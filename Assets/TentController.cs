using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TentController : MonoBehaviour
{
    public GameObject drop;

    public GameObject leak;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            var point = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            for (int j = 0; j < 6; j++)
            {
                Instantiate(leak, point + new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var leaks = FindObjectsOfType<Leak>();
        if (leaks.Length == 0)
        {
            return;
        }
        var leak = leaks[Random.Range(0, leaks.Length)];
        Instantiate(drop, leak.transform.position, leak.transform.rotation);
    }
}