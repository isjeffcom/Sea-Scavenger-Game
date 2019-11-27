using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Initilized and UI Page Router
// This is for smoothly switch UI with camera animation
// Also because I dont want to learn Unity Scene concept END OF THE STROY
// For F S, Someone should really built a UI framework like Vue.js or React for Game Dev

public class GlobalController : MonoBehaviour
{

    // Instance for cross cs access
    public static GlobalController _ins;

    // Mode 0: Start Screen, 1: Game Play, 2: Pick up item, 3: Ended
    public static int _mode = 0;
    public static int _score = 0;
    public static int _paw = 30;
    public static int _load = 78;
    public static int _loadTotal = 300;
    public static int _collected = 0;

    // Cameras
    public Camera mainCamera;
    public Camera pickUpCamera;

    // Start Ani
    private Animator cameraStart;
    private Animator UIStart;

    // All UI Array Container
    private GameObject[] All_UI;

    // Objects for hide
    public Transform hint;

    void Awake()
    {
        _ins = this;
        cameraStart = mainCamera.GetComponent<Animator>();
        UIStart = GameObject.Find("UI_Start").GetComponent<Animator>();
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
        UIStart.SetBool("open", true);
        cameraStart.SetBool("open", true);
        StartCoroutine(WaitForCamAni(2));
    }

    IEnumerator WaitForCamAni(int delay)
    {
        // Wait 3 Seconds to show the leaser effect
        yield return new WaitForSeconds(delay);
        mainCamera.GetComponent<Animator>().enabled = false;
        mainCamera.transform.position = new Vector3(0, 72, -670);
        mainCamera.transform.rotation = Quaternion.Euler(12, 0, 0);
        ShipController._ins.init();
        switchUIView("UI_Driving", "MainCamera", false, 1);
        DisplayHistory._ins.init();
        
        


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
        if(_mode != 3)
        {
            switchCursor(cursor);
        }
        

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

    public void CollectItem (string name, string solution, bool res, int money)
    {
        // UI Response
        DisplayHistory._ins.AddHistory(name, solution, res, money);

        if(_collected >= 1)
        {
            GameEneded();
        } else
        {
            _collected++;
        }

        // Add to the data storage
        //ActionHistories._ins.AddHistory(name, solution, res, money);
    }

    void GameEneded ()
    {
        _mode = 3;
        DisplayHistory._ins.Ended();
        GameObject.Find("UI_Restart").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.Find("UI_Restart").GetComponent<CanvasGroup>().blocksRaycasts = true;
        switchCursor(true);
    }

    public void resetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void switchCursor (bool bol)
    {
        Cursor.visible = bol;
        Cursor.lockState = bol ? CursorLockMode.None :  CursorLockMode.Locked;
    }

}
