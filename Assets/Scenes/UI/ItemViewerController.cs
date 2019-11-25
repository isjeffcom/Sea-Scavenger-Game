using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewerController : MonoBehaviour
{

    // Instance for cross cs access
    public static ItemViewerController _ins;

    // Save State
    public static int _UI_IV_State = 0;

    private GameObject UI_IV_Contents;
    private GameObject UI_IV_Contents_Cont;
    private GameObject UI_IV_Solutions;
    private GameObject UI_IV_Property;
    private GameObject UI_IV_Next;
    private GameObject UI_IV_PageTitle;
    private GameObject UI_IV_Animated_Bg;
    private GameObject UI_IV_Status;

    private Animator Ani_Solu;
    private Animator Ani_Contents;
    private Animator Ani_Property;
    private Animator Ani_PageTitle;
    private Animator Ani_AnimatedBg;
    private Animator Ani_Contents_Cont;
    private Animator Ani_Status;

    void Awake()
    {
        _ins = this;

        UI_IV_Solutions = GameObject.Find("UI_IV_Solutions");
        UI_IV_Contents = GameObject.Find("UI_IV_Contents");
        UI_IV_Contents_Cont = GameObject.Find("UI_IV_Contents_Cont");
        UI_IV_PageTitle = GameObject.Find("UI_IV_PageTitle");
        UI_IV_Next = GameObject.Find("UI_IV_Next");
        UI_IV_Property = GameObject.Find("UI_IV_Property");
        UI_IV_Animated_Bg = GameObject.Find("UI_Animated_Bg");
        UI_IV_Status = GameObject.Find("UI_IV_Status");

        Ani_Solu = UI_IV_Solutions.GetComponent<Animator>();
        Ani_Contents = UI_IV_Contents.GetComponent<Animator>();
        Ani_Property = UI_IV_Property.GetComponent<Animator>();
        Ani_PageTitle = UI_IV_PageTitle.GetComponent<Animator>();
        Ani_AnimatedBg = UI_IV_Animated_Bg.GetComponent<Animator>();
        Ani_Contents_Cont = UI_IV_Contents_Cont.GetComponent<Animator>();
        Ani_Status = UI_IV_Status.GetComponent<Animator>();
    }


    public void PlayStartAni ()
    {
        Ani_PageTitle.SetBool("open", true);
        Ani_AnimatedBg.SetBool("open", true);
        Ani_Contents_Cont.SetBool("open", true);
        Ani_Status.SetBool("open", true);
    }

    

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            
            if(EventSystem.current.currentSelectedGameObject == UI_IV_Next && _UI_IV_State == 0)
            {
                Debug.Log("ININININNININ");
                // Play Animation
                Ani_Property.SetBool("open", true);
                Ani_Contents.SetBool("open", true);
                Ani_Solu.SetBool("open", true);

                // Set state
                _UI_IV_State = 1;
            }
            
        }
    }
}
