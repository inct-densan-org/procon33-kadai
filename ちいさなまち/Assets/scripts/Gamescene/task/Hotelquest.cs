using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotelquest : MonoBehaviour
{
    [SerializeField]
    private QuestDataBase QuestDataBase;
    public GameObject gomi1, gomi2, gomi3, gomi4, gomi5;
    public static int gominum;
    public static bool questclear;
    private bool a, b;
    // Update is called once per frame
    void Update()
    {
        if (QuestDataBase.GetQusetLists()[5].GetIsQuest() && a == false)
        {
            a = true;
            gomi1.SetActive(true); gomi2.SetActive(true); gomi3.SetActive(true); gomi4.SetActive(true); gomi5.SetActive(true);
        }
        if (gominum == 5 && b == false)
        {
            questclear = true;
            b = true;
        }
    }
    public void ABReset()
    {
        a = false;
        b = false;
    }
}
