using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class TasManager : MonoBehaviourPunCallbacks
{
    public GameObject Questmenu,messegedis,questNPC;
    public TextMeshProUGUI inf1, inf2, inf3,mesege;
    [SerializeField]
    private QuestDataBase QuestDataBase;
    private Moneymanager Moneymanager;
    private string menuKey;
    private Menumanager menumanager;
    publicÅ@ List<int> list =new List<int>();
    public static int Questnum;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < QuestDataBase.GetQusetLists().Count; i++)
        {
            QuestDataBase.GetQusetLists()[i].SetIsQuest(false);
        }
        int choiceNum;
        List<int> ramdumlist = new List<int>(); ;
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
        if (QuestDataBase.GetQusetLists()[0].GetIsQuest() == true)
        {
            questNPC.SetActive(true);
        }
        menuKey = Menumanager.menuKey;
        if (menuKey=="quest")
        {
            Questmenu.SetActive(true);
            inf1.text = "ÅE" + $"{QuestDataBase.GetQusetLists()[list[0]].GetQuestinf()}" + "\n" + " íBê¨ïÒèVÅ@" + $"{QuestDataBase.GetQusetLists()[list[0]].Getreward()}" + "â~";
            inf2.text = "ÅE" + $"{QuestDataBase.GetQusetLists()[list[1]].GetQuestinf()}" + "\n" + " íBê¨ïÒèVÅ@" + $"{QuestDataBase.GetQusetLists()[list[1]].Getreward()}" + "â~";
            inf3.text = "ÅE" + $"{QuestDataBase.GetQusetLists()[list[2]].GetQuestinf()}" + "\n" + " íBê¨ïÒèVÅ@" + $"{QuestDataBase.GetQusetLists()[list[2]].Getreward()}" + "â~";
        }

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
        mesege.text = $"{QuestDataBase.GetQusetLists()[list[0]].GetQuestinf()}" + "\n" + "íBê¨ïÒèVÅ@" + $"{QuestDataBase.GetQusetLists()[list[0]].Getreward()}" + "â~" + "\n" + "ÇéÛÇØÇ‹Ç∑Ç©ÅH";
    }
    public void OnPushInf2()
    {
        Questnum = QuestDataBase.GetQusetLists()[list[1]].GetNumber();
        messegedis.SetActive(true);
        mesege.text = $"{QuestDataBase.GetQusetLists()[list[1]].GetQuestinf()}" + "\n" + "íBê¨ïÒèVÅ@" + $"{QuestDataBase.GetQusetLists()[list[1]].Getreward()}" + "â~" + "\n" + "ÇéÛÇØÇ‹Ç∑Ç©ÅH";
    }
    public void OnPushInf3()
    {
        Questnum = QuestDataBase.GetQusetLists()[list[2]].GetNumber();
        messegedis.SetActive(true);
        mesege.text = $"{QuestDataBase.GetQusetLists()[list[2]].GetQuestinf()}" + "\n" + "íBê¨ïÒèVÅ@" + $"{QuestDataBase.GetQusetLists()[list[2]].Getreward()}" + "â~" + "\n" + "ÇéÛÇØÇ‹Ç∑Ç©ÅH";
    }
}
