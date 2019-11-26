using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResult : MonoBehaviour
{
    // Start is called before the first frame update
    public static DisplayResult _ins;

    private GameObject UI_Res_Text;
    private GameObject UI_Res_Money_Text;

    void Awake() {
        _ins = this;
        UI_Res_Text = GameObject.Find("UI_Res_Text");
        UI_Res_Money_Text = GameObject.Find("UI_Res_Money_Text");

    }

    void Start(){
        gameObject.SetActive(false);
    }

    public void showResult(string res, string money) {
        gameObject.SetActive(true);
        StartAni(true);
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
