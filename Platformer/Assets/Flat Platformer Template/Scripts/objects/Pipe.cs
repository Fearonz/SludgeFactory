using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("pipe-snap"))
        {
            GameObject pipe = GameObject.Find("pipe");
            if (pipe)
            {
                Destroy(pipe.GetComponent<HingeJoint2D>());
                Destroy(pipe.GetComponent<Rigidbody2D>());
            }

            GameObject holder = GameObject.Find("pipe-holder");
            if (holder)
            {
                Destroy(holder);
            }
        }
    }
}
