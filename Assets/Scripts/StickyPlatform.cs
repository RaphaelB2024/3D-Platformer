using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private Vector3 lastPlatformPos;
    private GameObject player;
    private void Start()
    {
        lastPlatformPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            lastPlatformPos = transform.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = null;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            //Calculate platform movement since last frame
            Vector3 platformMovement = transform.position - lastPlatformPos;

            //Apply movement offset to player position
            player.transform.position += platformMovement;
        }

        //Update last position for next frame
        lastPlatformPos = transform.position;
    }
}
