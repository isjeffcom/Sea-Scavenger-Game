using UnityEngine;

// Initilized and UI Page Router
// This is for smoothly switch UI with camera animation
// Also because I dont want to learn Unity Scene concept END OF THE STROY
// For F S, Someone should really built a UI framework like Vue.js or React for Game Dev

public class GlobalController : MonoBehaviour
{

    // Instance for cross cs access
    public static GlobalController _ins;

    // Mode 0: Start Screen, 1: Game Play, 2: Pick up item
    public static int _mode = 0;
    public static int _score = 0;
    public static int _paw = 30;
    public static int _load = 78;
    public static int _loadTotal = 300;

    // Cameras
    public Camera mainCamera;
    public Camera pickUpCamera;

    // All UI Array Container
    private GameObject[] All_UI;

    // Objects for hide
    public Transform hint;

    void Awake()
    {
        _ins = this;

    }

    void Start()
    {
        // Global Initial
        // Open main camera
        switchCamera("MainCamera");
        switchUIView("UI_Start", "MainCamera", true, 0);
    }

    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            _load = _load + 1;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            _loadTotal = _loadTotal + 1;
        }
    }

    public void startGame ()
    {
        switchUIView("UI_Driving", "MainCamera", false, 1);
    }

    public void toMainCamera(bool bol)
    {
        mainCamera.enabled = bol;
        pickUpCamera.enabled = !bol;
    }

    public void switchCamera (string name)
    {
        GameObject.Find(name).GetComponent<Camera>().enabled = true;

        Camera[] allCam = Camera.allCameras;

        for(int i = 0; i < allCam.Length; i++)
        {
            if (allCam[i].gameObject.name != name)
            {

                allCam[i].enabled = false;
            }
        }

    }

    public void switchUIView (string pageName, string camName, bool cursor, int mode)
    {
        All_UI = GameObject.FindGameObjectsWithTag("UI_Pages");
        switchCamera(camName);
        switchCursor(cursor);

        foreach (GameObject page in All_UI)
        {
            if(pageName == page.name)
            {
                page.GetComponent<Canvas>().enabled = true;
            } else
            {
                page.GetComponent<Canvas>().enabled = false;
            }
        }

        _mode = mode;

    }

    void switchCursor (bool bol)
    {
        Cursor.visible = bol;
        Cursor.lockState = bol ? CursorLockMode.None :  CursorLockMode.Locked;
    }

}
