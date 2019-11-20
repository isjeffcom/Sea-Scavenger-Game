using UnityEngine;
using UnityEngine.UI;

public class DisplayLoad : MonoBehaviour
{
    private int lastLoad;
    // Start is called before the first frame update
    void Awake()
    {
        lastLoad = GlobalController._load;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (lastLoad != GlobalController._load)
        {
            lastLoad = GlobalController._load;
            string final = GlobalController._load > 100 ? GlobalController._load.ToString() + ".0" : "0" + GlobalController._load.ToString() + ".0";
            gameObject.GetComponent<Text>().text = final;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = final;
        }
    }
}
