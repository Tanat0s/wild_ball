﻿using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField]private Transform cameraTransform;
    private PlayerMovement playerMovement;
    private Vector3 movement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        var horizontal = Input.GetAxis(GlobalStringValues.Horizontal_Axis);
        var vertical = Input.GetAxis(GlobalStringValues.Vertical_Axis);
       
        movement = new Vector3(horizontal, 0, vertical);
        movement = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movement;
        movement.Normalize();
    }

    void FixedUpdate()
    {
        playerMovement.MovePlayer(movement);
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = focus ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
