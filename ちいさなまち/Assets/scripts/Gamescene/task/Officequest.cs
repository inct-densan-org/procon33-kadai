using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Officequest : MonoBehaviour
{
    [SerializeField] private QuestDataBase QuestDataBase;
    public static bool questclear;
    
    void Update()
    {
        if (QuestDataBase.GetQusetLists()[4].GetIsQuest() == true)
        {
            questclear = true;
        }
    }
}