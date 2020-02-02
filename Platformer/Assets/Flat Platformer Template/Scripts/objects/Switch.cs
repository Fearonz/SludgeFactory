using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public Sprite closedSprite;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject sludge = GameObject.Find("sludge-3");
        if (sludge)
        {
            GetComponent<SpriteRenderer>().sprite = closedSprite;
            Destroy(sludge);
        }
    }
}
