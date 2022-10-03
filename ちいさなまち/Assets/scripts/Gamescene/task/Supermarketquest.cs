using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supermarketquest : MonoBehaviour
{
    [SerializeField] private QuestDataBase QuestDataBase;
    public static bool questclear;
    public static bool a = false;
    void Update()
    {
        if (QuestDataBase.GetQusetLists()[0].GetIsQuest() == true && a == true)
        {
            questclear = true;
            a = false;
        }
    }
}
