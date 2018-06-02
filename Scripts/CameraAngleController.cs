using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleController : MonoBehaviour
{
    public CameraController cameraController;

    //public RaycastHit hit; // collision detection ray
    float cameraDistance = Mathf.Sqrt(7 * 7 / 2);// distance of the camera from the character
    
    bool rayHit = false;

    // Bit shift the index of the layer (8) to get a bit mask


    float clip_value = 0.3f; // how far the 4 rays are spread from the centre

    Vector3 cam_offset = new Vector3(0, 7, -7);

    RaycastHit hit;

    int layerMask;

    public void AngleControl()
    {

        /*
         * CLIPPING AND OBSTRUCTION OF THE CAMERA
         */

        

        cam_offset = new Vector3(0, 7, -7);
        
        // is set to true if a ray hits an object


        // Does the ray intersect any objects excluding the player layer
        CheckHit(0, 0, 0); //cast ray from centre

        CheckHit(clip_value, 0, clip_value);
        CheckHit(clip_value, 0, -clip_value);
        CheckHit(-clip_value, 0, clip_value);
        CheckHit(-clip_value, 0, -clip_value);
        CheckHit(0, clip_value, -clip_value);
        CheckHit(0, clip_value, clip_value);
        CheckHit(0, -clip_value, -clip_value);
        CheckHit(0, -clip_value, clip_value);


        layerMask = 1 << 8;
        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        if (rayHit) {
            cameraDistance = 7;
        }
        else
        { 

            //DEBUG INFO & RAYS
            /*
            Debug.DrawRay(transform.position, transform.rotation * cam_offset, Color.white);
            Debug.DrawRay(transform.position + new Vector3(clip_value, 0, clip_value), transform.rotation * cam_offset, Color.red);
            Debug.DrawRay(transform.position + new Vector3(clip_value, 0, -clip_value), transform.rotation * cam_offset, Color.green);
            Debug.DrawRay(transform.position + new Vector3(-clip_value, 0, clip_value), transform.rotation * cam_offset, Color.black);
            Debug.DrawRay(transform.position + new Vector3(-clip_value, 0, -clip_value), transform.rotation * cam_offset, Color.cyan);
            Debug.Log("Did not Hit");
            */

            if (cameraDistance < 7)
                cameraDistance += Time.deltaTime * 25;
            if (cameraDistance > 7)
                cameraDistance = 7;
            cameraController.mainCamera.transform.localPosition = new Vector3(0, cameraDistance, -cameraDistance);
            
        }
        
        // reset ray cast hit
        rayHit = false;

        /*
         * CLIPPING AND OBSTRUCTION OF THE CAMERA
         * END
         */
        


    }

    void CheckHit(float x, float y, float z)
    {
        if (Physics.Raycast(transform.position + new Vector3(x, y, z), transform.rotation * cam_offset, out hit, 10, layerMask, QueryTriggerInteraction.Ignore)) { 
            RayHitEvent(transform.position, hit);
            rayHit = true;
        }

    }

    void RayHitEvent(Vector3 pos, RaycastHit hit)
    {
        //DEBUG INFO & RAYS
        /*
        Debug.DrawRay(pos, hit.point - pos, Color.yellow);
        Debug.DrawRay(transform.position, hit.point - pos, Color.black);
        Debug.DrawRay(transform.position, hit.point - transform.position, Color.red);
        //Debug.Log("Hit: " + (hit.point - pos));
        //Debug.Log("Hit point true: " + (hit.point));
        //*/

        //transform.position = hit.point - transform.position;
        //mainCamera.transform.localPosition = hit.point - mainCamera.transform.position;

        //if(hit.transform.gameObject.tag == "Gound") { 

            float dist = Vector3.Distance(transform.position, hit.point);

            if (Mathf.Sqrt(dist * dist / 2) < cameraDistance)
                cameraDistance = Mathf.Sqrt(dist * dist / 2);

            cameraController.mainCamera.transform.localPosition = new Vector3(0, cameraDistance, -cameraDistance);

        //}
    }
}
