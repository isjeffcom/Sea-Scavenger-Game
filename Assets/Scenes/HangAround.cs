using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangAround : MonoBehaviour
{   
    public int movementChange = 1000;
    public float hangingY = 60;
    private int count = 0;
    private int dir = 0; // 0: left, 1: right, 2: forward, 3: backword
    private Vector3 startPos;

    private Vector3 velocity = Vector3.zero;
    void Start () {  
       startPos = new Vector3 (Random.Range(-50.0f, 50.0f), hangingY, Random.Range(-320.0f, -430.0f));
       transform.position = startPos;
    }

    // Update is called once per frame
    void Update () {
        if(count < movementChange){
            MoveByDir(transform, dir);
            count++;
        } else {
            count = 0;
            dir = dir == 3 ? 0 : Random.Range(0, 3);
        }
    }

    void MoveByDir (Transform transform, int d){
        float x = 0f;
        float z = 0f;

        if(d == 0){
            x = -10f;
        }

        else if(d == 1){
            x = 10f;
        }

        else if (d == 2){
            z = 10f;
        }

        else if (d == 3){
            z = -10f;
        }

        Vector3 movingTarget = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            movingTarget,
            ref velocity,
            2,
            Mathf.Infinity,
            Time.deltaTime
        );


        
    }

}
