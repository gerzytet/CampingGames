using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishCounter : MonoBehaviour
{
    public int required = 10;
    public static FishCounter instance;

    FishCounter()
    {
        instance = this;
    }

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Catch " + required;
    }
}
