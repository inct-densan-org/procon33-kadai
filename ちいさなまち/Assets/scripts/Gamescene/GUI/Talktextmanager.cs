using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;


public class Talktextmanager : MonoBehaviour
{
    public TextMeshProUGUI talktext;
    public GameObject talk;
    [SerializeField]
    private QuestDataBase QuestDataBase;
    [SerializeField]
    private ItemDataBase ItemDataBase;
    private int a;
    public bool cooltime;
    // Update is called once per frame
   async void Update()
    {
        if (Menumanager.menuKey == "shoptalk")
        {
            talk.SetActive(true);
            if (Restranquest.questclear == true)
            {
                talktext.text = "「掃除をしてくれたのですね。ありがとうございます。これ報酬金です。」";
                if (Input.GetMouseButton(0) )
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Restranquest.questclear = false;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[3].Getreward());
                    QuestDataBase.GetQusetLists()[3].SetIsQuest(false);
                    QuestDataBase.GetQusetLists()[3].SetIsQuria(true);
                }
            }
        }
        if (Menumanager.menuKey == "hoteltalk")
        {
            talk.SetActive(true);
            if (Hotelquest.questclear == true)
            {
                talktext.text = "「掃除をしてくれたのですね。ありがとうございます。これ報酬金です。」";
                if (Input.GetMouseButton(0)||Input.GetKeyDown(KeyCode.Space))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Hotelquest.questclear = false;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[5].Getreward());
                    QuestDataBase.GetQusetLists()[5].SetIsQuest(false);
                    QuestDataBase.GetQusetLists()[5].SetIsQuria(true);
                }
            }
        }
        if (Menumanager.menuKey == "foodtalk")
        {
            talk.SetActive(true);
            if (Supermarketquest.questclear == true)
            {
                talktext.text = "「こちら報酬になります。」";
                if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[0].Getreward());
                    QuestDataBase.GetQusetLists()[0].SetIsQuria(true);
                    QuestDataBase.GetQusetLists()[0].SetIsQuest(false);
                    GetItem("配達用の食料").Setkosuu(-1);
                    QuestDataBase.GetQusetLists()[0].SetIsQuest(false);
                    Supermarketquest.questclear = false;

                }
            }
        }
        if (Menumanager.menuKey == "hostalk")
        {
            talk.SetActive(true);
            if (Hospitalquest.questclear == true)
            {
                talktext.text = "「こちら報酬になります。」";
                if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[1].Getreward());
                    QuestDataBase.GetQusetLists()[1].SetIsQuria(true);
                    QuestDataBase.GetQusetLists()[1].SetIsQuest(false);
                    GetItem("配達用の薬").Setkosuu(-1);
                    Hospitalquest.questclear = false;
                }
            }
        }
        if (Menumanager.menuKey == "dragtalk")
        {
            talk.SetActive(true);
            if (Dragstorequest.questclear == true)
            {
                talktext.text = "「こちら報酬になります。」";
                if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[2].Getreward());
                    QuestDataBase.GetQusetLists()[2].SetIsQuria(true);
                    QuestDataBase.GetQusetLists()[2].SetIsQuest(false);
                    Dragstorequest.questclear = false;
                    GetItem("配達用のマスク").Setkosuu(-1);
                }
            }
        }
           
        if (Menumanager.menuKey == "questtalk")
        {
            talk.SetActive(true);
            if (Officequest.questclear == true)
            {
                talktext.text = "「ありがとう。これはお礼だよ。」";
                if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[4].Getreward());
                    QuestDataBase.GetQusetLists()[4].SetIsQuria(true);
                    QuestDataBase.GetQusetLists()[4].SetIsQuest(false);
                    GetItem("書類").Setkosuu(-1);
                    Officequest.questclear = false;
                }
            }
        }

        if (Menumanager.menuKey == "talk")
        {
            talk.SetActive(true);
            if (Move.reception == true)
            {
                
                a = 0;
                for (int i = 0; i < QuestDataBase.GetQusetLists().Count; i++)
                {
                    if (i == 3||i==5) continue;
                    if (QuestDataBase.GetQusetLists()[i].GetIsQuest() == true && GetItem(QuestDataBase.GetQusetLists()[i].GetQuestitem()).Getkosuu() == 0)
                    {
                        a++;
                    }

                }
                if (a > 0)
                {
                    talktext.text = "こちらを配達してください。";
                    if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
                    {
                        talk.SetActive(false);
                        Menumanager.menuKey = null;
                        cooltime = true;
                        

                        Move.reception = false;
                        if (QuestDataBase.GetQusetLists()[2].GetIsQuest() == true)
                        {
                            Dragstorequest.a = true;
                            GetItem("配達用のマスク").Setkosuu(1);
                        }

                        if (QuestDataBase.GetQusetLists()[4].GetIsQuest() == true)
                        {
                            Officequest.a = true;
                            GetItem("書類").Setkosuu(1);
                        }
                        if (QuestDataBase.GetQusetLists()[1].GetIsQuest() == true)
                        {
                            Hospitalquest.a = true;
                            GetItem("配達用の薬").Setkosuu(1);
                        }
                        if (QuestDataBase.GetQusetLists()[0].GetIsQuest() == true)
                        {
                            Supermarketquest.a = true;
                            GetItem("配達用の食料").Setkosuu(1);
                        }
                        await Task.Delay(500);
                        cooltime = false;
                    }
                }
                else
                {

                    talktext.text = "私はここでクエストアイテムの受け渡しをしています。";
                    if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
                    {
                        cooltime = true;
                        talk.SetActive(false);
                        Menumanager.menuKey = null;
                        await Task.Delay(500);
                        cooltime = false;
                    }
                }
            }
        

        }
        
    }
    public Item GetItem(string searchName)
    {
        return ItemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
