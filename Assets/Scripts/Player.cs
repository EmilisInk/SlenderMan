using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject flashlight;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }
    }
}
