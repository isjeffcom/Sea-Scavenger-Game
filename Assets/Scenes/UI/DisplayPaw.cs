using UnityEngine;
using UnityEngine.UI;

public class DisplayPaw : MonoBehaviour
{
    private int lastPaw;
    // Start is called before the first frame update
    void Awake()
    {
        lastPaw = GlobalController._paw;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (lastPaw != GlobalController._paw)
        {
            lastPaw = GlobalController._paw;
            gameObject.GetComponent<Text>().text = GlobalController._paw.ToString();
            gameObject.transform.GetChild(0).GetComponent<Text>().text = GlobalController._paw.ToString();
        }
    }
}
