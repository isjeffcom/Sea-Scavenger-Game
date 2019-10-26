using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFlash : MonoBehaviour
{
    public float delay = 4f;
    public int flashDelay = 1000;

    public GameObject mObj;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayFlashing(delay));
    }



    IEnumerator delayFlashing (float delay)
    {
        
        while (true)
        {
      
            yield return new WaitForSeconds(delay);
            flashTwice();

        }
        
    }

    

    void flashOnce ()
    {
        mObj.GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1.0f, 0.2f));
        StartCoroutine(flashOnceTimer(0.03f));


    }

    IEnumerator flashOnceTimer(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        mObj.GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1.0f, 1f));

    }

    void flashTwice()
    {
        StartCoroutine(flashTwiceTimer(0.08f));
        
    }

    IEnumerator flashTwiceTimer(float delay)
    {
        flashOnce();
        yield return new WaitForSeconds(delay);
        flashOnce();

    }
}

