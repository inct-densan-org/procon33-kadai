using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TasManager : MonoBehaviour
{
    public GameObject Questmenu;
    public TextMeshProUGUI inf1, inf2, inf3;
    [SerializeField]
    private QuestDataBase QuestDataBase;
    private Moneymanager Moneymanager;
    private string menuKey;
    private Menumanager menumanager;
    private List<int> list =new List<int>();
    // Start is called before the first frame update
    void Start()
    {
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
        
        menuKey = Menumanager.menuKey;
        if (menuKey=="quest")
        {@
            inf1.text = "E" + $"{QuestDataBase.GetQusetLists()[list[0]].GetQuestinf()}" + "\n" + " ’B¬•ñV@" + $"{QuestDataBase.GetQusetLists()[list[0]].Getreward()}" + "‰~";
            inf2.text = "E" + $"{QuestDataBase.GetQusetLists()[list[1]].GetQuestinf()}" + "\n" + " ’B¬•ñV@" + $"{QuestDataBase.GetQusetLists()[list[1]].Getreward()}" + "‰~";
            inf3.text = "E" + $"{QuestDataBase.GetQusetLists()[list[2]].GetQuestinf()}" + "\n" + " ’B¬•ñV@" + $"{QuestDataBase.GetQusetLists()[list[2]].Getreward()}" + "‰~";
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {
               

                Menumanager.menuKey = "quest";
                Questmenu.SetActive(true);
            }
        }

    }
    public void OnPushBack()
    {
        Menumanager.menuKey = null;
        Questmenu.SetActive(false);
    }
}
