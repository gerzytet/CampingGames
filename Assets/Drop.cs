using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Drop : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(0.0f, 1.0f), 0);
        Destroy(gameObject, 3);
    }

    void Update()
    {
        
    }
}
