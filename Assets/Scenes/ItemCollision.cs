using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{


    public Transform hint;
    public Transform mainCamera;


    Vector3 hintOffset = new Vector3(8, 8, -8);
    private GameObject instanceObj;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RealSub")
        {
   
            hint.position = transform.position + hintOffset;
        }

    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "RealSub")
        {
            
            hint.LookAt(mainCamera);

            if (Input.GetKeyDown(KeyCode.E))
            {
                ColliderDetector._instance.toViewItem(gameObject);
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RealSub")
        {

            hint.position = new Vector3(-1,-1,1);
        }
    }


}
