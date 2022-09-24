using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using Photon.Pun;
public class Playerlistmanager : MonoBehaviour
{
    public GameObject textpre,playerlistdis,menu;
    public Transform textParent = null;
    private Menumanager menumanager;
    // Start is called before the first frame update
    void Start()
    {

       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnpushPlayerlist()
    {
        int playernum = PhotonNetwork.PlayerList.Length;
        for (int i = 0; i < playernum; i++)
        {
            GameObject text = Instantiate(textpre, textParent);
            var notice = text.GetComponent<TextMeshProUGUI>();
            notice.text = $"{i + 1}; {PhotonNetwork.PlayerList[i].NickName}";

        }
        playerlistdis.SetActive(true);
        menu.SetActive(false);
        Menumanager.menuKey = "playerlist";
    }
    public void Onpushback()
    {
        menu.SetActive(true);
        playerlistdis.SetActive(false);
        Menumanager.menuKey = "menu";
    }
}
