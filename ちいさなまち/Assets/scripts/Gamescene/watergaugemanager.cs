using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watergaugemanager : MonoBehaviour
{
    public static float watertime = 0;
    private itibyou byou;
    private Image Bar;
    const float MIN = 0;     // �ŏ��l
    const float MAX = 100;   // �ő�l
    // Start is called before the first frame update
    void Start()
    {
        GameObject image_object = GameObject.Find("watergauge");
        Bar = image_object.GetComponent<Image>();
        var byou = gameObject.AddComponent<itibyou>();
        byou.Init(() =>
        {
            watertime++;
            // Bar.fillAmount = 1 - (time / 100);
        });
        byou.Play();
    }
    private bool K;
    // Update is called once per frame
    void Update()
    {
        watertime = Mathf.Clamp(watertime, MIN, MAX);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            watertime -= 10;
        }
        Bar.fillAmount = 1 - (watertime / 100);
        // if (time >= 10 )
        // {
        //    byou.Stop();
        // }
    }
    public  static void Setwater(int value)
    {
        watertime -= value;
    }
}

