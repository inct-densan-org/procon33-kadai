using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Pun;
public class GameStart : MonoBehaviourPunCallbacks
{
    Dictionary<int, string> NPClist = new Dictionary<int, string>();
    public List<int> list = new List<int>();
    public GameObject[] asd;
    public int StartNpcInf;
    private Customproperties customproperties;
    // Start is called before the first frame update
    void   Start()
    {
        customproperties = GameObject.Find("PUN2Sever").gameObject.GetComponent<Customproperties>();
        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];
        if (p1 == PhotonNetwork.LocalPlayer)
        {
          a();
        }
    }
    public async void a()
    {
        await Task.Delay(2000);
        asd= GameObject.FindGameObjectsWithTag("NPC");
        List<int> ramdumlist = new List<int>(); ;
        for (int i = 0; i < asd.Length; i++)
        {
            NPClist.Add(i, asd[i].name);
            ramdumlist.Add(i);
        }
        int choiceNum;
        var e = ramdumlist.Count;
        for (int i = 0; i < e; i++)
        {
            int ramdam = ramdumlist[Random.Range(0, ramdumlist.Count)];
            list.Add(ramdam);
            choiceNum = ramdumlist.IndexOf(ramdam);
            ramdumlist.RemoveAt(choiceNum);
        }
        
        for(int i = 0; i < StartNpcInf; i++)
        {
            while (customproperties.GetNPCinf(NPClist[list[i]]) == false)
            {
                Debug.Log(NPClist[list[i]]);
                customproperties.SetNPCinf(NPClist[list[i]], true);
            }
           
        }
        
        
        
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
