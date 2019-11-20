using UnityEngine;
using UnityEngine.UI;

public class S_Btn_Text : MonoBehaviour
{
    private Text text;
    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }

    public void hover()
    {
        text.color = Color.black;
    }

    public void leave()
    {

        text.color = new Color(6f/255f, 240f/255f, 1f);
    }
}
