using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public float chance = 0.1f;
    
    private void FixedUpdate()
    {
        if (Random.Range(0.0f, 1.0f) < chance)
        {
            int index = Random.Range(0, transform.childCount);
            Transform child = transform.GetChild(index);
            int type = Random.Range(0, FishingController.instance.maxFish);
            GameObject fish = Instantiate(FishingController.instance.fish, child.position, Quaternion.identity);
            fish.GetComponent<Fish>().type = type;
            fish.transform.SetParent(transform.parent);
        }
    }
}
