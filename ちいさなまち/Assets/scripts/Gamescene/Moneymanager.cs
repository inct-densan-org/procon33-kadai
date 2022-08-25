using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Moneymanager : MonoBehaviour
{
    public static int Money;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{Money}"+"‰~";
        if (Input.GetKeyDown(KeyCode.M))
        {
            Getmoney(100);
        }
    }
    public static void Getmoney(int money)
    {
        Money += money;
    }
   
}
