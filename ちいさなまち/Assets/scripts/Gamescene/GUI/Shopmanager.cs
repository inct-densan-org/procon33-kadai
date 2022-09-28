using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine.EventSystems;

public class Shopmanager : MonoBehaviourPunCallbacks
{
    public GameObject shopmenu;
   
    // private Sprite sp1, sp2, sp3, sp4;
    public TextMeshProUGUI mesege;
    //public static bool isshop;
    private Menumanager menumanager;
    private bool haninai, a;
    [SerializeField]
    private ItemDataBase itemDataBase;
    private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();
    private int money,totalmoney;
    private Moneymanager Moneymanager;
    private string menuKey;
    [SerializeField] private EventSystem eventSystem;
   
    
    private bool w;
    private List<int> restoranshopitemlist = new List<int>();
    private List<int> hospitalshopitemlist = new List<int>();
    private List<int> drukstoreshopitemlist = new List<int>();
    private List<int> foodstoreshopitemlist = new List<int>();//int型のListを定義
    [SerializeField]
    GameObject iconPrefab = null;
    [SerializeField]
    Transform iconParent = null;
    public GameObject buydis, buybutton,shopdis;
    private GameObject button_ob;
    private string ItemName;
    public TextMeshProUGUI Iteminf, goukei,moneytext;
    public TMP_InputField inputField;
    private Gaugemanager gaugemanager;
    private int  s;
    private Infection2 infection2;
  public  Dictionary<int, GameObject> buttons = new Dictionary<int, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        gaugemanager = this.gameObject.GetComponent<Gaugemanager>();
        inputField = inputField.GetComponent<TMP_InputField>();
        //time = Mathf.Clamp(time, MIN, MAX);
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            
            itemDataBase.GetItemLists()[i].syokika();
            Debug.Log(itemDataBase.GetItemLists()[i].GetKindOfItem().ToString());
            if (itemDataBase.GetItemLists()[i].GetKindOfItem().ToString() == "restaurant")
            {
                restoranshopitemlist.Add(i);
            }
            if (itemDataBase.GetItemLists()[i].GetKindOfItem().ToString() == "hospital")
            {
                hospitalshopitemlist.Add(i);
            }
            if (itemDataBase.GetItemLists()[i].GetKindOfItem().ToString() == "drugstore")
            {
                drukstoreshopitemlist.Add(i);
            }
            if (itemDataBase.GetItemLists()[i].GetKindOfItem().ToString() == "foodstore")
            {
                foodstoreshopitemlist.Add(i);
            }
        }
        

    }
    void iconmake(int num,int i)
    {
        GameObject button = Instantiate(iconPrefab, iconParent);
        button.name = itemDataBase.GetItemLists()[num].GetItemName();
        GameObject inf = button.transform.GetChild(0).gameObject;
        inf.GetComponent<TextMeshProUGUI>().text = itemDataBase.GetItemLists()[num].GetItemName();
        GameObject en = button.transform.GetChild(1).gameObject;
        en.GetComponent<TextMeshProUGUI>().text = $"{itemDataBase.GetItemLists()[num].Getmoney()}" + "円";
        GameObject icon = button.transform.GetChild(3).gameObject;
        icon.GetComponent<Image>().sprite = itemDataBase.GetItemLists()[num].GetIcon();
        button.GetComponent<Button>().onClick.AddListener(OnPushItem);
        buttons.Add(i, button);
    }
    // Update is called once per frame
    void Update()
    {
        menuKey = Menumanager.menuKey;

        money = Moneymanager.Money;
        if (menuKey=="shop")
        {
            shopmenu.SetActive(true);
            moneytext.text = $"{money}円";
            if (a == false)
            {
                a = true;
                for (int i = 0; i < restoranshopitemlist.Count; i++)
                {
                    var num = restoranshopitemlist[i];
                    iconmake(num, i);
                }
            }
        }
        if(menuKey== "hospitalshop")
        {
            shopmenu.SetActive(true);
            moneytext.text = $"{money}円";
            if (a == false)
            {
                a = true;
                for (int i = 0; i < hospitalshopitemlist.Count; i++)
                {
                    var num = hospitalshopitemlist[i];
                    iconmake(num, i);
                }
            }
        }
        if (menuKey == "foodstore")
        {
            shopmenu.SetActive(true);
            moneytext.text = $"{money}円";
            if (a == false)
            {
                a = true;
                for (int i = 0; i < foodstoreshopitemlist.Count; i++)
                {
                    var num = foodstoreshopitemlist[i];
                    iconmake(num, i);
                }
            }
        }
        if (menuKey == "durkstore")
        {
            shopmenu.SetActive(true);
            moneytext.text = $"{money}円";
            if (a == false)
            {
                a = true;
                for (int i = 0; i < drukstoreshopitemlist.Count; i++)
                {
                    var num = drukstoreshopitemlist[i];
                    iconmake(num, i);
                }
            }
        }
    }
    void OnPushItem()
    {
        buydis.SetActive(true);
        shopdis.SetActive(false);
        button_ob = eventSystem.currentSelectedGameObject;
        s = 0;
        inputField.text = "0";
        ItemName = button_ob.name;
        buybutton.name = ItemName;
        var buytext = buybutton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        if(GetItem(ItemName).GetKindOfItem().ToString()== "restaurant")
        {
            buytext.text = "注文する";
        }
        else
        {
            buytext.text = "購入";
        }
        Iteminf.text = $"{GetItem(ItemName).GetItemName()}\n{GetItem(ItemName).GetInformation()}";
        goukei.text = $"合計　{GetItem(ItemName).Getmoney() * s}円";
    }
    
    public void Onpushbuy()
    {
        infection2 = GameObject.FindGameObjectsWithTag("Player")[0].gameObject.GetComponent<Infection2>();
        var totalmoney = GetItem(ItemName).Getmoney() * s;
        button_ob = eventSystem.currentSelectedGameObject;
        ItemName = button_ob.name;
        if (money < totalmoney) { mesege.text = "所持金が足りません"; Invoke(nameof(mesagedele), 3f); }
        if (totalmoney == 0) { mesege.text = "アイテムを選んでください"; Invoke(nameof(mesagedele), 3f); }
        if (money >= totalmoney && totalmoney != 0)
        {
            Moneymanager.Setmoney(-(totalmoney));
            if(GetItem(ItemName).GetKindOfItem().ToString()== "restaurant"&&!infection2.GetPlayerinfeffect(PhotonNetwork.LocalPlayer.ActorNumber))
            {
                mesege.text = "食べました";
                Invoke(nameof(mesagedele), 3f);
                gaugemanager.Setfood(GetItem(ItemName).Getfoodrecovery());
                gaugemanager.SetWater(GetItem(ItemName).Getwaterrecovery());
            }
           else if (GetItem(ItemName).GetKindOfItem().ToString() == "restaurant" && infection2.GetPlayerinfeffect(PhotonNetwork.LocalPlayer.ActorNumber))
            {
                var a = menumanager.KANPOU;
                if (a)
                {
                    mesege.text = "食べました";
                    Invoke(nameof(mesagedele), 3f);
                    gaugemanager.Setfood(GetItem(ItemName).Getfoodrecovery());
                    gaugemanager.SetWater(GetItem(ItemName).Getwaterrecovery());
                }
                else
                {
                    mesege.text = "感染しているため食べる事が出来ません。";
                    Invoke(nameof(mesagedele), 3f);
                }
                
            }
            else
            {
                mesege.text = "購入しました";
                Invoke(nameof(mesagedele), 3f);
                GetItem(ItemName).Setkosuu(s);
            }
            
        }
    }
    public void exitkosuu()
    {
        s = int.Parse(inputField.text);
        goukei.text = $"合計　{GetItem(ItemName).Getmoney() * s}円";
    }
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
    public void Onbushback()
    {
        buydis.SetActive(false);
        mesege.text = null;
        shopdis.SetActive(true);
    }
    public void onpushshopback()
    {
        a = false;
        shopmenu.SetActive(false);
        Menumanager.menuKey = null;
        var d = buttons.Count;
        for(int i=0; i < d; i++)
        {
            GameObject icon = buttons[i];
            // アイテムのアイコンを削除
            Destroy(icon);
            // アイコンのディクショナリから対象のアイテムを削除
            buttons.Remove(i);
        }
    }
    void mesagedele()
    {
        mesege.text = null;
    }
   
}