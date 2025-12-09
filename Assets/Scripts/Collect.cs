using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Enemy enemy;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Spawner spawner = FindObjectOfType<Spawner>();
            spawner.Collect();

            enemy.IncreaseSpeed();


            Destroy(gameObject);
        }
    }
}
