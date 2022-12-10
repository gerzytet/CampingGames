
using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public int lives = 3;
    public static Lives instance;

    public Lives()
    {
        instance = this;
    }
    
    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Lives : " + lives;
    }
}
