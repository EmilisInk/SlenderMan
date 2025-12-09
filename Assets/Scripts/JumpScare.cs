using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    public Image image;

    public Transform target;

    public Enemy enemy;

    private void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    public void showImage()
    {
        enemy = FindObjectOfType<Enemy>();

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer <= 2)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
