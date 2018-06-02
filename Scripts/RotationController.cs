using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour {

    public CameraController cameraController;

    public float smooth = 50.0f;

    // Update is called once per frame
    public void CameraRotate () {
        /*
         * RATATION
         */

        //transform.rotation = new Vector3(45, 0, 0);

        if (cameraController.tiltAroundY < -30)
        {

            // Dampen towards the target rotation
            //transform.rotation = transform.Rotate(Vector3.right * Time.deltaTime);

        }

        /*
          * RATATION
          * END
          */
    }
}
