using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewerController : MonoBehaviour
{
    private int UI_IV_State = 0;
    private GameObject UI_IV_Content;
    private GameObject UI_IV_Solutions;
    private GameObject UI_IV_Property;
    private GameObject UI_IV_Next;

    private Animator Ani_Solu;
    private Animator Ani_Content;
    private Animator Ani_Property;

    void Awake()
    {
        UI_IV_Solutions = GameObject.Find("UI_IV_Solutions");
        UI_IV_Content = GameObject.Find("UI_IV_Content");
        UI_IV_Next = GameObject.Find("UI_IV_Next");
        UI_IV_Property = GameObject.Find("UI_IV_Property");

        Ani_Solu = UI_IV_Solutions.GetComponent<Animator>();
        Ani_Content = UI_IV_Content.GetComponent<Animator>();
        Ani_Property = UI_IV_Property.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == UI_IV_Next)
        {
            Ani_Property.SetBool("open", true);
            Ani_Content.SetBool("open", true);
            Ani_Solu.SetBool("open", true);
        }
    }
}
