﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public Transform lookAtTransform;
    public float cameraSpeed = 5;
    public bool automatic = false;

    private void Update()
    {
        transform.LookAt(lookAtTransform);

        if (!automatic)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * cameraSpeed * Time.fixedDeltaTime);
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(Vector3.right * cameraSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.fixedDeltaTime);
        }


        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }
}
