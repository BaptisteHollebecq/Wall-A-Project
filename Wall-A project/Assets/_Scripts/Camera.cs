using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public Transform lookAtTransform;
    public float cameraSpeed = 5;
    public bool automatic = false;

    private float xRot;
    private float zRot;

    private float distance;

    private void Awake()
    {
        xRot = transform.rotation.x;
        distance = Vector3.Distance(transform.position, lookAtTransform.position);
    }

    private void Update()
    {
        xRot = transform.rotation.eulerAngles.x;

        transform.rotation = Quaternion.LookRotation(lookAtTransform.position - transform.position, Vector3.up);

        // transform.LookAt(lookAtTransform);

        if (!automatic)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * cameraSpeed * Time.fixedDeltaTime);
                transform.rotation = Quaternion.LookRotation(lookAtTransform.position - transform.position, Vector3.up);
            }

            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(Vector3.right * cameraSpeed * Time.fixedDeltaTime);
                transform.rotation = Quaternion.LookRotation(lookAtTransform.position - transform.position, Vector3.up);
            }
        }
        else
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.LookRotation(lookAtTransform.position - transform.position, Vector3.up);
        }


        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

    private void LateUpdate()
    {
       transform.rotation = Quaternion.LookRotation(lookAtTransform.position - transform.position, Vector3.up);
    }
}
