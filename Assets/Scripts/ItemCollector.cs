using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int collectables = 0;

    public TextMeshProUGUI collectableText;
    public AudioSource coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            coinSound.Play();
            Destroy(other.gameObject);
            collectables++;
            collectableText.text = "Score: " + collectables;
        }
    }


}
