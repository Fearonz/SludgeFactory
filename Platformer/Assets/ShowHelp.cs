using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHelp : MonoBehaviour
{
    public GameObject HelpImage;
    void Start()
    {
        HelpImage.SetActive(false);
    }

    public void ClickForShow()
    {
        if(HelpImage.active == true)
        {
            HelpImage.SetActive(false);
        }
        else
        {
            HelpImage.SetActive(true);
        }
       
    }

    public void Hide()
    {
        HelpImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
