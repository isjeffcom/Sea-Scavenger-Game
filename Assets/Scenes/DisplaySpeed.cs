using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySpeed : MonoBehaviour
{   
    private GameObject mObj;
    private string mTxtCont;
    
    // Start is called before the first frame update
    void Awake() {
        mObj = gameObject;
    }


    // Update is called once per frame
    void LateUpdate(){
        
        if(ShipController.moveFB < 0){
            string text = Mathf.Ceil(-ShipController.moveFB).ToString();
            mObj.GetComponent<Text> ().text = "R" + text;
        } else {
            mObj.GetComponent<Text> ().text = Mathf.Ceil(ShipController.moveFB).ToString();
        }
        
    }
}
