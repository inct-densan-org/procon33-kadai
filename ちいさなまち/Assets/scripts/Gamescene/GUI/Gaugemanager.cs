using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaugemanager : MonoBehaviour
{
    
    public float foodtime,watertime = 0;
    private itibyou byou;
    private Image foodBar,waterBar;
    const float MIN = 0;     // �ŏ��l
    const float MAX = 100;   // �ő�l
    // Start is called before the first frame update
    void Start()
    {
        GameObject foodimage_object = GameObject.Find("ge-zi");
        foodBar = foodimage_object.GetComponent<Image>();
        GameObject waterimage_object = GameObject.Find("watergauge");
        waterBar = waterimage_object.GetComponent<Image>();
        var byou = gameObject.AddComponent<itibyou>();
        byou.Init(() =>
        {
            watertime++;
            foodtime++;
            // Bar.fillAmount = 1 - (time / 100);
        });
        byou.Play();
    }
    private bool K;
    // Update is called once per frame
    void Update()
    {
        foodtime = Mathf.Clamp(foodtime, MIN, MAX);
        watertime = Mathf.Clamp(watertime, MIN, MAX);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foodtime -= 10;
            watertime -= 10;
        }
        foodBar.fillAmount = 1 - (foodtime / 100);
        waterBar.fillAmount = 1 - (watertime / 100);
        // if (time >= 10 )
        // {
        //      byou.Stop();
        // }
    }
    public void Setfood(int value)
    {
        foodtime -= value;
        
    }
    public void SetWater(int value)
    {
        watertime -= value;

    }
}
