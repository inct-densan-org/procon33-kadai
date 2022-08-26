using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class shopmanager : MonoBehaviour
{
    public GameObject shopmenu;
    public Image icon1, icon2, icon3, icon4;
    // private Sprite sp1, sp2, sp3, sp4;
    public TextMeshProUGUI en1, en2, en3, en4, info1, info2, info3, info4, kosuu1, kosuu2, kosuu3, kosuu4,total,moneytext,mesege;
    public static bool isshop;
    private bool haninai, a;
    [SerializeField]
    private ItemDataBase itemDataBase;
    private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();
    private int ko1, ko2, ko3, ko4,money,totalmoney;
    private Moneymanager Moneymanager;
    // Start is called before the first frame update
    void Start()
    {
        //time = Mathf.Clamp(time, MIN, MAX);

        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            //?@?A?C?e??????K??????
            numOfItem.Add(itemDataBase.GetItemLists()[i], 0);
            //?@?m?F???f?[?^?o??

            Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ": " + itemDataBase.GetItemLists()[i].GetInformation() + "??");
        }
    }
    // Update is called once per frame
    void Update()
    {
        ko1 = Mathf.Clamp(ko1, 0, 9);
        ko2 = Mathf.Clamp(ko2, 0, 9);
        ko3 = Mathf.Clamp(ko3, 0, 9);
        ko4 = Mathf.Clamp(ko4, 0, 9);
        if (isshop == true)
        {
            money = Moneymanager.Money;
            moneytext.text = $"{money}" + "‰~";
            icon1.sprite = itemDataBase.GetItemLists()[0].GetIcon();
            icon2.sprite = itemDataBase.GetItemLists()[1].GetIcon();
            icon3.sprite = itemDataBase.GetItemLists()[2].GetIcon();
            icon4.sprite = itemDataBase.GetItemLists()[3].GetIcon();
            en1.text = itemDataBase.GetItemLists()[0].Getmoney() + "‰~";
            en2.text = itemDataBase.GetItemLists()[1].Getmoney() + "‰~";
            en3.text = itemDataBase.GetItemLists()[2].Getmoney() + "‰~";
            en4.text = itemDataBase.GetItemLists()[3].Getmoney() + "‰~";
            info1.text = $"{itemDataBase.GetItemLists()[0].GetItemName()}" + "\n" + $"{itemDataBase.GetItemLists()[0].GetInformation()}";
            info2.text = $"{itemDataBase.GetItemLists()[1].GetItemName()}" + "\n" + $"{itemDataBase.GetItemLists()[1].GetInformation()}";
            info3.text = $"{itemDataBase.GetItemLists()[2].GetItemName()}" + "\n" + $"{itemDataBase.GetItemLists()[2].GetInformation()}";
            info4.text = $"{itemDataBase.GetItemLists()[3].GetItemName()}" + "\n" + $"{itemDataBase.GetItemLists()[3].GetInformation()}";
            kosuu1.text = $"{ko1}";
            kosuu2.text = $"{ko2}";
            kosuu3.text = $"{ko3}";
            kosuu4.text = $"{ko4}";
            totalmoney = (itemDataBase.GetItemLists()[0].Getmoney() * ko1) + (itemDataBase.GetItemLists()[1].Getmoney() * ko2) + (itemDataBase.GetItemLists()[2].Getmoney() * ko3) + (itemDataBase.GetItemLists()[3].Getmoney() * ko4);
            total.text = $"{totalmoney}"+"‰~";
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (Input.GetKey(KeyCode.Space))
            {

                isshop = true;
                shopmenu.SetActive(true);
            }
        }

    }
    public void Onpushue1() { ko1++; }
    public void Onpushue2() { ko2++; }
    public void Onpushue3() { ko3++; }
    public void Onpushue4() { ko4++; }
    public void Onpushsita1() { ko1--; }
    public void Onpushsita2() { ko2--; }
    public void Onpushsita3() { ko3--; }
    public void Onpushsita4() { ko4--; }
    public void Onpushbuy() { if (money < totalmoney) { mesege.text = "ŠŽ‹à‚ª‘«‚è‚Ü‚¹‚ñ"; Invoke(nameof(mesagedele), 3f); } else { mesege.text = "w“ü‚µ‚Ü‚µ‚½";Invoke(nameof(mesagedele), 3f);Moneymanager.Setmoney(totalmoney); } }
    void mesagedele()
    {
        mesege.text = null;
    }
    public void Onpushback() { isshop =false;shopmenu.SetActive(false); }

}