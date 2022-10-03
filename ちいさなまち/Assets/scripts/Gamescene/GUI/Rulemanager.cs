using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulemanager : MonoBehaviour
{
    
    public GameObject Ruledis,menudis;
    private bool ismenu;
    // Update is called once per frame
    void Update()
    {
        if (Menumanager.menuKey == "rule")
        {
            Ruledis.SetActive(true);
        }
    }
    public void OnPushback()
    {
        
        if (ismenu)
        {
            Ruledis.SetActive(false);
            menudis.SetActive(true);
            Menumanager.menuKey = "menu";
            ismenu = false;
        }
        else
        {
            Ruledis.SetActive(false);
            Menumanager.menuKey = null;
        }
    }
    public void OnPushhelp()
    {
        ismenu = true;
        menudis.SetActive(false);
        Menumanager.menuKey = "rule";
    }
}
