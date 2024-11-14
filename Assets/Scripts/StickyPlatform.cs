using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private Vector3 originalScale; // Store the player's original scale

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            originalScale = collision.transform.localScale; // Save the original scale
            collision.transform.SetParent(transform); // Parent the player to the platform
            collision.transform.localScale = originalScale; // Reset the player's scale
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); // Unparent the player
            collision.transform.localScale = originalScale; // Reset the player's scale just in case
        }
    }
}
