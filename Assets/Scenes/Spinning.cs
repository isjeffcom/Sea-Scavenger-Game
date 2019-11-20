using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{

    void Update()
    {
        if (ShipController._moveFB != 0)
        {
            transform.Rotate(0, 0, 10 * ShipController._moveFB * Time.deltaTime);
        } else
        {
            transform.Rotate(0, 0, 140 * Time.deltaTime);
        }
        
    }


}
