﻿using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    private Vector3  offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        transform.position = playerTransform.position + offset;
    }

}
