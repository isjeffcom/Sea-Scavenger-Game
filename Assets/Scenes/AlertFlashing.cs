using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertFlashing : MonoBehaviour
{   
    // 0 Red, 1 Blue
    private int state = 0;
    private float dt;
    private Light mLight;

    // Start is called before the first frame update
    void Awake () {
        mLight = this.GetComponent<Light> ();
    }

    void Start(){
        InvokeRepeating("flashing", 1.0f, 0.1f);
    }

    void flashing() {

        if(state == 0){
            mLight.color = Color.red;
            state = 1;
        } 
        
        else {
            mLight.color = Color.blue;
            state = 0;
        }
         
    }
}
