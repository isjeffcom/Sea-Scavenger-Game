using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameObject mObj;
    private Text t;
    // Start is called before the first frame update
    void Awake() {
        mObj = gameObject;
    }

    // Update is called once per frame
    void LateUpdate() {
        mObj.GetComponent<Text> ().text = "Money: " + GlobalController._score.ToString();
    }
}
