using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;
    private Vector3  offset;

    [SerializeField, Range(0,10)]private float deltaOffset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        if(offset.magnitude > deltaOffset)
            transform.position = playerTransform.position + offset;
    }

}
