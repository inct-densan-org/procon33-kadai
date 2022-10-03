using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class Talktextmanager : MonoBehaviour
{
    public TextMeshProUGUI talktext;
    public GameObject talk;
    [SerializeField]
    private QuestDataBase QuestDataBase;

    // Update is called once per frame
    void Update()
    {
        if (Menumanager.menuKey == "talk")
        {
            talk.SetActive(true);
            if (Restranquest.questclear == true)
            {
                talktext.text = "「掃除をしてくれたのですね。ありがとうございます。これ報酬金です。」";
                if (Input.GetMouseButton(0))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Restranquest.questclear = false;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[3].Getreward());
                    QuestDataBase.GetQusetLists()[3].SetIsQuria(true);
                }
            }

            else if (Supermarketquest.questclear == true)
            {
                talktext.text = "「こちら報酬になります。」";
                if (Input.GetMouseButton(0))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[0].Getreward());
                    QuestDataBase.GetQusetLists()[0].SetIsQuria(true);

                    QuestDataBase.GetQusetLists()[0].SetIsQuest(false);
                    Supermarketquest.questclear = false;

                }
            }

            else if (Hospitalquest.questclear == true)
            {
                talktext.text = "「こちら報酬になります。」";
                if (Input.GetMouseButton(0))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[1].Getreward());
                    QuestDataBase.GetQusetLists()[1].SetIsQuria(true);
                    
                    Hospitalquest.questclear = false;
                }
            }

            else if (Dragstorequest.questclear == true)
            {
                talktext.text = "「こちら報酬になります。」";
                if (Input.GetMouseButton(0))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[2].Getreward());
                    QuestDataBase.GetQusetLists()[2].SetIsQuria(true);
                    Dragstorequest.questclear = false;

                }
            }

            else if (Officequest.questclear == true)
            {
                talktext.text = "「ありがとう。これはお礼だよ。」";
                if (Input.GetMouseButton(0))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[4].Getreward());
                    QuestDataBase.GetQusetLists()[4].SetIsQuria(true);
                    
                    Officequest.questclear = false;
                }
            }

            else if (Move.reception = true) 
            {
                talktext.text = "こちらを配達してください。";
                if (Input.GetMouseButton(0))
                {
                    talk.SetActive(false);
                    MenuManager.menuKey = null;
                    Move.reception = false;
                }
            }
        }
    }
}
