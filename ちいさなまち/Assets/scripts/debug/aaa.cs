using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
public class aaa : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField]
    private ItemDataBase itemDataBase;
    private bool a;
   public List<int> shopitemlist = new List<int>(); //intŒ^‚ÌList‚ð’è‹`
    [SerializeField]
    GameObject iconPrefab = null;
    [SerializeField]
    Transform iconParent = null;
    public GameObject buydis,buybutton;
    private GameObject button_ob;
    private string ItemName;
    public TextMeshProUGUI Iteminf,goukei;
    public TMP_InputField inputField;
    private int money,s;

    private void Start()
    {
        inputField = inputField.GetComponent<TMP_InputField>();
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            itemDataBase.GetItemLists()[i].syokika();
            
            if (itemDataBase.GetItemLists()[i].GetKindOfItem().ToString() == "restaurant")
            {
                shopitemlist.Add( i);
            }
        }
        Moneymanager.Money = 10000;
    }
    private void Update()
    {
        money = Moneymanager.Money;
        if (a == false)
        {
            a = true;
            for (int i=0; i < shopitemlist.Count; i++)
            {
                var num = shopitemlist[i];
                GameObject button = Instantiate(iconPrefab, iconParent);
                button.name= itemDataBase.GetItemLists()[num].GetItemName();
                GameObject inf= button. transform.GetChild(0).gameObject;
                inf.GetComponent<TextMeshProUGUI>().text = itemDataBase.GetItemLists()[num].GetItemName();
                GameObject en= button.transform.GetChild(1).gameObject;
                en.GetComponent<TextMeshProUGUI>().text = $"{itemDataBase.GetItemLists()[num].Getmoney()}" + "‰~";
                GameObject icon = button.transform.GetChild(2).gameObject;
                icon.GetComponent<Image>().sprite = itemDataBase.GetItemLists()[num].GetIcon();
                button.GetComponent<Button>().onClick.AddListener(OnPushItem);
            }
           
        }
        
    }
    void OnPushItem()
    {
        buydis.SetActive(true);
        button_ob = eventSystem.currentSelectedGameObject;
        
        ItemName = button_ob.name;
        buybutton.name = ItemName;
        Iteminf.text = $"{GetItem(ItemName).GetItemName()}\n{GetItem(ItemName).GetInformation()}";
        
    }
   public void exitkosuu()
    {
         s = int.Parse(inputField.text);
        goukei.text = $"‡Œv@{GetItem(ItemName).Getmoney() * s}‰~";
    }
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
    public void Onbushback()
    {
        buydis.SetActive(false);
    }
    public void Onpushbuy()
    {
        var totalmoney = GetItem(ItemName).Getmoney() * s;
        button_ob = eventSystem.currentSelectedGameObject;
        ItemName = button_ob.name;
        if (money >= totalmoney && totalmoney != 0)
        {
            Moneymanager.Setmoney(-(totalmoney));
            GetItem(ItemName).Setkosuu(s);
        }
    }
}
