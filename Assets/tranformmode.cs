using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum TransformMode
{
    Move,
    Resize,
    Rotate,
    Reset,
    ResetSize
}

public class tranformmode : MonoBehaviour
{
    private TransformMode currentMode = TransformMode.Move;
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialScale;
    private Quaternion initialRotation;
    private Vector3 initialPosition = new Vector3(-20f, 0f, 0f);
    private Quaternion currentRotation;

    private Vector3 initialSize;
    private Vector3 resetPosition;
    public GameObject resetPositionObject;




    public Rigidbody rb;
    public Button toggleGravityButton;
    public Button increaseDragButton;
    public Button decreaseDragButton;

    private bool isGravityOn = false;




    private void Start()
        {
            // Set the default mode to Move
            SetMode(TransformMode.Move);
            initialScale = transform.localScale; // Set the initialScale only once at the start
            initialRotation = transform.rotation;
            currentRotation = initialRotation; // Initialize currentRotation
        initialPosition = transform.localPosition;


        initialSize = transform.localScale;

        resetPosition = resetPositionObject != null ? resetPositionObject.transform.position : Vector3.zero;




        // Assign button click listeners
      //  toggleGravityButton.onClick.AddListener(ToggleGravity);
        increaseDragButton.onClick.AddListener(IncreaseDrag);
        decreaseDragButton.onClick.AddListener(DecreaseDrag);

        // Get the Rigidbody component if not assigned in the Inspector
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }



    public void ToggleGravity()
    {
        isGravityOn = !isGravityOn;
        rb.useGravity = isGravityOn;
    }

    public void IncreaseDrag()
    {
        rb.drag += 0.1f; // Adjust the drag value as needed
    }

    public void DecreaseDrag()
    {
        rb.drag = Mathf.Max(0f, rb.drag - 0.1f); // Ensure drag doesn't go below zero
    }



    public void SetMode(TransformMode mode)
    {
        currentMode = mode;
    }

    public void MoveObject()
    {
        SetMode(TransformMode.Move);
    }

    public void ResizeObject()
    {
        SetMode(TransformMode.Resize);
    }

    public void RotateObject()
    {
        SetMode(TransformMode.Rotate);
    }
    public void ResetObject()
    {
        SetMode(TransformMode.Reset);
       
            SetMode(TransformMode.Reset);

        if (resetPositionObject != null)
        {
            transform.position = resetPosition;
        }



    }


    public void ResetSize()
    {
        SetMode(TransformMode.ResetSize);
        transform.localScale = initialSize;
    }

    private void OnMouseDown()
    {
        if (currentMode == TransformMode.Move)
        {
            isDragging = true;
            offset = transform.position ;
        }
        else if (currentMode == TransformMode.Resize)
        {
            isDragging = true;
            initialScale = transform.localScale;
            initialPosition = transform.position; // Store the initial position
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void Update()
    {
        if (currentMode == TransformMode.Rotate)
        {
            // Implement code for rotating the object with WASD keys
            Debug.Log("current mode");
            RotateSelectedObject();
        }else if (currentMode == TransformMode.Resize)
        {
            // Implement code for resizing the selected object with mouse
            ResizeSelectedObject();
        }
        if (isDragging)
        {

            
             if (currentMode == TransformMode.Move)
            {
                Vector3 targetPosition = GetMouseWorldPosition() + offset;


                Debug.Log(targetPosition);

                transform.position = targetPosition/2;
            }
        }
    }

    private void ResizeSelectedObject()
{
    // Initialize the scaling factors to 1.0
    float scaleFactorX = 1.0f;
    float scaleFactorY = 1.0f;
    float scaleFactorZ = 1.0f;

    if (Input.GetKey(KeyCode.W))
    {
        scaleFactorY = 1.01f;
    }
    else if (Input.GetKey(KeyCode.S))
    {
        scaleFactorY = 0.99f;
        }

    if (Input.GetKey(KeyCode.A))
    {
        scaleFactorX = 1.01f; 
    }
    else if (Input.GetKey(KeyCode.D))
    {
        scaleFactorX = 0.99f;
        }

    if (Input.GetKey(KeyCode.Q))
    {
        scaleFactorZ = 1.01f;
        }
    else if (Input.GetKey(KeyCode.E))
    {
        scaleFactorZ = 0.99f;
        }

    // Apply the scaling factors incrementally to the object's local scale
    transform.localScale = new Vector3(transform.localScale.x * scaleFactorX, transform.localScale.y * scaleFactorY, transform.localScale.z * scaleFactorZ);
}

  

    private void RotateSelectedObject()
    {
        // Calculate the rotation angles based on input
        float rotationX = 0f;
        float rotationY = 0f;
        float rotationZ = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            rotationX = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rotationX = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotationY = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationY = -1.0f;
        }

        // Apply the rotations incrementally to the current rotation
        currentRotation = Quaternion.Euler(rotationX, rotationY, rotationZ) * currentRotation;
        transform.rotation = currentRotation;
    }
}