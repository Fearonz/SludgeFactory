using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("tetet");
        GameObject sludge = GameObject.Find("sludge-3");
        if (sludge)
        {
            Destroy(sludge);
        }
    }
}
