using UnityEngine;
using UnityEngine.UI;

public class DisplayDir : MonoBehaviour
{

    private int lastFBState;
    // Start is called before the first frame update
    void Start()
    {
        lastFBState = ShipController._moveFB >= 0 ? 1 : 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int fbState = ShipController._moveFB >= 0 ? 1 : 0;
        if (fbState != lastFBState)
        {
            gameObject.GetComponent<Text>().text = fbState == 1 ? "F" : "R";
            lastFBState = fbState;
        }
    }
}
