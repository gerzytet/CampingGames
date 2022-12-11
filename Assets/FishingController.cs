
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class FishingController : MinigameController
{
    public GameObject fish;
    public int maxFish = 3;

    public List<Sprite> fishSprites;
    
    public static FishingController instance;

    FishingController()
    {
        instance = this;
    }
    public override bool IsWon()
    {
        return FishCounter.instance.required <= 0;
    }

    public override bool IsLost()
    {
        return false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Rod.instance.length -= Rod.instance.speed;
        }
        else
        {
            Rod.instance.length += Rod.instance.speed;
        }

        Rod.instance.length = Mathf.Clamp(Rod.instance.length, 0, 1);
    }
}
