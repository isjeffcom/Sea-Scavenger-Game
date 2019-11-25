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

        if(value == ColliderDetector.currentSolution){
            GlobalController._score = GlobalController._score + 1000;
            DisplayResult._displayResult.showResult("Go Job !!");
        }else{
            DisplayResult._displayResult.showResult("WRONG");
        }

        
        
    }
}
