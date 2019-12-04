using UnityEngine;

public class LimitWall : MonoBehaviour
{
    private Transform main;
    private Material mat; 
    // Start is called before the first frame update
    void Awake()
    {
        main = GameObject.Find("MicroSub_Light").transform;
        mat = gameObject.GetComponent<MeshRenderer>().material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RealSub")
        {
            
        }

    }

    // Fade display limit wall when player approching
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "RealSub")
        {
            
            float dis = GetXDistance(main.transform, transform) - 10;

            if (dis < 100 && dis > 0)
            {
                float revDis = 101 - (dis);
                
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1.0f, revDis / 100));
                
            } else
            {
                
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1.0f, 0f));

            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RealSub")
        {
            gameObject.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1.0f, 0f));
        }
    }

    void wallVisiable (bool bol)
    {

    }

    float GetXDistance (Transform a, Transform b)
    {
        return Mathf.Abs(a.position.x - b.position.x);
    }
}
