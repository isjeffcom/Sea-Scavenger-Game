using UnityEngine;
using UnityEngine.UI;

public class ViewerBtnClicked : MonoBehaviour
{   
    public GameObject UI_Score;
    private GameObject Item;
    private Text resText;
    // Start is called before the first frame update
    public void onClickHandler (string value) {
        bool final = false;
        int money = 0;
        //Debug.Log("value: " + value);
        //Debug.Log("Solution: " + ItemViewerController.itemSolution);
        if(value == ItemViewerController.itemSolution){
            money = 1000;
            GlobalController._score = GlobalController._score + money;
            DisplayResult._ins.showResult("RIGHT", "1000", ItemViewerController.itemSolution);
            final = true;
        }else{
            DisplayResult._ins.showResult("WRONG", "0", ItemViewerController.itemSolution);
            final = false;
        }
        GlobalController._ins.CollectItem(ItemViewerController.itemName, ItemViewerController.itemSolution, final, money);
        ColliderDetector._instance.exitViewerMode();

    }
}
