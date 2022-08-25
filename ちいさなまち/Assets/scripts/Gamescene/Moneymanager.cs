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
