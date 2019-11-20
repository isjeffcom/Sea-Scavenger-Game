using UnityEngine;
using UnityEngine.UI;

public class DisplayLoadTotal : MonoBehaviour
{
    private int lastLoadTotal;
    // Start is called before the first frame update
    void Awake()
    {
        lastLoadTotal = GlobalController._loadTotal;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (lastLoadTotal != GlobalController._load)
        {
            lastLoadTotal = GlobalController._loadTotal;
            string final = GlobalController._loadTotal > 100 ? GlobalController._loadTotal.ToString() + ".0" : "0" + GlobalController._loadTotal.ToString() + ".0";
            gameObject.GetComponent<Text>().text = final;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = final;
        }
    }
}
