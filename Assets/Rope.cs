using Unity.VisualScripting;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Vector2 start;
    public Vector2 end;

    public int type;
    public GameObject goal;
    public bool frozen = false;

    void Update()
    {
        if (frozen)
        {
            return;
        }
        transform.position = Vector2.Lerp(start, end, 0.5f);
        Vector2 diff = end - start;
        transform.localScale = new Vector2(diff.magnitude, 1);
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, diff));
        end = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (goal.GetComponent<Collider2D>().OverlapPoint(end))
            {
                end = goal.transform.position;
                frozen = true;
                RopeController.instance.solved[type] = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
