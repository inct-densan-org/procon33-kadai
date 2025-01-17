using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;
public class Route1 : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject moveObj;
    [SerializeField] float speed;
    public int orikaesi;
    private List<Transform> points;
    public int pointIdx = 0;
    public float waittime,orikaesiwait;
    Vector3 nextPos;
    private Vector3 nowPos, maePos;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y");
    private Animator animator = null;
    public string e;
    private bool b;
    public bool c;
    void Start()
    {
        
        speed = UnityEngine.Random.Range(1.0f, 2.0f);
        waittime = UnityEngine.Random.Range(1.0f, 15.0f);
        orikaesiwait = UnityEngine.Random.Range(1.0f, 15.0f);
        points = new List<Transform>();
        points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        nextPos = points[pointIdx].position;
        animator = moveObj.  GetComponent<Animator>();
        moveObj.SetActive(true);
    }
    void Update()
    {
        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];
        
       
        if (p1 == PhotonNetwork.LocalPlayer)
        {
            
            if(b == false) moveObj.transform.position = points[0].position;b = true;
            nowPos = moveObj.transform.position;
            var a = moveObj.transform.position;
            maepos(a);
            if (c == false)
            {
                if ((nextPos - moveObj.transform.position).sqrMagnitude > Mathf.Epsilon)
                {
                    moveObj.transform.position = Vector3.MoveTowards(moveObj.transform.position, nextPos, speed * Time.deltaTime);
                }
                else
                {
                    pointIdx++;

                    if (pointIdx == orikaesi)
                    {
                     //  moveObj.SetActive(false);
                        c = true;
                      photonView.RPC(nameof(Nothyozi), RpcTarget.All);
                        Invoke(nameof(NPCorikaesi), orikaesiwait);
                        speed = UnityEngine.Random.Range(1.0f, 2.0f);
                        orikaesiwait = UnityEngine.Random.Range(1.0f, 15.0f);
                    }
                    if (pointIdx < points.Count)
                    {
                        nextPos = points[pointIdx].position;
                    }
                    if (pointIdx == points.Count)
                    {
                     //  moveObj.SetActive(false);
                      photonView.RPC(nameof(Nothyozi), RpcTarget.All);
                        Invoke(nameof(NPCReset), waittime);
                        speed = UnityEngine.Random.Range(1.0f, 2.0f);
                        waittime = UnityEngine.Random.Range(1.0f, 15.0f);
                    }
                }
            }

            if (nowPos.x > maePos.x) { animator.SetFloat(idX, 1f); e = "right"; }
            if (nowPos.x == maePos.x&& nowPos.y != maePos.y)
            {
                switch (e)
                {
                    case "right":
                        animator.SetFloat(idX, 0.5f); break;
                    case "left":
                        animator.SetFloat(idX, -0.5f); break;
                    default:
                        animator.SetFloat(idX, 0); break;
                }
            }
            if (nowPos.x < maePos.x) { animator.SetFloat(idX, -1f); e = "left"; }
            if (nowPos.y < maePos.y) { animator.SetFloat(idY, -1f); e = "front"; }
            if (nowPos.y == maePos.y&& nowPos.x != maePos.x)
            {
                switch (e)
                {
                    case "front":
                        animator.SetFloat(idY, -0.5f); break;
                    case "back":
                        animator.SetFloat(idY, 0.5f); break;
                    default:
                        animator.SetFloat(idY, 0); break;
                }
            }
            if (nowPos.y == maePos.y && nowPos.x == maePos.x)
            {
               
            }
                if (nowPos.y > maePos.y) { animator.SetFloat(idY, 1f); e = "back"; }
            if (e != "right")
            {
                moveObj.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
    void NPCReset()
    {
      //  moveObj.SetActive(true);
       photonView.RPC(nameof(Hyozi), RpcTarget.All);
        moveObj.transform.position = points[0].position;
        points = new List<Transform>();
        points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        pointIdx = 1;
        nextPos = points[pointIdx].position;
    }
    void NPCorikaesi() {
       // moveObj.SetActive(true);
      photonView.RPC(nameof(Hyozi), RpcTarget.All);

        c = false;
    }
    private async void maepos(Vector3 vector3)
    {
        await Task.Delay(10);
        maePos = vector3;
    }
    [PunRPC]
   public void Hyozi()
    {
        
        moveObj.SetActive(true);
    }
    [PunRPC]
  public  void Nothyozi()
    {
        
        moveObj.SetActive(false);
    }
    
}