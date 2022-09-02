using Photon.Pun;
using UnityEngine;
using TMPro;
using Photon.Realtime;

[RequireComponent(typeof(Animator))]
// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class Move : MonoBehaviourPunCallbacks
{
    private bool ispush,ishor,isver,infection;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y");
    private Animator animator = null;
    public static Vector3 popo;
    private Vector3 input;
    private Menumanager menumanager;
    public static bool isdurk;
    private float speed = 5f;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    public static string myplayername;
    private Player player;
    public void Start()
    {
        player = PhotonNetwork.LocalPlayer;
         myplayername = this.gameObject.name;
        GameObject oya = GameObject.Find("Canvas");
        transform.parent = oya.transform;
        transform.localPosition = new Vector3(0, 5.7f, -1);
        animator = GetComponent<Animator>();
        var byou = gameObject.AddComponent<itibyou>();
        byou.Init(() =>
        {
         
            infection = Customproperties.Getplayerinf(player.ActorNumber);
        });
        byou.Play();
    }

    private void Update()
    {
        //var isshop = shopmanager.isshop;
        var menuKey = Menumanager.menuKey;
        
        var x = Input.GetAxisRaw("Horizontal");
        var  y = Input.GetAxisRaw("Vertical");
        if (infection == true&&isdurk==false)
        {
            speed = 1f;
        }
        if (infection == true && isdurk == true)
        {
            speed = 3f;
        }
        if(infection==false)
        {
            speed = 5f;
        }
        // ���g�����������I�u�W�F�N�g�����Ɉړ��������s��
        if (photonView.IsMine)
        {
            if (menuKey == null)
            {
                if (Input.GetAxisRaw("Horizontal") != 0 && isver == false)
                {
                    input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0f); ishor = true;
                }
                else if (Input.GetAxisRaw("Vertical") != 0 && ishor == false)
                {
                    input = new Vector3(0, Input.GetAxisRaw("Vertical"), 0f); isver = true;
                }
                else
                {
                    input = new Vector3(0, 0, 0f);
                }
                transform.Translate(speed * Time.deltaTime * input.normalized);
            } 
            
            popo = transform.position;
            if (Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.RightArrow)){ animator.SetFloat(idX, 0.5f); animator.SetFloat(idY, 0); ispush = false; ishor = false; }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) { animator.SetFloat(idX, -0.5f); animator.SetFloat(idY, 0); ispush=false; ishor = false; }
            if (x > 0.1 && ispush == false) { animator.SetFloat(idX, 1); ispush = true; }
            if (x <-0.1 && ispush == false) { animator.SetFloat(idX, -1); ispush = true; }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) { animator.SetFloat(idY, 0.5f); animator.SetFloat(idX, 0); ispush = false; isver = false;  }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) { animator.SetFloat(idY, -0.5f); animator.SetFloat(idX, 0); ispush = false;isver = false; }
            if (y > 0.1 && ispush == false) { animator.SetFloat(idY, 1); ispush = true; }
            if (y < -0.1 && ispush == false) { animator.SetFloat(idY, -1); ispush = true; }
        }
    }
    public static void Effecttime()
    {

        isdurk = false;
    }
}

