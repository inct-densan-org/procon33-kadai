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
    [SerializeField] float speed=1;
    public int orikaesi;
   public List<Transform> points;
   public int pointIdx = 0;
    Vector3 nextPos;
    public Vector3 nowPos, maePos;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y");
    private Animator animator = null;
    public string e;
    private bool b,c;
    void Start()
    {
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
           if(b==false) moveObj.transform.position = points[0].position;b = true;
            nowPos = moveObj.transform.position;
            var a = moveObj.transform.position;
            maepos(a);
            if ((nextPos - moveObj.transform.position).sqrMagnitude > Mathf.Epsilon)
            {
                moveObj.transform.position = Vector3.MoveTowards(moveObj.transform.position, nextPos, speed * Time.deltaTime);
            }
            else
            {
                pointIdx++;

               
                if (pointIdx == orikaesi) { moveObj.SetActive(false); 
                    Invoke(nameof(NPCorikaesi), 3f); }
                if (pointIdx < points.Count&&c==false)
                {
                    nextPos = points[pointIdx].position;
                }
                if (pointIdx == points.Count)
                {
                    moveObj.SetActive(false);c = true;
                    Invoke(nameof(NPCReset), 3f);
                }

            }
            if (nowPos.x > maePos.x) { animator.SetFloat(idX, 1f); e = "right"; }
            if (nowPos.x == maePos.x)
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
            if (nowPos.y == maePos.y)
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
            if (nowPos.y > maePos.y) { animator.SetFloat(idY, 1f); e = "back"; }
        }
         
    }
    void NPCReset()
    {

        moveObj.SetActive(true);

        moveObj.transform.position = points[0].position;
        points = new List<Transform>();
        points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        pointIdx = 1;
        nextPos = points[pointIdx].position;

    }
    void NPCorikaesi() {
        moveObj.SetActive(true);

        //moveObj.transform.position = points[orikaesi].position;
        //points = new List<Transform>();
        //points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        //pointIdx =orikaesi+ 1;
        //nextPos = points[pointIdx].position;
        c = false;
    }
    private void FixedUpdate()
    {
        

    }
    private async void maepos(Vector3 vector3)
    {
        await Task.Delay(100);
        maePos = vector3;
    } 
}