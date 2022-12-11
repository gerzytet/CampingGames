
using UnityEditor;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public static float speed = 3f;
    public int type;
    
    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = FishingController.instance.fishSprites[type];
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        if (transform.position.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
    }
}
