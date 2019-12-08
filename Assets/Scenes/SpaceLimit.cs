using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceLimit : MonoBehaviour
{

    private Text timer;


     void Awake()
    {
        timer = GameObject.Find("UI_Warning_Timer").GetComponent<Text>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "RealSub")
        {
            GlobalController._ins.hitLimit(true);
            timer.text = GlobalController._limitDown.ToString();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RealSub")
        {
            GlobalController._ins.hitLimit(false);
        }
    }
}
