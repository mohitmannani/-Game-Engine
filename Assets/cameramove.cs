using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
   
    public float moveSpeed = 5f;
    public Camera mainCamera; // Reference to the specific camera

    void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Camera reference not set. Please assign a camera in the Inspector.");
            return;
        }

        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Check for WASD keys for movement
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        mainCamera.transform.Translate(moveDirection);
    }
}
