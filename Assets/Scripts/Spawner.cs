using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int count = 8;

    public Vector3 startPosition;
    public Vector3 endPosition;

    public LayerMask groundLayer;

    public TextMeshProUGUI collectibleCountText;

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var pos = new Vector3();
            pos.x = Random.Range(startPosition.x, endPosition.x);
            pos.y = 500;
            pos.z = Random.Range(startPosition.z, endPosition.z);

            if (Physics.Raycast(pos, Vector3.down, out RaycastHit hit, 1000, groundLayer))
            {
                var rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

                Instantiate(prefab, hit.point, rotation);
            }
        }

        UpdateUI();
    }

    public void Collect()
    {
        count--;
        UpdateUI();
    }

    private void UpdateUI()
    {
        collectibleCountText.text = "Collectibles: " + count.ToString();
    }

}
