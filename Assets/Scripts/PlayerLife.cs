using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    public GameObject player;
    public float DeathPit = -50f;

    public AudioSource deathSound;

    void Update()
    {
        if (player.transform.position.y < DeathPit)
       {
            Die();
       }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision .gameObject.CompareTag("EnemyBody"))
        {
            Die();
        }
    }

    void Die()
    {
        deathSound.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(ReloadLevel),1.3f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
