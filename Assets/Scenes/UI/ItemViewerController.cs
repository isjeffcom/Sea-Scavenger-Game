using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemViewerController : MonoBehaviour
{

    // Instance for cross cs access
    public static ItemViewerController _ins;
    public static string itemName;
    public static string itemSolution;

    // Save State
    public static int _UI_IV_State = 0;
    private bool loaclState = false;

    // Rotation Speed
    private float rotSpeed = 160;

    // Data Container
    private ItemData data;

    // UI Container Static
    private GameObject UI_IV_All_Bg;
    private GameObject UI_IV_Contents;
    private GameObject UI_IV_Contents_Cont;
    private GameObject UI_IV_Solutions;
    private GameObject UI_IV_Property;
    private GameObject UI_IV_P_Cont;
    private GameObject UI_IV_Next;
    private GameObject UI_IV_PageTitle;
    private GameObject UI_IV_Animated_Bg;
    private GameObject UI_IV_Status;

    // UI Text Dynamic
    private GameObject UI_IV_PageTitle_Main;
    private GameObject UI_IV_PageTitle_Sub;

    private GameObject UI_IV_Title;
    private GameObject UI_IV_Content;
    private GameObject UI_IV_MAT;
    private GameObject UI_IV_YEAR;
    private GameObject UI_IV_LETH;

    // UI Animator Controller
    private Animator Ani_All_Bg;
    private Animator Ani_Solu;
    private Animator Ani_Contents;
    private Animator Ani_Property;
    private Animator Ani_Property_Enter;
    private Animator Ani_PageTitle;
    private Animator Ani_AnimatedBg;
    private Animator Ani_Contents_Cont;
    private Animator Ani_Status;
    


    private float ObjAniCounter = 0f;
    private GameObject CObject;

    void Awake()
    {
        _ins = this;

        // Get UI Element Refs
        UI_IV_All_Bg = GameObject.Find("UI_IV_All_Bg");
        UI_IV_Solutions = GameObject.Find("UI_IV_Solutions");
        UI_IV_Contents = GameObject.Find("UI_IV_Contents");
        UI_IV_Contents_Cont = GameObject.Find("UI_IV_Contents_Cont");
        UI_IV_PageTitle = GameObject.Find("UI_IV_PageTitle");
        UI_IV_Next = GameObject.Find("UI_IV_Next");
        UI_IV_Property = GameObject.Find("UI_IV_Property");
        UI_IV_P_Cont = GameObject.Find("UI_IV_P_Cont");
        UI_IV_Animated_Bg = GameObject.Find("UI_Animated_Bg");
        UI_IV_Status = GameObject.Find("UI_IV_Status");

        UI_IV_PageTitle_Main = GameObject.Find("UI_IV_PageTitle_Main");
        UI_IV_PageTitle_Sub = GameObject.Find("UI_IV_PageTitle_Sub");
        UI_IV_Title = GameObject.Find("UI_IV_Title");
        UI_IV_Content = GameObject.Find("UI_IV_Content");
        UI_IV_MAT = GameObject.Find("UI_IV_P_MAT");
        UI_IV_YEAR = GameObject.Find("UI_IV_P_YEAR");
        UI_IV_LETH = GameObject.Find("UI_IV_P_LETH");

        // Get Animator Refs
        Ani_All_Bg = UI_IV_All_Bg.GetComponent<Animator>();
        Ani_Solu = UI_IV_Solutions.GetComponent<Animator>();
        Ani_Contents = UI_IV_Contents.GetComponent<Animator>();
        Ani_Property = UI_IV_Property.GetComponent<Animator>();
        Ani_Property_Enter = UI_IV_P_Cont.GetComponent<Animator>();
        Ani_PageTitle = UI_IV_PageTitle.GetComponent<Animator>();
        Ani_AnimatedBg = UI_IV_Animated_Bg.GetComponent<Animator>();
        Ani_Contents_Cont = UI_IV_Contents_Cont.GetComponent<Animator>();
        Ani_Status = UI_IV_Status.GetComponent<Animator>();
    }


    public void StartAni (bool bol)
    {
        Ani_All_Bg.SetBool("open", bol);
        Ani_PageTitle.SetBool("open", bol);
        Ani_AnimatedBg.SetBool("open", bol);
        Ani_Contents_Cont.SetBool("open", bol);
        Ani_Status.SetBool("open", bol);
        Ani_Property_Enter.SetBool("open", bol);

    }

    public void EnterItemViewer(GameObject obj)
    {
        // Unlock Update
        loaclState = true;

        // Get Instant Object
        CObject = obj;

        // Get Data Class From Object
        data = obj.GetComponent<ItemData>();

        // Play Animation
        StartAni(true);

        //toState(0);
        itemName = data.getTitle();
        itemSolution = data.getSolution();

        // Set UI Text
        UI_IV_Title.GetComponent<Text>().text = data.getTitle();
        UI_IV_Content.GetComponent<Text>().text = data.getContent();

        UI_IV_MAT.GetComponent<Text>().text = data.getMaterial();
        UI_IV_YEAR.GetComponent<Text>().text = data.getPubYear();
        UI_IV_LETH.GetComponent<Text>().text = data.getLethal();

    }

    public void ExitItemViewer ()
    {
        StartAni(false);
        toState(0);
        _UI_IV_State = 0;
        loaclState = false;
        CObject = null;
        itemName = null;
        itemSolution = null;
        StartCoroutine(ExitItemViewerDelay(1));
        
    }

    IEnumerator ExitItemViewerDelay(int delay)
    {

        yield return new WaitForSeconds(delay);
        GlobalController._ins.switchUIView("UI_Driving", "MainCamera", false, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if(CObject == null || !loaclState)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {

            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            if (Vector3.Dot(CObject.transform.up, Vector3.up) >= 0)
            {
                CObject.transform.Rotate(CObject.transform.up, -rotX, Space.World);
            }
            else
            {
                CObject.transform.Rotate(CObject.transform.up, rotX, Space.World);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (EventSystem.current.currentSelectedGameObject == UI_IV_Next && _UI_IV_State == 0)
            {
                toState(1);
                // 3D Object Animation
                moveCObj(1);
            }

        }

        

    }

    void toState (int state)
    {
        bool aniBool = state == 1 ? true : false;
        string titleMain = state == 1 ? "SELECT SOLUTIONS" : "ITEM";
        string titleSub = state == 1 ? "PRIMARY MISSION / SELECT SOLUTIONS" : "PRIMARY MISSION / VIEW ITEM DETAILS";

        // Play Animation
        
        Ani_Property.SetBool("open", aniBool);
        Ani_Contents.SetBool("open", aniBool);
        Ani_Solu.SetBool("open", aniBool);

        // Set Page Title
        UI_IV_PageTitle_Main.GetComponent<Text>().text = titleMain;
        UI_IV_PageTitle_Sub.GetComponent<Text>().text = titleSub;

        // Set state
        _UI_IV_State = state;
    }

    void moveCObj (int state)
   
    {

        if(CObject == null)
        {
            return;
        }

        Vector3 newPosi;

        if(state == 1)
        {
            newPosi = new Vector3(CObject.transform.position.x + 0.1f, CObject.transform.position.y, CObject.transform.position.z);
        } else
        {
            newPosi = new Vector3(CObject.transform.position.x - 0.1f, CObject.transform.position.y, CObject.transform.position.z);
        }

        if (ObjAniCounter < 3.3f)
        {
            
            CObject.transform.position = newPosi;
            ObjAniCounter = ObjAniCounter + 0.1f;
            moveCObj(state);
        } else
        {
            ObjAniCounter = 0f;
        }
        
        
    }
}
