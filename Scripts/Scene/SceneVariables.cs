using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVariables : MonoBehaviour {

    [SerializeField]
    private Pool projectilePool;
    public Pool ProjectilePool { get { return projectilePool; } }
    [SerializeField]
    private UIControl uiControl;
    public UIControl UIControl { get { return uiControl; } }
    [SerializeField]
    private LiveUI liveUI;
    public LiveUI LiveUI { get { return liveUI; } }

    [SerializeField]
    private PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement { get { return playerMovement; } }

    [SerializeField]
    private GameObject playerObject;
    public GameObject PlayerObject { get { return playerObject; } }

    [SerializeField]
    private GameObject checkpointsParent;
    public GameObject CheckpointsParent { get { return checkpointsParent; } }
    [SerializeField]
    private GameObject[] checkpointArray;
    public GameObject[] CheckpointArray { get { return checkpointArray; } }
    
}
