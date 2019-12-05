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

    // Adjustable value
    public int SpaceLimitTimer = 400;

    // Mode 0: Start Screen, 1: Game Play, 2: Pick up item, 3: Ended, 4: In Game Menu
    public static int _mode = 0;
    public static int _score = 0;
    public static int _paw = 30;
    public static int _load = 78;
    public static int _loadTotal = 300;
    public static int _collected = 0;
    public static int _limitDown;
    public bool _ended = false;
    public int _endCondition = 1;

    // UIs
    private GameObject UI_Warning;
    //private GameObject UI_InGame_Menu;
    private Animator openSceneAni;

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

    // In Game Menu Bool
    private bool inGame = false;

    void Awake()
    {
        _ins = this;
        
        _limitDown = SpaceLimitTimer;
        openSceneAni = GameObject.Find("UI_Game_Ending").GetComponent<Animator>();
        cameraStart = mainCamera.GetComponent<Animator>();
        All_UI = GameObject.FindGameObjectsWithTag("UI_Pages");
        UI_Warning = GameObject.Find("UI_Warning");
        //UI_InGame_Menu = GameObject.Find("UI_InGame_Menu");
        UIStart = GameObject.Find("UI_Start").GetComponent<Animator>();
    }

    void Start()
    {
        // Global Initial
        // Open main camera
        switchCamera("MainCamera");
        switchUIView("UI_Start", "MainCamera", true, 0);
        openSceneAni.SetBool("open", true);
        UI_Warning.SetActive(false);

        // Play Music
        gameObject.GetComponent<AudioSource>().Play();
        //UI_InGame_Menu.SetActive(false);
    }

    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_mode == 1 || _mode == 4)
            {
                inGameMenu();
            }
            
        }
    }

    public void inGameMenu ()
    {
        inGame = !inGame;
        
        if (inGame)
        {
            switchUIView("UI_InGame_Menu", "MainCamera", true, 4);
        } else
        {
            switchUIView("UI_Driving", "MainCamera", false, 1);
        }
    }

    public void startGame ()
    {
        UIStart.SetBool("open", true);
        cameraStart.SetBool("open", true);
        switchCursor(false);
        StartCoroutine(WaitForCamAni(3));
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
        
        switchCamera(camName);

        
        if (_mode != 3)
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

        if (_ended)
        {
            switchCursor(_ended);
        }



        _mode = _ended ? 3 : mode;

    }

    public void CollectItem (string name, string solution, bool res, int money)
    {
        // UI Response
        DisplayHistory._ins.AddHistory(name, solution, res, money);

        if(_collected >= _endCondition)
        {
            Debug.Log(_collected);
            Debug.Log(_endCondition);
            GameEnded();
        } else
        {
            _collected++;
        }

        // Add to the data storage
        //ActionHistories._ins.AddHistory(name, solution, res, money);
    }

    public void hitLimit (bool bol)
    {
        if (bol)
        {
            
            if (_limitDown > 0)
            {
                _limitDown = _limitDown - 1;
            }
            else
            {
                resetScene();
            }
        } else
        {
            _limitDown = SpaceLimitTimer;
        }
        UI_Warning.SetActive(bol);

    }


    void GameEnded ()
    {
        _ended = true;
        DisplayHistory._ins.Ended();
        GameObject.Find("UI_Restart").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.Find("UI_Restart").GetComponent<CanvasGroup>().blocksRaycasts = true;
        switchCursor(true);
    }

    IEnumerator WaitForCloseSceneAni(int delay)
    {
        // Wait 3 Seconds to show the leaser effect
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);

    }

    public void switchCursor (bool bol)
    {
        Cursor.visible = bol;
        Cursor.lockState = bol ? CursorLockMode.None :  CursorLockMode.Locked;
    }

    public void resetScene()
    {
        openSceneAni.SetBool("open", false);
        StartCoroutine(WaitForCloseSceneAni(1));
    }


    public void exitGame()
    {
        Application.Quit();
    }
}
