
using UnityEngine;

public class Spawn_Point : MonoBehaviour
{
    private Vector3 position;
    
    public void Spawn(GameObject gameObject)
    {
        Instantiate(gameObject, transform);
    }
}
