using System.Collections;
using UnityEngine;

public class ItemTarget : MonoBehaviour
{

    private Animator shieldAni;
    public float health = 100.0f;
    public int time = 1000;

    private void Awake()
    {
        shieldAni = gameObject.transform.Find("Shield").gameObject.GetComponent<Animator>();
        
    }

    public void TakeDamage (float amount) {
        
        health = health - amount;
        DamageShieldAni();
        if (health <= 0f){
            Die();
        }
    }

    void DamageShieldAni ()
    {
        shieldAni.SetBool("open", true);
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.name == "FireSingle(Clone)"){
            TakeDamage(10.0f);
        }
    }

    void Die()
    {
        gameObject.GetComponent<Animator>().SetBool("open", true);
        gameObject.transform.Find("Fire").gameObject.GetComponent<ParticleSystem>().Play();
        StartCoroutine(WaitToDie(3));

    }

    IEnumerator WaitToDie(int delay)
    {
        // Wait 3 Seconds to show the leaser effect
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        

    }
}
