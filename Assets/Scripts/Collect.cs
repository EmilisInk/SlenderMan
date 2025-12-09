using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private Enemy enemy;

    private AudioSource collectSound;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        collectSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Spawner spawner = FindObjectOfType<Spawner>();
            spawner.Collect();
            AudioSource.PlayClipAtPoint(collectSound.clip, transform.position);

            enemy.IncreaseSpeed();


            Destroy(gameObject);
        }
    }
}
