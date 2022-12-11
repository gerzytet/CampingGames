using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public float length = 1f;

    public static Rod instance;
    public float originalY;
    public float originalSize;
    public float hookY;
    public GameObject hook;
    public float speed = 0.02f;

    Rod()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
        originalSize = transform.localScale.y;
        hookY = hook.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float bottom = originalY + originalSize / 2;
        transform.position = new Vector2(transform.position.x, Mathf.Lerp(bottom, originalY, length));
        transform.localScale = new Vector2(transform.localScale.x, Mathf.Lerp(0, originalSize, length));
        hook.transform.position = new Vector2(hook.transform.position.x, Mathf.Lerp(bottom, hookY, length));
    }
}
