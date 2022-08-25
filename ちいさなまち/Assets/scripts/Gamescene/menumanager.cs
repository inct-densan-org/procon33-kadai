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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ismenu == false)
            {
                
                gezi.SetActive(false);
                menu.SetActive(true);
                ismenu = true;
            }
            else
            {
                
                gezi.SetActive(true);
                menu.SetActive(false);
                ismenu = false;
            }
            
        }

    }
}
