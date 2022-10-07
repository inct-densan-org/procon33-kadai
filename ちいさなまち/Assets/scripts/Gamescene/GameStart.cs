using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameStart : MonoBehaviourPunCallbacks
{
    Dictionary<int, string> NPClist = new Dictionary<int, string>();
    public List<int> list = new List<int>();
    public GameObject[] asd;
    public int StartNpcInf;
    private Customproperties customproperties;
    private PUN2Server pUN2Server;
    private Player p1;
    private bool ab;
    // Start is called before the first frame update
    void   Start()
    {
        pUN2Server = GameObject.Find("PUN2Sever").gameObject.GetComponent<PUN2Server>();
        customproperties = GameObject.Find("PUN2Sever").gameObject.GetComponent<Customproperties>();
        var player = PhotonNetwork.PlayerList;
         p1 = player[0];
        
    }
    public  void a()
    {
      //  await Task.Delay(2000);
        
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
                
                customproperties.SetNPCinf(NPClist[list[i]], true);
            }
            
        }
        




    }
    // Update is called once per frame
    void Update()
    {
        if (p1 == PhotonNetwork.LocalPlayer&&pUN2Server.isStart&&!ab)
        {
            
            ab = true;
            a();
        }
    }
}
