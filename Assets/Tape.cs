
using UnityEngine;

public class Tape : MonoBehaviour
{
    public bool isPreview = false;
    public Vector2 start;
    public Vector2 end;
    
    void SetVisible(bool visible)
    {
        GetComponent<Renderer>().enabled = visible;
    }

    void Start()
    {
        SetVisible(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPreview)
        {
            return;
        }
        var otherLeak = other.gameObject.GetComponent<Leak>();
        if (otherLeak == null)
        {
            return;
        }
        
        Destroy(otherLeak.gameObject);
    }

    void Update()
    {
        if (isPreview)
        {
            //left mouse clicked
            if (Input.GetMouseButtonDown(0))
            {
                SetVisible(true);
                start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            } else if (Input.GetMouseButtonUp(0))
            {
                GameObject newTape = Instantiate(gameObject);
                Tape tape = newTape.GetComponent<Tape>();
                tape.isPreview = false;
                tape.SetVisible(true);
                SetVisible(false);
            }

            if (Input.GetMouseButton(0))
            {
                end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        transform.position = Vector2.Lerp(start, end, 0.5f);
        Vector2 diff = end - start;
        transform.localScale = new Vector2(diff.magnitude, 1);
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, diff));
        if (!isPreview)
        {
            SetVisible(true);
        }
    }
}