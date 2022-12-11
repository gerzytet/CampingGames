using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RopeStub : MonoBehaviour
{
    public GameObject rope;
    public int type = -1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                GameObject newRope = Instantiate(this.rope, transform.parent, true);
                newRope.GetComponent<Rope>().start = transform.position;
                newRope.GetComponent<Rope>().type = type;
                newRope.GetComponent<Rope>().goal = RopeController.instance.GetGoal(gameObject);
            }
        }

        GetComponent<SpriteRenderer>().color = RopeController.instance.ropeColors[type];
    }
}
