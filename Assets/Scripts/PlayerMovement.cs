using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0,10)] private float speed = 2.0f;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlayer(Vector3 movement)
    {
        playerRigidbody.AddForce(movement * speed);
    }

    #if UNITY_EDITOR
    [ContextMenu("Reset values")]
    public void ResetValues()
    {
        speed = 2;
    }
    #endif
}
