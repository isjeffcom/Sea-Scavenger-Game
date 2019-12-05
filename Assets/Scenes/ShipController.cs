using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{

    public static ShipController _ins;

    public float moveSpeed = 30.0f;
    public float rotateSpeed = 0.02f;
    public float cameraSpeed = 5.0f;
    public float topLimit;
    public float bottomLimit;
    public Vector3 aimingOffset = new Vector3(0, 0, -15);

    [Range(0.01f, 1.0f)]
    public float camSmoothFactor = 0.5f;

    public GameObject crashScreen;

    public bool reverseControl = true;


    public Camera mainCamera;
    public Camera miniMapCamera;
    public Transform controlBody;

    private Vector3 velocity = Vector3.zero;

    public static float _moveFB;
    public static float _moveLR;
    public static float _moveTB;

    float rotX;
    float rotY;
    float rotZ;

    private Vector3 cameraPos;

    private Vector3 cameraOffset;

    bool stopMoving = false;

    void Awake()
    {
        _ins = this;
    }

    // Start is called before the first frame update
    public void init()
    {
        cameraOffset = mainCamera.transform.position - transform.position;
        gameObject.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Reset All Value
        _moveFB = 0;
        _moveLR = 0;
        _moveTB = 0;
        rotX = 0;
        rotY = 0;
        rotZ = 0;

        if (stopMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.T))
        {
            GlobalController._ins.resetScene();
        }

        if (GlobalController._mode == 1)
        {
            //Debug.Log(GlobalController._mode);
            // Reset rotation and face forward
            if (Input.GetKey(KeyCode.R))
            {
                ResetRotation(transform);
            }

            shipControl(transform);
            cameraControl(transform);
            aimingControl();
            UpdateMiniMap(miniMapCamera.transform, transform);
        }


    }

    void shipControl(Transform obj)
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift) && transform.rotation.z == 0f)
        {
            return;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            _moveFB = Input.GetAxis("Vertical") * moveSpeed;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            rotX = Input.GetAxis("Horizontal") * rotateSpeed;
            //objRotateTo(transform, new Vector3(transform.rotation.x, transform.rotation.y, 0f), 0.02f);
            /*if (transform.rotation.z >= -0.2f || transform.rotation.z <= 0.2f)
            {
                rotZ = Input.GetAxis("Horizontal") > 0 ? 0.2f : -0.2f;
                rotY = 0f;
            }*/
            
        }


        /*if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            objRotateTo(transform, new Vector3(transform.rotation.x, transform.rotation.y, 0f), 0.02f);
        }*/
        

        if (Input.GetKey(KeyCode.LeftControl) && transform.position.y > bottomLimit)
        {
            _moveTB = -2 * moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift) && transform.position.y < topLimit)
        {
            _moveTB = 2 * moveSpeed;
        }

        Vector3 movement = new Vector3(_moveLR, _moveTB, _moveFB);
        movement = transform.rotation * movement;
        Vector3 movingTarget = transform.position + movement;

        ObjMoveToPosi(obj, movingTarget);

        Vector3 rorateTarget = new Vector3(rotX, rotY, rotZ);
        ObjRotate(obj, rorateTarget, true);
    }

    void cameraControl(Transform obj)
    {

        Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * cameraSpeed, Vector3.up);
        Quaternion camTurnAngleY = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * cameraSpeed, mainCamera.transform.right);

        cameraOffset = camTurnAngleX * camTurnAngleY * cameraOffset;


        Vector3 newPos = transform.position + cameraOffset;
        mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, newPos, camSmoothFactor);

        mainCamera.transform.LookAt(transform);

    }

    void aimingControl ()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 newPos = mainCamera.transform.position - aimingOffset;
            mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, newPos, camSmoothFactor);
        }
    }

    void ObjMoveToPosi(Transform obj, Vector3 target)
    {
        // Main
        obj.position = Vector3.SmoothDamp(
            obj.position,
            target,
            ref velocity,
            2,
            Mathf.Infinity,
            Time.deltaTime
        );
    }

    void ObjRotate(Transform obj, Vector3 val, bool reverse)
    {
        // If reverse control has been selected
        if (reverse)
        {
            obj.Rotate(val.y, val.x, -val.z);
        }
        else
        {
            obj.Rotate(-val.y, val.x, -val.z);
        }
    }

    void objRotateTo(Transform obj, Vector3 val, float smoothFactor)
    {
        Quaternion t = Quaternion.Euler(val);
        obj.rotation = Quaternion.Lerp(obj.rotation, t, smoothFactor);
    }



    void UpdateMiniMap(Transform miniMap, Transform follow)
    {
        // Set Mini Map Camera
        miniMap.position = new Vector3(follow.position.x, miniMap.position.y, follow.position.z);
    }

    void ResetRotation(Transform obj)
    {
        float s = 5.0f;
        Quaternion t = Quaternion.Euler(0, 0, 0);
        obj.rotation = Quaternion.Slerp(obj.rotation, t, Time.deltaTime * s);
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Terrain")
        {
            //resetPos();
        }
    }


    void OnCollisionExit()
    {
        // Do nothing for now
    }

    void resetPos()
    {
        StartCoroutine(onResetPos(1));
    }

    IEnumerator onResetPos(float delay)
    {

        stopMoving = true;
        crashScreen.SetActive(true);
        transform.position = new Vector3(-8, 57, -461);
        transform.rotation = Quaternion.identity;

        yield return new WaitForSeconds(delay);

        crashScreen.SetActive(false);
        stopMoving = false;
    }




}
