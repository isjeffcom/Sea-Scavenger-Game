using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    // Start is called before the first frame update
    public static DisplayResult _displayResult;

    private GameObject mObj;

    void Awake() {
        _displayResult = this;
        mObj = gameObject;
        //Debug.Log(mobj);
        
    }

    void Start(){
        mObj.GetComponent<Text> ().enabled = false;
    }

    public void showResult(string res) {
        mObj.GetComponent<Text> ().enabled = true;
        mObj.GetComponent<Text> ().text = res;
        StartCoroutine(close(3));
    }

    IEnumerator close(int delay){

        // Wait 3 Seconds to show the leaser effect
        yield return new WaitForSeconds(delay);

        mObj.GetComponent<Text> ().text = "";
        mObj.GetComponent<Text> ().enabled = false;

    }
}
