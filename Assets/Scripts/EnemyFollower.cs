using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWaypointIndex = 0;
    bool EnemyDetector = false;

    public float Speed = 1f;

    private void Update()
    {
        if (EnemyDetector)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy Activator"))
        {
            EnemyDetector = true;
        }
    }
}
