using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform lookAtTransform;
    public float cameraSpeed = 5;

    private void Update()
    {
        transform.LookAt(lookAtTransform);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.fixedDeltaTime);
        }
    }
}
