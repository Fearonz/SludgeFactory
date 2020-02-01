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
        if (canDrop)
        {
            if (Input.GetKeyDown("g")&& !LevelController.instance.isPlant){
                Instantiate(seed, transform.position, Quaternion.Euler(0, 0, 0), transform);
            }
        }
    }
}
