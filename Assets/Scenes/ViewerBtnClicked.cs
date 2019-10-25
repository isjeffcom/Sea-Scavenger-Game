using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewerBtnClicked : MonoBehaviour
{   
    public GameObject UI_Score;
    private GameObject Item;
    private Text resText;
    // Start is called before the first frame update
    public void onClickHandler (string value) {

        ColliderDetector._instance.exitViewerMode();

        //ameObject dr = GameObject.Find("UI_Score");

        if(value == ColliderDetector.currentSolution){
            ColliderDetector.score = ColliderDetector.score + 1000;
            DisplayResult._displayResult.showResult("Go Job !!");
        }else{
            DisplayResult._displayResult.showResult("WRONG");
        }

        
        
    }
}
