using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float ToTarget;
    public bool carpiyor;

    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            if (Hit.transform.gameObject.tag == "Selectable")
            {
                carpiyor = true;
                ToTarget = Hit.distance;
                DistanceFromTarget = ToTarget;
            }
        }
        else
        {
            carpiyor = false;
        }
    }
}
