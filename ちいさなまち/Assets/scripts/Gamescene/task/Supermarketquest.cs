using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supermarketquest : MonoBehaviour
{
    [SerializeField] private QuestDataBase QuestDataBase;
    public static bool questclear;
    
    void Update()
    {
        if (QuestDataBase.GetQusetLists()[0].GetIsQuest() == true)
        {
            questclear = true;
        }
    }
}
