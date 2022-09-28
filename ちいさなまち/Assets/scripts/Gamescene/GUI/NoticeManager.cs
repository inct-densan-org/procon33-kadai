using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using Photon.Pun;
public class NoticeManager : MonoBehaviourPunCallbacks
{
    public GameObject textpre;
    public  Transform textParent = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public  void Notice(string value)
    {
        photonView.RPC(nameof(notice), RpcTarget.All, value);
    }
    [PunRPC]
    public async void notice(string value)
    {
        GameObject text = Instantiate(textpre, textParent);
        var notice = text.GetComponent<TextMeshProUGUI>();
        notice.text = value;
        await Task.Delay(3000);
        DestroyImmediate(text);
    }
}
