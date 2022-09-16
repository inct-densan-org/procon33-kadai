using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restranquest : MonoBehaviour
{
    [SerializeField]
    private QuestDataBase QuestDataBase;
    public GameObject gomi1, gomi2, gomi3;
    public static int gominum;
    public static bool questquria;
    private bool a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (QuestDataBase.GetQusetLists()[3].GetIsQuest()&&a==false)
        {
            a = true;
            gomi1.SetActive(true); gomi2.SetActive(true); gomi3.SetActive(true);
        }
        if (gominum == 3)
        {
            questquria = true;
        }
        
    }
}
