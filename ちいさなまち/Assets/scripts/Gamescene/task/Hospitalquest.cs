using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospitalquest : MonoBehaviour
{
    [SerializeField] private QuestDataBase QuestDataBase;
    public static bool questclear;
    public static bool a = false;
    private void Start()
    {
        questclear = false;
        a = false;
    }
    void Update()
    {
        if (QuestDataBase.GetQusetLists()[1].GetIsQuest() == true && a == true)
        {
            questclear = true;
            a = false;
        }
        else if (QuestDataBase.GetQusetLists()[1].GetIsQuest() == false) 
        {
            a = false;
        }
    }
}