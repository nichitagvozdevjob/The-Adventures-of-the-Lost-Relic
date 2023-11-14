using UnityEngine;

public class Attackable : MonoBehaviour
{
    public virtual void GetHit()
    {
        Destroy(gameObject);
    }
}
