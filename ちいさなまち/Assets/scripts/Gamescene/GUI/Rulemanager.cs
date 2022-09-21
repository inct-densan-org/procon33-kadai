using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulemanager : MonoBehaviour
{
    public GameObject Ruledis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        Ruledis.SetActive(false);
        Menumanager.menuKey = null;
    }
}
