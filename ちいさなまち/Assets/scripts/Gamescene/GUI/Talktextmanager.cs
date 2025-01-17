using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using Photon.Pun;

public class Talktextmanager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI talktext,hitotext;
    public GameObject talk;
    [SerializeField]
    private QuestDataBase QuestDataBase;
    [SerializeField]
    private ItemDataBase ItemDataBase;
    private int a;
    public bool cooltime;
    public bool iswash;
    public int syokuba;
    public string syokubaname;
    public Move move;
    // Update is called once per frame
   
    async void Update()
    {
        var tagObjects = GameObject.FindGameObjectsWithTag("Player");
        if (move == null)
        {
            for (int i = 0; i < tagObjects.Length; i++)
            {
                if (PhotonNetwork.LocalPlayer.ActorNumber == tagObjects[i].GetPhotonView().OwnerActorNr)
                {
                    move = tagObjects[i].GetComponent<Move>();
                }
            }
        }
        if (Menumanager.menuKey == "shoptalk")
        {
            talk.SetActive(true);
            if (Restranquest.questclear == true)
            {
                talktext.text = "「掃除をしてくれたのですね。ありがとうございます。これ報酬金です。」";
                if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
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
                    syokubaname = null;
                }
            }
        }
        if (Menumanager.menuKey != "talk" || Menumanager.menuKey != "wash")
        {
            hitotext.text = "店員";
        }
        if (Menumanager.menuKey == "wash")
        {
            
            talk.SetActive(true);
            hitotext.text = "自分";
            talktext.text = "手洗いうがいをしました。";
            if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
            {
                
                talk.SetActive(false);
                Menumanager.menuKey = null;
                cooltime1();
                if (!iswash)
                {
                    iswash = true;
                    await Task.Delay(40000);
                    iswash = false;
                }
               
            }
        }
        
        if (Menumanager.menuKey == "talk")
        {
            hitotext.text = "職員";
            
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
                        cooltime1();
                        

                        Move.reception = false;
                        if (QuestDataBase.GetQusetLists()[2].GetIsQuest() == true)
                        {
                            Dragstorequest.a = true;
                            GetItem("配達用のマスク").Setkosuu(1);
                        }

                        if (QuestDataBase.GetQusetLists()[4].GetIsQuest() == true)
                        {
                            
                            GetItem("書類").Setkosuu(1);
                           syokubaname= move.Syokubanamereturn();
                            Officequest.a = true;
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
   async void cooltime1()
    {
        cooltime = true;
        await Task.Delay(500);
        cooltime = false;
    }
    async void derei()
    {
        await Task.Delay(12000);
        
    }
    public Item GetItem(string searchName)
    {
        return ItemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
