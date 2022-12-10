using UnityEngine;

public abstract class MinigameController : MonoBehaviour
{
    public abstract bool IsWon();
    public abstract bool IsLost();
}