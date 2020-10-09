using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public abstract void Move(float horizontal, float vertical);
    public abstract void Jump();
}