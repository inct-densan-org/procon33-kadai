using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menumanager : MonoBehaviour
{
    public GameObject menu ,gezi;
    public static bool ismenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var isshop = shopmanager.isshop;
        if (Input.GetKeyDown(KeyCode.Escape)&&isshop==false)
        {
            if (ismenu == false)
            {
                menu.SetActive(true);
                ismenu = true;
            }
            else
            {
                menu.SetActive(false);
                ismenu = false;
            }
        }
    }
}
