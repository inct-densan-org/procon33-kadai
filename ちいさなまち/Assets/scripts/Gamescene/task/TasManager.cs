using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.UI;

public class TasManager : MonoBehaviourPunCallbacks
{
    public GameObject Questmenu, messegedis;
    public TextMeshProUGUI inf1, inf2, inf3, messege,mesegetitle;
    [SerializeField]
    private QuestDataBase QuestDataBase;
    private Moneymanager Moneymanager;
    private string menuKey;
    private Menumanager menumanager;
    public List<int> list = new List<int>();
    public static int Questnum;
    public GameObject t1, t2, t3;
    public int quriacount;
    private int qiestnum;
    public Sprite menusp, questsp;
    private Image mesegeimage;
    // Start is called before the first frame update
    void Start()
    {
      mesegeimage=   messegedis.GetComponent<Image>() ;
        qiestnum = QuestDataBase.GetQusetLists().Count;
        for (int i = 0; i < QuestDataBase.GetQusetLists().Count; i++)
        {
            QuestDataBase.GetQusetLists()[i].SetIsQuest(false);
            QuestDataBase.GetQusetLists()[i].SetIsQuria(false);
        }
        int choiceNum;
        List<int> ramdumlist = new List<int>(); 
        for (int i = 0; i < QuestDataBase.GetQusetLists().Count; i++)
        {
            ramdumlist.Add(i);
        }
        var e = ramdumlist.Count;
        for (int i = 0; i < e; i++)
        {
            int ramdam = ramdumlist[Random.Range(0, ramdumlist.Count)];
            list.Add(ramdam);
            choiceNum = ramdumlist.IndexOf(ramdam);
            ramdumlist.RemoveAt(choiceNum);
        }
    }

    // Update is called once per frame
    void Update()
    {

        menuKey = Menumanager.menuKey;
        if (menuKey == "menu")
        {
            mesegetitle.text = "アイテム詳細";
            mesegeimage.sprite = menusp;
            mesegeimage.color = new Color32(189, 247, 255, 255);
        }
        if (menuKey=="quest")
        {//189,247,255,255
            mesegetitle.text = "クエスト詳細";
            mesegeimage.sprite = questsp;
            mesegeimage.color= new Color32(255, 255, 255, 255);
            if (QuestDataBase.GetQusetLists()[list[0]].GetIsQuest()) t1.SetActive(true); else t1.SetActive(false);
            if (QuestDataBase.GetQusetLists()[list[1]].GetIsQuest()) t2.SetActive(true); else t2.SetActive(false);
            if (QuestDataBase.GetQusetLists()[list[2]].GetIsQuest()) t3.SetActive(true); else t3.SetActive(false);
            Questmenu.SetActive(true);
            inf1.text =  $"{QuestDataBase.GetQusetLists()[list[0]].GetQuestinf()}" + "\n" + " クリアほうしゅう" + $"{QuestDataBase.GetQusetLists()[list[0]].Getreward()}" + "円";
            inf2.text =  $"{QuestDataBase.GetQusetLists()[list[1]].GetQuestinf()}" + "\n" + " クリアほうしゅう" + $"{QuestDataBase.GetQusetLists()[list[1]].Getreward()}" + "円";
            inf3.text =   $"{QuestDataBase.GetQusetLists()[list[2]].GetQuestinf()}" + "\n" + " クリアほうしゅう" + $"{QuestDataBase.GetQusetLists()[list[2]].Getreward()}" + "円";
        }
        for (int i = 0; i < QuestDataBase.GetQusetLists().Count; i++)
        {
            if (QuestDataBase.GetQusetLists()[i].GetIsQuria())
            {
                taskquria(i);
                quriacount++;
            }
           
            
        }
        if(quriacount== qiestnum)
        {
            quriacount = 0;
            int choiceNum;
            List<int> ramdumlist = new List<int>();
            for (int i = 0; i < QuestDataBase.GetQusetLists().Count; i++)
            {
                ramdumlist.Add(i);
            }
            var e = ramdumlist.Count;
            for (int i = 0; i < e; i++)
            {
                int ramdam = ramdumlist[Random.Range(0, ramdumlist.Count)];
                list.Add(ramdam);
                choiceNum = ramdumlist.IndexOf(ramdam);
                ramdumlist.RemoveAt(choiceNum);
            } 
        }
    }
    public void taskquria(int i)
    {
        list.Remove(i);
        QuestDataBase.GetQusetLists()[i].SetIsQuria(false);
    }
    public void OnPushBack()
    {
        Menumanager.menuKey = null;
        Questmenu.SetActive(false);
    }
    public void OnPushInf1()
    {
        Questnum = QuestDataBase.GetQusetLists()[list[0]].GetNumber();
        messegedis.SetActive(true);
        messege.text = $"{QuestDataBase.GetQusetLists()[list[0]].GetQuestinf()}" + "\n" + $"{QuestDataBase.GetQusetLists()[list[0]].Getreward()}" + "円" + "\n" + "���󂯂܂����H";
    }
    public void OnPushInf2()
    {
        Questnum = QuestDataBase.GetQusetLists()[list[1]].GetNumber();
        messegedis.SetActive(true);
        messege.text = $"{QuestDataBase.GetQusetLists()[list[1]].GetQuestinf()}" + "\n" + $"{QuestDataBase.GetQusetLists()[list[1]].Getreward()}" + "円" + "\n" + "���󂯂܂����H";
    }
    public void OnPushInf3()
    {
        Questnum = QuestDataBase.GetQusetLists()[list[2]].GetNumber();
        messegedis.SetActive(true);
        messege.text = $"{QuestDataBase.GetQusetLists()[list[2]].GetQuestinf()}" + "\n" + $"{QuestDataBase.GetQusetLists()[list[2]].Getreward()}" + "円" + "\n" + "���󂯂܂����H";
    }
}