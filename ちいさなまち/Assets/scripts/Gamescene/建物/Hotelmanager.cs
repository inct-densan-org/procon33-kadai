using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using System.Threading.Tasks;

public class Hotelmanager : MonoBehaviourPunCallbacks
{
    public GameObject hoteldis,itigou,nigou,urikere,itigoudoa,nigoudoa;
    public TextMeshProUGUI moneytext,mesege;
    public bool isitigou, isnigou;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Menumanager.menuKey == "hotel")
        {
            moneytext.text = $"{Moneymanager.Money}";
            hoteldis.SetActive(true);
            if (!isitigou)
            {
                itigou.SetActive(true);
            }
            else itigou.SetActive(false);
            if (!isnigou) nigou.SetActive(true);
            else nigou.SetActive(false);
            if (isitigou && isnigou) { urikere.SetActive(true); }
            else urikere.SetActive(false);
        }
    }
  public async void Onpush1gou()
    {
        if (Moneymanager.Money >= 1000)
        {
            itigou.SetActive(false);
            Moneymanager.Setmoney(-1000);
            photonView.RPC(nameof(Setitigou), RpcTarget.All);
            itigoudoa.SetActive(false);
            mesege.text = "w“ü‚µ‚Ü‚µ‚½";
            await Task.Delay(3000);
            mesege.text = null;
        }
        else
        {
            mesege.text = "Š‹à‚ª‘«‚è‚Ü‚¹‚ñ";
            await Task.Delay(3000);
            mesege.text = null;
        }
    }
   public  async void Onpush2gou()
    {
        if (Moneymanager.Money >= 1000)
        {
            nigou.SetActive(false);
            Moneymanager.Setmoney(-1000);
            photonView.RPC(nameof(Setnigou), RpcTarget.All);
            nigoudoa.SetActive(false);
            mesege.text = "w“ü‚µ‚Ü‚µ‚½";
            await Task.Delay(3000);
            mesege.text = null;
        }
        else
        {
            mesege.text = "Š‹à‚ª‘«‚è‚Ü‚¹‚ñ";
            await Task.Delay(3000);
            mesege.text = null;
        }
    }
    public void Onpushback()
    {
        
        Menumanager.menuKey = null;
        hoteldis.SetActive(false);
    }
    [PunRPC]
    public void Setitigou()
    {
        isitigou = true;
    }
    [PunRPC]
    public void Setnigou()
    {
        isnigou = true;
    }
}
