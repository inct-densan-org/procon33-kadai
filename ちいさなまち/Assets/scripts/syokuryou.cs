using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class syokuryou : MonoBehaviour
{
    public float time = 0;
    private itibyou byou;
    private Image Bar;
    const float MIN = 0;     // 最小値
    const float MAX = 100;   // 最大値
    // Start is called before the first frame update
    void Start()
    {
        GameObject image_object = GameObject.Find("ge-zi");
        Bar = image_object.GetComponent<Image>();
        var byou = gameObject.AddComponent<itibyou>();
        byou.Init(() =>
        {

            time++;
           // Bar.fillAmount = 1 - (time / 100);
        });
        byou.Play();
    }
    private bool K;
    // Update is called once per frame
    void Update()
    {
        time= Mathf.Clamp(time, MIN, MAX);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            time -= 10;
        }
        Bar.fillAmount = 1 - (time / 100);
       // if (time >= 10 )
       // {

            //    byou.Stop();


            // }
    }
}
