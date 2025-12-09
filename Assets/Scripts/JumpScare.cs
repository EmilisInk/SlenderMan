using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    public Image Image;
    public Transform Target;
    public Enemy Enemy;

    private AudioSource audioSource;

    public bool isShowing = false;

    public TextMeshProUGUI gameover;

    private void Start()
    {
        Image = GetComponent<Image>();

        Image.enabled = false;
        gameover.enabled = false;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(Enemy.transform.position, Target.position);
        bool shouldShow = distanceToPlayer <= 2f;
        Debug.Log("Distance: " + distanceToPlayer + " Should show: " + shouldShow);

        

        if (shouldShow && !isShowing)
        {
            Image.enabled = true;
            audioSource.Play();
            isShowing = true;
            gameover.enabled = true;

            Invoke("RestartGame", 2f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

