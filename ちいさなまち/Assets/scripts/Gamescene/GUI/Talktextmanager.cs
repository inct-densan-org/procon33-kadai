using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class Talktextmanager : MonoBehaviour
{
    public TextMeshProUGUI talktext;
    public GameObject talk;
    [SerializeField]
    private QuestDataBase QuestDataBase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Menumanager.menuKey == "talk")
        {
            talk.SetActive(true);
            if (Restranquest.questquria == true)
            {
                talktext.text = "�X��\n �u�|�������Ă��ꂽ�̂ł��ˁB���肪�Ƃ��������܂��B�����V���ł��B�v";
                if (Input.GetMouseButton(0))
                {
                    talk.SetActive(false);
                    Menumanager.menuKey = null;
                    Restranquest.questquria = false;
                    Moneymanager.Setmoney(QuestDataBase.GetQusetLists()[3].Getreward());
                    QuestDataBase.GetQusetLists()[3].SetIsQuria(true);
                }
            }
        }
    }
}
