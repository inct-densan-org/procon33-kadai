using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Moneymanager : MonoBehaviour
{
    public static int Money;
    public TextMeshProUGUI text;
    private bool a;
    // Update is called once per frame
    private void Start()
    {
      
    }
    void Update()
    {
        
        text.text = $"{Money}"+"円";
        if (Input.GetKeyDown(KeyCode.M))
        {
            Setmoney(100);
        }
    }
    public static void Setmoney(int money)
    {
        Money += money;
    }
}
