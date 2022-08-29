using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class Menumanager : MonoBehaviour
{
    public GameObject menu ,messegedis;
     public static string menuKey;
    public TextMeshProUGUI k1,k2,k3,k4,mesasege,warning;
    public Image icon1,icon2,icon3,icon4;
    [SerializeField] private ItemDataBase itemDataBase;
    public string menuKeysee;
    private string ItemName;
    private Infection2 infection2;
    private Watergaugemanager watergaugemanager;
    private Foodgaugemanager foodgaugemanager;
    private Move move;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        menuKeysee = menuKey;
        if (menuKey=="menu")
        {
            icon1.sprite = itemDataBase.GetItemLists()[0].GetIcon();
            icon2.sprite = itemDataBase.GetItemLists()[1].GetIcon();
            icon3.sprite = itemDataBase.GetItemLists()[2].GetIcon();
            icon4.sprite = itemDataBase.GetItemLists()[3].GetIcon();
            k1.text = $"{itemDataBase.GetItemLists()[0].Getkosuu()}";
            k2.text = $"{itemDataBase.GetItemLists()[1].Getkosuu()}";
            k3.text = $"{itemDataBase.GetItemLists()[2].Getkosuu()}";
            k4.text = $"{itemDataBase.GetItemLists()[3].Getkosuu()}";
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
           
            switch (menuKey)
            {
                case "menu":
                    menu.SetActive(false);
                       menuKey = null;
                    break;
                case null:
                    menu.SetActive(true);
                    menuKey = "menu";
                    break;
            }

        }
    }
    public void Onpushmask()
    {
        messegedis.SetActive(true);
        ItemName = "マスク";
        mesasege.text = itemDataBase.GetItemLists()[0].GetItemName() + "\n" + itemDataBase.GetItemLists()[0].GetInformation() +"\n"+"を使用しますか？";
        
    }
    public void Onpushfood(){
        messegedis.SetActive(true);
        ItemName="食べ物";
        mesasege.text=GetItem(ItemName).GetItemName()+ "\n" + GetItem(ItemName).GetInformation() +"\n"+"を使用しますか？";
    }
    public void Onpushwater()
    {
        messegedis.SetActive(true);
        ItemName = "水";
        mesasege.text = GetItem(ItemName).GetItemName() + "\n" + GetItem(ItemName).GetInformation() + "\n" + "を使用しますか？";
    }
    public void Onpushdurk()
    {
        messegedis.SetActive(true);
        ItemName = "薬";
        mesasege.text = GetItem(ItemName).GetItemName() + "\n" + GetItem(ItemName).GetInformation() + "\n" + "を使用しますか？";
    }
    public void Onno(){messegedis.SetActive(false);}
    public async void Onyes() 
    {
      
        if (ItemName == "マスク" && GetItem(ItemName).Getkosuu()>0)
        {
            itemDataBase.GetItemLists()[0].Setkosuu(-1);
            Infection2.ismask = true;
            messegedis.SetActive(false);
        }
        if ( GetItem(ItemName).Getkosuu() == 0)
        {
            warning.text = "アイテムがありません";
            Invoke(nameof(Delwarning), 3);
        }
        if (ItemName == "食べ物" && GetItem(ItemName).Getkosuu() > 0)
        {
            Foodgaugemanager.Setfood(20);
            itemDataBase.GetItemLists()[3].Setkosuu(-1);
            messegedis.SetActive(false);
        }
        if (ItemName == "水" && GetItem(ItemName).Getkosuu() > 0)
        {
            Watergaugemanager.Setwater(20);
            itemDataBase.GetItemLists()[2].Setkosuu(-1);
            messegedis.SetActive(false);
        }
        if (ItemName == "薬" && GetItem(ItemName).Getkosuu() > 0)
        {
            Move.isdurk = true;

            itemDataBase.GetItemLists()[1].Setkosuu(-1);
            messegedis.SetActive(false);
            await Task.Delay(10000);
            Move.Effecttime();
        }

    }
    void Delwarning() { warning.text = null; }
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
