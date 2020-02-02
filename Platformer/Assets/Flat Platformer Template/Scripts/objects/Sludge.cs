using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sludge : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("col");
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("art");
        }
    }
}
