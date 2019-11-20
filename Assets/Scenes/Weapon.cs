using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    public float power = 1.0f;
    public float range = 1000.0f;

    public int fireGap = 10;
    public int fireDistance = 500;

    //public ParticleSystem fireFlash;
    public GameObject fireSingle;

    public Camera cam;

    private int mFireTimer = 0;

    void Update () {

        if(mFireTimer > 0){
            mFireTimer = mFireTimer - 1;
            return;
        }

        if(Input.GetButton("Fire1")){
            if(mFireTimer == 0 && GlobalController._mode == 1){
                Shoot();
                mFireTimer = fireGap;
            }
        }
    }

    void Shoot () {

        // Copy Object
        GameObject instanceFF = Instantiate(fireSingle, transform.position, Quaternion.Euler(new Vector3 (0,0,0)));

        // Set instance's rotation 
        instanceFF.transform.rotation = transform.rotation;

        // Destroy Instance After PS Lifetime is over
        StartCoroutine(destroyInsPS(instanceFF, 3));
        

        /*RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, range)){

            ItemTarget target = hit.transform.GetComponent<ItemTarget>();
            
            if(target != null){
               
                target.TakeDamage(power);
            }
            
        }*/
    }

    IEnumerator destroyInsPS(GameObject obj, float delay){
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
