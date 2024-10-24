using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            collectables++;
            Debug.Log("Collectables: " + collectables);
        }
    }




}
