using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]private Transform respawnPosition;
    private Rigidbody player;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if(transform.position.y < 0)
        {
            RespawnPlayer();
        }        
    }

    private void RespawnPlayer()
    {
        transform.position = respawnPosition.position;
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.gameObject.layer == (int)LayerEnum.Enemy)
        {            
            RespawnPlayer();
        }
    }
}
