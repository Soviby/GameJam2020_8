﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D platformEffect2D;
    public float holdTime;

    private void Start()
    {
        platformEffect2D = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            holdTime = 0.5f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (holdTime <= 0)
            {
                platformEffect2D.rotationalOffset = 180f;
                holdTime = 0.5f;
            }
            else
            {
                holdTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            platformEffect2D.rotationalOffset = 0f;
        }
    }

}
