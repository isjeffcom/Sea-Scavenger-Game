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
    public static string currentSolution;

    private GameObject item;
    private Vector3 itemOriginalPosi;
    private Quaternion itemOriginalRota;

    private GameObject instanceObj;

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

        // Add script to object copied
        //instanceObj.AddComponent<ViewItem>();

        // Apply Holo Material to instance object
        if (instanceObj.GetComponent<MeshRenderer>())
        {
            instanceObj.GetComponent<Renderer>().material = holoMaterial;
            // Apply new scale value to new shape
            instanceObj.transform.localScale = new Vector3(1, 1, 1);

        } else
        {
            foreach(Transform child in instanceObj.transform)
            {
                if (child.GetComponent<Renderer>())
                {
                    child.GetComponent<Renderer>().material = holoMaterial;
                }

                // Apply new scale value to new shape
                instanceObj.transform.localScale = new Vector3(10, 10, 10);
            }
            
        }
        
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
        GlobalController._ins.switchUIView("UI_Driving", "MainCamera", false, 1);
        ItemViewerController._ins.ExitItemViewer(); 
        Destroy(instanceObj);
    }
}
