using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0,10)] private float speed = 2.0f;
    [SerializeField, Range(0,10)] private float jumpSpeed = 2.0f;

    public bool IsGrounded { get; private set; }
    private Rigidbody playerRigidbody;
    private Animator animator;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(playerRigidbody.velocity.x == 0 && playerRigidbody.velocity.z == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }

    public void MovePlayer(Vector3 movement)
    {
        playerRigidbody.AddForce(movement * speed);
    }

    public void JumpPlayer(Vector3 movement)
    {
        playerRigidbody.AddForce(movement * jumpSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == (int)LayerEnum.Ground)
        {
            IsGrounded = true;
        }
    }

     private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.layer == (int)LayerEnum.Ground)
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.layer == (int)LayerEnum.Ground)
        {
            IsGrounded = false;
        }
    }

    #if UNITY_EDITOR
    [ContextMenu("Reset values")]
    public void ResetValues()
    {
        speed = 2;
    }
    #endif
}
