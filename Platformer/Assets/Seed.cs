using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public GameObject Plant;
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "fertil")
    //    {
    //        print("enter");
    //    }
    //}
    private void OnDestroy()
    {
        LevelController.instance.canDrop = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fertil")
        {
            Instantiate(Plant,transform.position + new Vector3(0,-0.1f,0),Quaternion.Euler(0,0,0), GameObject.Find("PlantHolder").transform);
            LevelController.instance.isPlant = true;
           
            Destroy(gameObject);
        }
    }
}
