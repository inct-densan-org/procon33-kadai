using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;
public class Route : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform moveObj;
    [SerializeField] float speed;
    List<Transform> points;
    int pointIdx = 0;
    Vector3 nextPos;
    public Vector3 nowPos, maePos;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y");
    private Animator animator = null;
    public string e;
    void Start()
    {
        points = new List<Transform>();
        points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        nextPos = points[pointIdx].position;
        animator = moveObj.  GetComponent<Animator>();
        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];
        if (p1 == PhotonNetwork.LocalPlayer) moveObj.transform.position = points[0].position;


    }




    void Update()
    {
        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];
        if (p1 == PhotonNetwork.LocalPlayer)
        {
            nowPos = moveObj.transform.position;
            var a = moveObj.transform.position;
            maepos(a);
            if ((nextPos - moveObj.position).sqrMagnitude > Mathf.Epsilon)
            {
                moveObj.position = Vector3.MoveTowards(moveObj.position, nextPos, speed * Time.deltaTime);
            }
            else
            {
                pointIdx++;

                if (pointIdx < points.Count)
                {
                    nextPos = points[pointIdx].position;
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
    private void FixedUpdate()
    {
        

    }
    private async void maepos(Vector3 vector3)
    {
        await Task.Delay(100);
        maePos = vector3;
    } 
}