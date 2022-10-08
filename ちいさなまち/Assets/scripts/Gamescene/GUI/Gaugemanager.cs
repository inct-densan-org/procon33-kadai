using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Threading.Tasks;

public class Gaugemanager : MonoBehaviourPunCallbacks
{
    public int foodgauge, watergauge;
    public GameObject tate, yoko;
    public float foodtime,watertime = 0;
    private itibyou byou;
    public Image foodBar,waterBar,foodtate,watertate;
    const float MIN = 0;     // �ŏ��l
    const float MAX = 100;   // �ő�l
    private NoticeManager noticeManager;
    private bool a, b;
    // Start is called before the first frame update
    void Start()
    {
        itibyou();
        noticeManager = this.gameObject.GetComponent<NoticeManager>();
        
    }
    async void itibyou()
    {
      
        watertime++;
        foodtime++;
      
        await Task.Delay(1200);
        itibyou();
    }
    private bool K;
    // Update is called once per frame
    void Update()//water x -255 y 216 food x -255 260
    {
        if(Menumanager.menuKey=="menu"|| Menumanager.menuKey == "shop" || Menumanager.menuKey == "hospitalshop" || Menumanager.menuKey == "durkstore" || Menumanager.menuKey == "foodstore" || Menumanager.menuKey == "quest" || Menumanager.menuKey == "hotel" || Menumanager.menuKey == "Setting" || Menumanager.menuKey == "playerlist")
        {
            tate.SetActive(true);
            yoko.SetActive(false);
        }
        else
        {
            tate.SetActive(false);
            yoko.SetActive(true);
        }
        foodtime = Mathf.Clamp(foodtime, MIN, foodgauge);
        watertime = Mathf.Clamp(watertime, MIN, watergauge);
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
        foodBar.fillAmount = 1 - (foodtime / foodgauge);
        waterBar.fillAmount = 1 - (watertime / watergauge);
       foodtate.fillAmount = 1 - (foodtime / foodgauge);
        watertate.fillAmount = 1 - (watertime / watergauge);

        if (foodtime == foodgauge-10 && a == false)
        {
            a = true;
            noticeManager.Notice($"{PhotonNetwork.LocalPlayer.NickName}が脱水症状で逝きそうだ");
        }
        if (foodtime != foodgauge - 10 && a == true) a = false;
        if (watertime == watergauge - 10 && b == false)
        {
            b = true;
            noticeManager.Notice($"{PhotonNetwork.LocalPlayer.NickName}が餓死しそうだ");
        }
        if (watertime != watergauge - 10 && b == true) b= false;
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
