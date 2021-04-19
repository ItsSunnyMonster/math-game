//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    private float _xRotation = 0f; //keeping track of the x rotation so that we can clamp it afterwards

    public Transform playerBody; //transform of the player object

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock the cursor
    }

    private void Update()
    {
        //get mouse position input
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //set the x rotation and clamp it
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        //rotate according to the input
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}