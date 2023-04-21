
using UnityEngine;

public class Point : MonoBehaviour
{
    public void Spawn(Unit unit)
    {
        Instantiate(unit, transform.position,Quaternion.identity);
    }
}
