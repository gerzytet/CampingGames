using System.Collections.Generic;
using UnityEngine;

public class RopeController : MinigameController
{
    public GameObject tops;
    public GameObject bottoms;

    public List<Color> ropeColors;
    
    public static RopeController instance;
    public List<bool> solved;

    RopeController()
    {
        instance = this;
    }

    public GameObject GetGoal(GameObject stub)
    {
        int type = stub.GetComponent<RopeStub>().type;
        foreach (RopeStub s in FindObjectsOfType<RopeStub>())
        {
            if (s.type == type && s.gameObject != stub)
            {
                return s.gameObject;
            }
        }
        
        Debug.Log("null");
        return null;
    }

    void Setup(GameObject row, int types)
    {
        List<RopeStub> childStubs = new List<RopeStub>(row.GetComponentsInChildren<RopeStub>());
        for (int i = 0; i < types; i++)
        {
            while (true)
            {
                int index = Random.Range(0, childStubs.Count);
                if (childStubs[index].type == -1)
                {
                    childStubs[index].type = i;
                    break;
                }
            }
        }

        foreach (RopeStub stub in childStubs)
        {
            if (stub.type == -1)
            {
                stub.gameObject.SetActive(false);
            }
        }

        
    }

    void Start()
    {
        int types = 5;
        Setup(tops, types);
        Setup(bottoms, types);
        for (int i = 0; i < types; i++)
        {
            solved.Add(false);
        }
    }

    public override bool IsWon()
    {
        foreach (bool b in solved)
        {
            if (!b)
            {
                return false;
            }
        }

        return true;
    }

    public override bool IsLost()
    {
        return false;
    }
}
