using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    // Start is called before the first frame update
    public static DisplayResult _ins;

    private GameObject UI_Res_Text;
    private GameObject UI_Res_Money_Text;
    private GameObject UI_Res_Bg;


    void Awake() {
        _ins = this;
        UI_Res_Text = GameObject.Find("UI_Res_Text");
        UI_Res_Money_Text = GameObject.Find("UI_Res_Money_Text");
        UI_Res_Bg = GameObject.Find("UI_Res_Bg");

    }

    void Start(){
        gameObject.SetActive(false);
    }

    public void showResult(string res, string money) {
        gameObject.SetActive(true);
        StartAni(true);
        
        if(res == "RIGHT")
        {
            UI_Res_Bg.GetComponent<Image>().color = new Color32 (55, 170, 129, 255);
        } else
        {
            UI_Res_Bg.GetComponent<Image>().color = new Color32 (255, 54, 47, 255);
        }

        UI_Res_Text.GetComponent<Text>().text = res;
        UI_Res_Money_Text.GetComponent<Text>().text = money;
        unshowResult();
    }

    void StartAni (bool bol)
    {
        gameObject.GetComponent<Animator>().SetBool("open", bol);
    }

    void unshowResult ()
    {
        StartCoroutine(close(3));
        StartCoroutine(end(6));
    }

    IEnumerator close(int delay)
    {

        // Wait 3 Seconds to show the leaser effect
        yield return new WaitForSeconds(delay);
        StartAni(false);
    }

    IEnumerator end(int delay)
    {

        // Wait 3 Seconds to show the leaser effect
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
