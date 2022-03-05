using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0,10)] private float speed = 2.0f;
    [SerializeField, Range(0,10)] private float jumpSpeed = 2.0f;

    public bool IsGrounded { get; private set; }
    public bool IsOnWall { get; private set; }
    private Rigidbody playerRigidbody;
    private Animator animator;

    private Vector3 contactPointNormal;

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
        if(IsGrounded)
            playerRigidbody.AddForce(movement * jumpSpeed);
        else if(IsOnWall)
            playerRigidbody.AddForce((movement+contactPointNormal) * jumpSpeed);
    }

    private void OnControllerColliderHit(ControllerColliderHit colliderHit)
    {
        Debug.DrawRay(colliderHit.point, colliderHit.normal, Color.red, 1.25f);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.layer)
        {
            case (int)LayerEnum.Ground:
                IsGrounded = true;
            break;
            case (int)LayerEnum.Wall:
                if(!IsGrounded)
                {
                    contactPointNormal = other.GetContact(0).normal * jumpSpeed;
                    IsOnWall = true;
                }
            break;
        }
    }

     private void OnCollisionStay(Collision other)
    {
        switch(other.gameObject.layer)
        {
            case (int)LayerEnum.Ground:
                IsGrounded = true;
            break;
            case (int)LayerEnum.Wall:
                if(!IsGrounded)
                {
                    IsOnWall = true;
                    contactPointNormal = other.GetContact(0).normal * jumpSpeed;
                }
            break;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        switch(other.gameObject.layer)
        {
            case (int)LayerEnum.Ground:
                IsGrounded = false;
            break;
            case (int)LayerEnum.Wall:
                IsOnWall = false;
            break;
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
