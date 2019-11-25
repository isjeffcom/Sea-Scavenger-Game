using UnityEngine;
using UnityEngine.UI;

public class ViewItem : MonoBehaviour {

    Vector3 mPrevPos = Vector3.zero; 
    Vector3 mPosDelta = Vector3.zero;

    private GameObject mObj;
    private GameObject uiTitleCont;
    private GameObject uiContentCont;
    private GameObject objLaser;

    private ItemData data;

    private float rotSpeed = 100;

    void Awake()
    {
        mObj = gameObject;
    }


    void Start () {

        data = mObj.GetComponent<ItemData> ();

        // Set UI Title String
        uiTitleCont = GameObject.Find("UI_IV_Title");
        uiTitleCont.GetComponent<Text> ().text = data.getTitle();

        // Set UI Content String
        uiContentCont = GameObject.Find("UI_IV_Content");
        uiContentCont.GetComponent<Text> ().text = data.getContent();
        
        // Set Solution
        ColliderDetector.currentSolution = data.getSolution();


    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
            if (Vector3.Dot(mObj.transform.up, Vector3.up) >= 0)
            {
                mObj.transform.Rotate(mObj.transform.up, -rotX, Space.World);
            }
            else
            {
                mObj.transform.Rotate(mObj.transform.up, rotX, Space.World);
            }
        }

    }



}
