using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopmanager : MonoBehaviour
{
    public GameObject shopmenu;
    public Infection2 Infection2;
    public static bool isshop;
    private bool haninai,a;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        haninai = Infection2.haninai;
        if (haninai&&a==false)
        {
            hyouzi();a = true;
        }
        if(haninai==false)
        {
            a = false;
        }
    }
    void hyouzi()
    {
        
        {
            Debug.Log("dekiteru");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shopmenu.SetActive(true);
                isshop = true;
            }
        }
    }
  
}
