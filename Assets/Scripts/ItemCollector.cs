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
    int batteries = 0;
    float time = 0;

    public TextMeshProUGUI collectableText;
    public TextMeshProUGUI TimeText;
    public AudioSource coinSound;
    public AudioSource batterySound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            coinSound.Play();
            Destroy(other.gameObject);
            collectables++;
            collectableText.text = "Score: " + collectables;
        }

        if(other.gameObject.CompareTag("Battery"))
        {
            batterySound.Play();
            Destroy(other.gameObject);
            batteries++;
        }

        if (batteries == 1)
        {

        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        TimeText.text = "Time: " + Mathf.Round((time *100)) / 100;
    }
}
