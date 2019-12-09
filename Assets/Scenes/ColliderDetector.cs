using System.Collections;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public Transform hint;
    public Transform cam;
    public Camera mainCamera;
    public Camera pickUpCamera;
    public Camera miniMapCamera;
    public Vector3 itemDemoPosition;
    public GameObject IdLeaser;

    public GameObject ship;

    public GameObject UI_ItemViewer;
    public GameObject UI_Driving;

    public Material holoMaterial;

    public static ColliderDetector _instance;

    private GameObject item;
    private Vector3 itemOriginalPosi;
    private Quaternion itemOriginalRota;

    private GameObject instanceObj;

    public GameObject insObjRef;

    Vector3 offset = new Vector3 (8, 8, -8);

    //Vector3 hide = new Vector3 (-1, -1, 1);

    void Awake(){
		_instance = this;

    }

    // Delay 0.1f and go to view item (give some time for the instantiate process)
    public void toViewItem (GameObject obj)
    {
        if(GlobalController._mode == 1)
        {
            StartCoroutine(delayToView(obj, 0.1f));
        }
    }

    IEnumerator delayToView(GameObject obj, float delay)
    {

        // Copy Object
        instanceObj = Instantiate(obj, itemDemoPosition, Quaternion.Euler(new Vector3(0, 0, 0)));

        // Auto Resize Object for Camera View
        AutoScaleObject(instanceObj);

        addHoloMat(instanceObj);


        // Wait 3 Seconds to show the leaser effect
        yield return new WaitForSeconds(delay);

        // Enter view mode
        enterViewerMode();

    }

    // All UI Switch action now control by Global controller
    public void enterViewerMode () {
        
        GlobalController._ins.switchUIView("UI_ItemViewer", "PickUpCamera", true, 2);
        ItemViewerController._ins.EnterItemViewer(instanceObj);

    }

    public void exitViewerMode () {
        
        ItemViewerController._ins.ExitItemViewer(); 
        Destroy(instanceObj);
    }

    private void AutoScaleObject(GameObject obj)
    {
        // Get the bounds reference (the size of GO should be the same)
        Bounds refBound = insObjRef.GetComponent<Renderer>().bounds;

        Bounds objBound;
        // Get the GO bounds
        if (obj.GetComponent<Renderer>() != null)
        {
            objBound = obj.GetComponent<Renderer>().bounds;
        }

        else if(obj.transform.Find("obj").gameObject.GetComponent<Renderer>() != null)
        {
            objBound = obj.transform.Find("obj").gameObject.GetComponent<Renderer>().bounds;
        }

        else
        {
            objBound = obj.transform.Find("obj").gameObject.GetComponent<Collider>().bounds;
        }
      

        // Get the difference between the radius (is it smaller or bigger ?)
        float percent = objBound.extents.magnitude / refBound.extents.magnitude;

        // Depending on the percent, adjust the scale
        Vector3 finalScale = obj.transform.localScale * ((percent > 1) ? (1 / percent) : (1 + (1 - percent)));

        obj.transform.localScale = finalScale;
    }

    public void addHoloMat(GameObject obj)
    {
        // Apply Holo Material to instance object
        if (obj.GetComponent<MeshRenderer>())
        {

            obj.GetComponent<Renderer>().material = holoMaterial;

        }
        else
        {
            foreach (Transform child in obj.transform)
            {
                if (child.GetComponent<Renderer>())
                {
                    child.GetComponent<Renderer>().material = holoMaterial;
                }

                else if (child.GetComponent<Light>())
                {
                    child.GetComponent<Light>().enabled = false;
                }
                else
                {
                    addHoloMat(child.gameObject);
                }

            }

        }
    }
}
