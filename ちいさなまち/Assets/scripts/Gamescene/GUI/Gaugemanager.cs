using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Threading.Tasks;

public class Gaugemanager : MonoBehaviourPunCallbacks
{
    
    public float foodtime,watertime = 0;
    private itibyou byou;
    private Image foodBar,waterBar;
    const float MIN = 0;     // �ŏ��l
    const float MAX = 100;   // �ő�l
    private NoticeManager noticeManager;
    private bool a, b;
    // Start is called before the first frame update
    void Start()
    {
        itibyou();
        noticeManager = this.gameObject.GetComponent<NoticeManager>();
        GameObject foodimage_object = GameObject.Find("ge-zi");
        foodBar = foodimage_object.GetComponent<Image>();
        GameObject waterimage_object = GameObject.Find("watergauge");
        waterBar = waterimage_object.GetComponent<Image>();
       
    }
    async void itibyou()
    {
      
        watertime++;
        foodtime++;
      
        await Task.Delay(1000);
        itibyou();
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            foodtime += 10;
            watertime += 10;
        }
        foodBar.fillAmount = 1 - (foodtime / 200);
        waterBar.fillAmount = 1 - (watertime / 150);
       
       
        if (foodtime == 190 && a == false)
        {
            a = true;
            noticeManager.Notice($"{PhotonNetwork.LocalPlayer.NickName}が脱水症状で逝きそうだ");
        }
        if (foodtime != 190 && a == true) a = false;
        if (watertime == 140 && b == false)
        {
            b = true;
            noticeManager.Notice($"{PhotonNetwork.LocalPlayer.NickName}が餓死しそうだ");
        }
        if (watertime != 140 && b == true) b= false;
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
