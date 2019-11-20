
using UnityEngine;
using UnityEngine.UI;

public class DisplaySpeed : MonoBehaviour
{   

    // Update is called once per frame
    void LateUpdate(){

        gameObject.GetComponent<Text>().text = ParseSpeed(ShipController._moveFB);
        
    }

    string ParseSpeed (float val)
    {
        float num = val >= 0 ? Mathf.Ceil(val) : Mathf.Ceil(-val);
        string res = num.ToString();

        if (num < 100 && num > 9)
        {
            res = "0" + num.ToString();
        }

        else if (num < 9)
        {
            res = "00" + num.ToString();
        }

        return res;
    }
    
}
