using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject mainCamera;

    private Vector3 offset;
    private Vector3 mouse_drag;
    private Vector3 sin_coef;

    public float smooth = 50.0f;
    public float sensitivityX = 1.1f;
    public float sensitivityY = 1.1f;

    //private float tiltLock = -50;

    

    float tiltAroundZ = 270;
    [HideInInspector] public float tiltAroundY = 0;

    public CameraAngleController camAngCont;
    public RotationController camRotCont;

    void Start ()
    {
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate ()
    {

        transform.position = player.transform.position + offset;

        /*
         * ROTATION OF THE CAMERA
         */

        tiltAroundZ += Input.GetAxis("Mouse X") * sensitivityX;
        tiltAroundY -= Input.GetAxis("Mouse Y") * sensitivityY;

        if (tiltAroundY > 25) tiltAroundY = 25;
        if (tiltAroundY < -71) tiltAroundY = -71;

        Quaternion target = Quaternion.Euler( tiltAroundY, tiltAroundZ, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        /*
         * ROTATION OF THE CAMERA
         * END
         */

        // call here for smoother camera flow
        camAngCont.AngleControl();

        camRotCont.CameraRotate();

        Debug.Log("Tilt val: " + tiltAroundY);

    }

}

//https://www.youtube.com/watch?v=MkbovxhwM4I