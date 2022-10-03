using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Officequest : MonoBehaviour
{
    [SerializeField] private QuestDataBase QuestDataBase;
    public static bool questclear;
    public static bool a = false;
    private void Start()
    {
        questclear = false;
    }
    void Update()
    {
        if (QuestDataBase.GetQusetLists()[4].GetIsQuest() == true && a == true)
        {
            questclear = true;
            a = false;
        }
        else if (QuestDataBase.GetQusetLists()[4].GetIsQuest() == false) 
        {
            a = false;
        }
    }
}