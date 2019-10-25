using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTarget : MonoBehaviour
{   
    public float health = 100.0f;
    
    public void TakeDamage (float amount) {
        Debug.Log(health);
        health = health - amount;
        if(health <= 0f){
            Die();
        }
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.name == "FireSingle(Clone)"){
            TakeDamage(10.0f);
        }
    }

    void Die () {
        Destroy(gameObject);
    }
}
