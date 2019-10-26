using System.Collections;
using System.Collections.Generic;
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

    public static int score = 0;

    public static ColliderDetector _instance;
    public static string currentSolution;

    // 0: Free world, 1: Pick up item
    public int _mode = 0;

    private GameObject item;
    private Vector3 itemOriginalPosi;
    private Quaternion itemOriginalRota;

    private GameObject instanceObj;

    private Canvas UIItemViewer;
    private Canvas UIDriving;
    private Light obsurbLight;
    
    

    Vector3 offset = new Vector3 (8, 8, -8);

    Vector3 hide = new Vector3 (-1, -1, 1);

    void Awake(){
		_instance = this;
	}
    

    void Start () {
        toMainCamera(true);
        UIItemViewer = UI_ItemViewer.GetComponent<Canvas> ();
        UIDriving = UI_Driving.GetComponent<Canvas> ();
        obsurbLight = IdLeaser.GetComponent<Light> ();

        UIItemViewer.enabled = false;
        hint.position = hide;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {
        if(Input.GetKeyDown(KeyCode.F) && _mode == 1){
            exitViewerMode();
        }
    }

    public void toViewItem (GameObject obj)
    {
        if(_mode == 0)
        {
            StartCoroutine(delayToView(obj, 1));
        }
    }

    IEnumerator delayToView(GameObject obj, int delay)
    {

        // Copy Object
        instanceObj = Instantiate(obj, itemDemoPosition, Quaternion.Euler(new Vector3(0, 0, 0)));

        // Add script to object copied
        instanceObj.AddComponent<ViewItem>();

        // Apply Holo Material to instance object
        instanceObj.GetComponent<Renderer>().material = holoMaterial;

        // Apply new scale value to new shape
        instanceObj.transform.localScale = new Vector3(1, 1, 1);

        // Wait 3 Seconds to show the leaser effect
        yield return new WaitForSeconds(delay);

        enterViewerMode();

    }

    void toMainCamera (bool bol){
        mainCamera.enabled = bol;
        pickUpCamera.enabled = !bol;
    }

    public void enterViewerMode () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Switch Camera
        toMainCamera(false);

        // Set UIItemViewer Is True
        UIItemViewer.enabled = true;
        UIDriving.enabled = false;

        // Set Mode
        _mode = 1;
    }

    public void exitViewerMode () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UIItemViewer.enabled = false;
        UIDriving.enabled = true;

        // Display obsurb light 
        obsurbLight.enabled = false;
        toMainCamera(true);
        Destroy(instanceObj);
        _mode = 0;
    }
}
