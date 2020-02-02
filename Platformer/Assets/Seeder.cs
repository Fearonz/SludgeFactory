using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeder : MonoBehaviour
{
    public GameObject seed;

    public bool canDrop = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.instance.canDrop)
        {
            if (Input.GetKeyDown("g")&& !LevelController.instance.isPlant){
               GameObject temp= Instantiate(seed, transform.position, Quaternion.Euler(0, 0, 0), transform);

                temp.GetComponent<Rigidbody2D>().velocity = new Vector3(2, 1, 0);
                LevelController.instance.canDrop = false;

            }
        }
    }
}
