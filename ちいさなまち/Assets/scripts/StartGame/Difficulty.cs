using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public GameObject optionButtons;
    public static string difficulty;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void osita()
    {
        if(optionButtons.transform.GetChild(0).GetComponent<Toggle>().isOn == true)
        {
            difficulty = "ez";
        }
        if (optionButtons.transform.GetChild(1).GetComponent<Toggle>().isOn == true)
        {
            difficulty = "nomal";
        }
        if (optionButtons.transform.GetChild(2).GetComponent<Toggle>().isOn == true)
        {
            difficulty = "hard";
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
