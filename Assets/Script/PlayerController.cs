using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float maximumSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private GameObject map;

    private bool mapControll;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        mapControll = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        /*
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }*/

        float speed = inputMagnitude * maximumSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
            Physics.gravity = -Physics.gravity;

            transform.Rotate(new Vector3(0, 0, 180), Space.Self);
            */

            if (mapControll)
            {
                map.transform.rotation = Quaternion.Euler(0, 0, -180);
                mapControll = false;
            }
            else
            {
                map.transform.rotation = Quaternion.Euler(0, 0, 0);
                mapControll = true;
            }
        }

        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        Vector3 velocity = movementDirection * speed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    #region Change Material

    [SerializeField] private MeshRenderer skin;
    [SerializeField] private Material defaultSkinMat;

    public void ChangeSkinMat(Material newSkinMat)
    {
        skin.material = newSkinMat;
    }

    public void ResetSkinMat()
    {
        ChangeSkinMat(defaultSkinMat);
    }
    #endregion

    public void ExitBuild()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

