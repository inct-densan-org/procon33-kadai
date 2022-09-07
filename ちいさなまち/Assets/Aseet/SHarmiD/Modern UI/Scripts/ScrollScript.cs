using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{

    Scrollbar Scroll;
    float bar;
    float barbold;
    public GameObject ScrollBold;
    
    void Start()
    {
        Scroll = GetComponent<Scrollbar>();
        
    }

    
    void Update()
    {
        if (Scroll != null)
        {
            bar = Scroll.value;

            barbold = ScrollBold.GetComponent<Image>().fillAmount;

            barbold = bar;

            ScrollBold.GetComponent<Image>().fillAmount = barbold;
        }
    }
}
