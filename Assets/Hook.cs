using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public List<GameObject> fish;

    void OnTriggerEnter2D(Collider2D col)
    {
        var fish = col.gameObject.GetComponent<Fish>();
        if (fish == null)
        {
            return;
        }
        
        this.fish.Add(fish.gameObject);
        fish.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        foreach (GameObject f in fish)
        {
            f.transform.position = Vector2.MoveTowards(f.transform.position, transform.position, 0.5f);
        }

        if (Rod.instance.length < 0.1f)
        {
            FishCounter.instance.required -= fish.Count;
            foreach (GameObject f in fish)
            {
                Destroy(f);
            }
            fish.Clear();
        }
    }
}
