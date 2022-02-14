using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
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

        movement = new Vector3(horizontal, 0, vertical).normalized;
    }

    void FixedUpdate()
    {
        playerMovement.MovePlayer(movement);
    }
}
