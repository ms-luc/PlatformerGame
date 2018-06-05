using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update () {

        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.right * Time.deltaTime * 25);

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player entered checkpoint");
            material.color = Color.blue;
        }
    }
}
