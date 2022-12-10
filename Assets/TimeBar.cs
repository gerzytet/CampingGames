using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    public static TimeBar instance;
    public float time;
    private float originalX;
    private float originalSize;
    public static float MAX_TIME = 10f;

    public void ResetTime()
    {
        time = MAX_TIME;
    }

    TimeBar()
    {
        instance = this;
    }

    void Start()
    {
        ResetTime();
        originalX = transform.position.x;
        originalSize = ((RectTransform) transform).rect.width;
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 0;
        }
        
        float timePercent = time / MAX_TIME;
        float newX = Mathf.Lerp(originalX - (originalSize / 2), originalX, timePercent);
        float newSize = Mathf.Lerp(0, originalSize, timePercent);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        ((RectTransform) transform).sizeDelta = new Vector2(newSize, ((RectTransform) transform).rect.height);
        //transform.localScale = new Vector3(newSize, transform.localScale.y, transform.localScale.z);
    }
}
