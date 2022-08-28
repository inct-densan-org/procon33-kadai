using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class menumanager : MonoBehaviour
{
    public GameObject menu ,messegedis;
     public static string menuKey;
    public TextMeshProUGUI k1,k2,k3,k4,mesasege,warning;
    public Image icon1,icon2,icon3,icon4;
    [SerializeField] private ItemDataBase itemDataBase;
    public string menuKeysee;
    private string ItemName;
    private Infection2 Infection2;
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
        mesasege.text = itemDataBase.GetItemLists()[0].GetItemName() + "\n" + itemDataBase.GetItemLists()[0].GetInformation() +"\n"+"を使用しますか？";
        ItemName = "マスク";
    }
    public　void Onno(){messegedis.SetActive(false);}
    public void Onyes() 
    { 
        
        if (ItemName == "マスク" && GetItem(ItemName).Getkosuu()>0)
        {
            itemDataBase.GetItemLists()[0].Setkosuu(-1);
            Infection2.ismask = true;
            messegedis.SetActive(false);
        }
        if (ItemName == "マスク" && GetItem(ItemName).Getkosuu() == 0)
        {
            warning.text = "アイテム個数がありません";
            Invoke(nameof(Delwarning), 3);
        }

    }
    void Delwarning() { warning.text = null; }
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
