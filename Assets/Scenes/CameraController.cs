using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 1.0f;
    public Vector3 camreaOffset;

    void LateUpdate()
    {   
        // Debug.Log(target.rotation.x);
        /*Debug.Log(target.up * -1.0f);
        //Vector3 offsetReCal = new Vector3 (target.transform.TransformDirection);
        Vector3 desiredPosi = target.position + camreaOffset;
        //Vector3 desiredPosi = new Vector3(Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0);
        Vector3 smoothedPosi = Vector3.Lerp (transform.position, desiredPosi, smoothSpeed);
        
        transform.position = smoothedPosi;

        transform.rotation = target.transform.rotation;*/
        //transform.Rotate (target.rotation.x, target.rotation.y, 0);
        //transform.LookAt(target);
        //transform.Rotate(-Input.GetAxis ("Mouse X"), -Input.GetAxis ("Mouse Y"), 0); 
        
    }
}
