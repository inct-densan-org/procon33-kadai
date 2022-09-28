
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using Photon.Pun;
public class Playerlistmanager : MonoBehaviour
{
    public GameObject textpre, playerlistdis, menu;
    public Transform textParent = null;
    private Menumanager menumanager;
    public Dictionary<int, GameObject> texts = new Dictionary<int, GameObject>();
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
            notice.text = $"{i + 1} :  {PhotonNetwork.PlayerList[i].NickName}";
            texts.Add(i, text);
        }
        playerlistdis.SetActive(true);
        menu.SetActive(false);
        Menumanager.menuKey = "playerlist";
    }
    public void Onpushback()
    {
        int playernum = PhotonNetwork.PlayerList.Length;
        menu.SetActive(true);
        playerlistdis.SetActive(false);
        Menumanager.menuKey = "menu";
        for (int i = 0; i < playernum; i++)
        {
            GameObject icon = texts[i];
            // �A�C�e���̃A�C�R�����폜
            Destroy(icon);
            // �A�C�R���̃f�B�N�V���i������Ώۂ̃A�C�e�����폜
            texts.Remove(i);
        }
    }
}