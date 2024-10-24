using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int collectables = 0;

    public Text collectableText;

    private void OnColliderEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            collectables++;
            collectableText.text = "Score: " + collectables;
        }
    }




}
