﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds;      //Array (list) of all background to be parallaxed
    private float[] parallaxScales;      //proportion of the camera's movement to move the background by
    public float smoothing = 1f;              // How smooth the parallax is going to be. make sure to set above 0.

    private Transform cam;
    private Vector3 previousCamPostion;


    private void Awake()
    {
        cam = Camera.main.transform;
    }
    // Use this for initialization
    void Start()
    {

        previousCamPostion = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPostion.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPostion = cam.position;
    }
}
