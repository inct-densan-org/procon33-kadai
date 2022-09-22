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
    public List<int> shopitemlist = new List<int>(); //int型のListを定義
    [SerializeField]
    GameObject iconPrefab = null;
    [SerializeField]
    Transform iconParent = null;
    public GameObject buydis, buybutton;
    private GameObject button_ob;
    private string ItemName;
    public TextMeshProUGUI Iteminf, goukei,moneytext;
    public TMP_InputField inputField;
    private int  s;
    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<TMP_InputField>();
        //time = Mathf.Clamp(time, MIN, MAX);
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            itemDataBase.GetItemLists()[i].syokika();
            if (itemDataBase.GetItemLists()[i].GetKindOfItem().ToString() == "restaurant")
            {
                shopitemlist.Add(i);
            }
        }
       
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
                for (int i = 0; i < shopitemlist.Count; i++)
                {
                    var num = shopitemlist[i];
                    GameObject button = Instantiate(iconPrefab, iconParent);
                    button.name = itemDataBase.GetItemLists()[num].GetItemName();
                    GameObject inf = button.transform.GetChild(0).gameObject;
                    inf.GetComponent<TextMeshProUGUI>().text = itemDataBase.GetItemLists()[num].GetItemName();
                    GameObject en = button.transform.GetChild(1).gameObject;
                    en.GetComponent<TextMeshProUGUI>().text = $"{itemDataBase.GetItemLists()[num].Getmoney()}" + "円";
                    GameObject icon = button.transform.GetChild(2).gameObject;
                    icon.GetComponent<Image>().sprite = itemDataBase.GetItemLists()[num].GetIcon();
                    button.GetComponent<Button>().onClick.AddListener(OnPushItem);
                }

            }
        }
    }
    void OnPushItem()
    {
        buydis.SetActive(true);
        button_ob = eventSystem.currentSelectedGameObject;
        s = 0;
        ItemName = button_ob.name;
        buybutton.name = ItemName;
        Iteminf.text = $"{GetItem(ItemName).GetItemName()}\n{GetItem(ItemName).GetInformation()}";
        goukei.text = $"合計　{GetItem(ItemName).Getmoney() * s}円";
    }
    
    public void Onpushbuy()
    {
        var totalmoney = GetItem(ItemName).Getmoney() * s;
        button_ob = eventSystem.currentSelectedGameObject;
        ItemName = button_ob.name;
        if (money < totalmoney) { mesege.text = "所持金が足りません"; Invoke(nameof(mesagedele), 3f); }
        if (totalmoney == 0) { mesege.text = "アイテムを選んでください"; Invoke(nameof(mesagedele), 3f); }
        if (money >= totalmoney && totalmoney != 0)
        {
            Moneymanager.Setmoney(-(totalmoney));
            mesege.text = "購入しました";
            Invoke(nameof(mesagedele), 3f);
            GetItem(ItemName).Setkosuu(s);
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
    }
    public void onpushshopback()
    {
        shopmenu.SetActive(false);
        Menumanager.menuKey = null;
        
    }
    void mesagedele()
    {
        mesege.text = null;
    }
   
}