using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        var byou = gameObject.AddComponent<Reitenitibyou>();
         byou.Init(() =>
        {
            maePos = moveObj.transform.position;
           
        });
        byou.Play();
        }

    


void Update()
    {

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
        if (nowPos.x > maePos.x) { animator.SetFloat(idX, 1f); animator.SetFloat(idY, 0); }
        if (nowPos.x < maePos.x) { animator.SetFloat(idX, -1f); animator.SetFloat(idY, 0); }
        if (nowPos.y < maePos.x) { animator.SetFloat(idY, -1f); animator.SetFloat(idX, 0); }
        if (nowPos.y < maePos.x) { animator.SetFloat(idY, 1f); animator.SetFloat(idX, 0); }
    }
    private void FixedUpdate()
    {
        nowPos =moveObj. transform.position;

    }

}