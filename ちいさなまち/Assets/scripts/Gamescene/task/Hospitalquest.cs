using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospitalquest : MonoBehaviour
{
    [SerializeField] private QuestDataBase QuestDataBase;
    public static bool questclear;
    
    void Update()
    {
        if (QuestDataBase.GetQusetLists()[1].GetIsQuest() == true)
        {
            questclear = true;
        }
    }
}