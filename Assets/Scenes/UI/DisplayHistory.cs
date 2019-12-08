using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHistory : MonoBehaviour
{
    public static DisplayHistory _ins;

    private bool act = false;

    private Sprite img_wrong;
    private Sprite img_delete;
    private Sprite img_collect;

    private CanvasGroup UI_History;

    // UIs
    private GameObject first;
    private GameObject empty_text;


    // Instantiate UI Element
    public GameObject HistorySingle;
    

    // Start is called before the first frame update
    void Awake()
    {
        _ins = this;

        //perpare resources
        img_collect = Resources.Load<Sprite>("UI_IV_Solu_Collect_Icon");
        img_delete = Resources.Load<Sprite>("UI_IV_Solu_Destroy_Icon");
        img_wrong = Resources.Load<Sprite>("UI_History_Res_Wrong");

        first = GameObject.Find("UI_History_Cont_Inner").transform.GetChild(0).gameObject;
        empty_text = GameObject.Find("UI_History_EmptyText");
    }

    void LateUpdate()
    {   
        if(act == false)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            UI_History.alpha = 1f;
            UI_History.blocksRaycasts = true;
        }
        else
        {
            UI_History.alpha = 0f;
            UI_History.blocksRaycasts = false;
        }
    }

    public void Ended()
    {
        act = false;
        UI_History.alpha = 1f;
        UI_History.blocksRaycasts = true;
    }

    public void init()
    {
        UI_History = GameObject.Find("UI_History").GetComponent<CanvasGroup>();
        act = true;
    }

    public void AddHistory (string name, string solution, bool res, int money)
    {

        // Replace First Item, a little bit hacky, not the best way

        if(GlobalController._collected == 0)
        {
            parseData(first, solution, name, money, res);
            initial();
        } else
        {
            // Set New Position By Last Position
            Vector2 LastItemPosi = gameObject.transform.GetChild(transform.childCount - 1).GetComponent<RectTransform>().anchoredPosition;
            Vector2 ThisPosi = new Vector2(LastItemPosi.x, LastItemPosi.y - 70);

            GameObject s = Instantiate(HistorySingle, gameObject.transform, false);
            s.GetComponent<RectTransform>().anchoredPosition = ThisPosi;

            parseData(s, solution, name, money, res);
            
        }

    }

    void initial ()
    {
        first.GetComponent<CanvasGroup>().alpha = 1;
        empty_text.GetComponent<CanvasGroup>().alpha = 0;
    }

    void parseData(GameObject obj, string solution, string name, int money, bool res)
    {
        if (solution == "Collect")
        {
            obj.transform.Find("UI_History_S_Sulution").GetComponent<Image>().sprite = img_collect;
        }

        if (solution == "Destroy")
        {
            obj.transform.Find("UI_History_S_Sulution").GetComponent<Image>().sprite = img_delete;
        }


        if (!res)
        {
            obj.transform.Find("UI_History_S_Res").GetComponent<Image>().sprite = img_wrong;
        }

        obj.transform.Find("UI_History_S_Money").transform.Find("UI_History_S_Money_Text").GetComponent<Text>().text = money.ToString();
        obj.transform.Find("UI_History_S_Title").GetComponent<Text>().text = name;
    }

}
