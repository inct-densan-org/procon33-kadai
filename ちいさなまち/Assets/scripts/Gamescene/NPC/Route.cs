using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] Transform moveObj;
    [SerializeField] float speed;
    List<Transform> points;
    int pointIdx = 0;
    Vector3 nextPos;
    public Vector3 nowPos, maePos;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y");
    private Animator animator = null;
    void Start()
    {
        points = new List<Transform>();
        points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        nextPos = points[pointIdx].position;
        animator = moveObj.  GetComponent<Animator>();
        moveObj.transform.position = points[0].position;
       
    }




    void Update()
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
        if (nowPos.x > maePos.x) { animator.SetFloat(idX, 1f); }
        if (nowPos.x == maePos.x) { animator.SetFloat(idX, 0); }
        if (nowPos.x < maePos.x) { animator.SetFloat(idX, -1f); }
        if (nowPos.y < maePos.y) { animator.SetFloat(idY, -1f);  }
        if (nowPos.y == maePos.y) { animator.SetFloat(idY, 0);  }
        if (nowPos.y > maePos.y) { animator.SetFloat(idY, 1f);  }
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