using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionController : MonoBehaviour {

    
    public PlayerController player;


    /*
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.onGround = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.onGround = false;
        }
    }
    */

    private void Update()
    {
        transform.localPosition = player.transform.position;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
            player.onGround = true;

        //Debug.Log("In collider");
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
            player.onGround = false;
            
        //Debug.Log("Left collider");
    }

}
