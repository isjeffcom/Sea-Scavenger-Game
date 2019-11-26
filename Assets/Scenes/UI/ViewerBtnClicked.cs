using UnityEngine;
using UnityEngine.UI;

public class ViewerBtnClicked : MonoBehaviour
{   
    public GameObject UI_Score;
    private GameObject Item;
    private Text resText;
    // Start is called before the first frame update
    public void onClickHandler (string value) {

        if(value == ItemViewerController.itemSolution){
            GlobalController._score = GlobalController._score + 1000;
            DisplayResult._ins.showResult("RIGHT", "1000");
        }else{
            DisplayResult._ins.showResult("WRONG", "0");
        }

        ColliderDetector._instance.exitViewerMode();

    }
}
