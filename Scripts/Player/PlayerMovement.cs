using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour
{

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    private float accelerationTimeAirborne = .2f;
    private float accelerationTimeGrounded = .1f;
    [SerializeField]
    private float moveSpeed = 6;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    private float moveDirection = 0;

    //private enum MoveState { Stationary, Left, Right };
   // private MoveState playerMoveState = MoveState
    private enum ButtonState { NotPressed, Down, Hold, Released };
    private ButtonState jumpButtonState = ButtonState.NotPressed;
    private ButtonState leftButtonState = ButtonState.NotPressed;
    private ButtonState rightButtonState = ButtonState.NotPressed;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
    }

    public void StopMovement()
    {
        moveDirection = 0;
    }

    public void FlipMoveDirection()
    {
        moveDirection = -moveDirection;
    }

    public void ButtonLeftPress()
    {
        leftButtonState = ButtonState.Down;
        MoveLeft();
    }
    public void ButtonLeftRelease()
    {
        leftButtonState = ButtonState.Released;
        if (rightButtonState == ButtonState.Down)
        {
            MoveRight();
        }
        else
            StopMovement();
    }

    public void ButtonRightPress()
    {
        rightButtonState = ButtonState.Down;
        MoveRight();

    }
    public void ButtonRightRelease()
    {
        rightButtonState = ButtonState.Released;
        if (leftButtonState == ButtonState.Down)
        {
            MoveLeft();
        }
        else
            StopMovement();
    }
    public void MoveLeft()
    {
        moveDirection = -1;
    }

    public void MoveRight()
    {
        moveDirection = 1;
    }

    public void JumpPressDown()
    {
        jumpButtonState = ButtonState.Down;
    }

    public void JumpRelease()
    {
        jumpButtonState = ButtonState.Released;
    }

    void Update()
    {
        Vector2 input = new Vector2(moveDirection, 0);
        int wallDirX = (controller.collisions.left) ? -1 : 1;

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        bool wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (input.x != wallDirX && input.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }

        }




        //TODO Updated to button
        //Jump Input
        if (jumpButtonState == ButtonState.Down)
        {
            if (wallSliding)
            {
                jumpButtonState = ButtonState.Hold;
                GameManager.Instance.AudioController.PlayJumpSound();
                if (wallDirX == input.x)
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else if (input.x == 0)
                {
                    velocity.x = -wallDirX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else
                {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            }
            if (controller.collisions.below)
            {
                jumpButtonState = ButtonState.Hold;
                GameManager.Instance.AudioController.PlayJumpSound();
                velocity.y = maxJumpVelocity;
            }
        }
        if (jumpButtonState == ButtonState.Released)
        {
            jumpButtonState = ButtonState.NotPressed;
            //check already isn't low velocity
            if (velocity.y > minJumpVelocity)
                velocity.y = minJumpVelocity;
        }

        velocity.y += gravity * Time.deltaTime;
        velocity.y = Mathf.Clamp(velocity.y, -30f, 50f);
        controller.Move(velocity * Time.deltaTime, input);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
    }

    void UpdateOLD()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        int wallDirX = (controller.collisions.left) ? -1 : 1;

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        bool wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (input.x != wallDirX && input.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }

        }

     


        //TODO Updated to button
        //Jump Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallSliding)
            {
                if (wallDirX == input.x)
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else if (input.x == 0)
                {
                    velocity.x = -wallDirX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else
                {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            }
            if (controller.collisions.below)
            {
                velocity.y = maxJumpVelocity;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //check already isn't low velocity
            if (velocity.y > minJumpVelocity)
                velocity.y = minJumpVelocity;
        }

        velocity.y += gravity * Time.deltaTime;
        velocity.y = Mathf.Clamp(velocity.y, -30f,50f);
        controller.Move(velocity * Time.deltaTime, input);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
    }
}