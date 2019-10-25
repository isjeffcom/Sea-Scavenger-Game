using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSingle : MonoBehaviour
{
    public float movingSpeed = 100.0f;

    private Vector3 velocity = Vector3.zero;
    void Update () {
        transform.position += (transform.rotation * Vector3.forward) * Time.deltaTime * movingSpeed;
    }
}
