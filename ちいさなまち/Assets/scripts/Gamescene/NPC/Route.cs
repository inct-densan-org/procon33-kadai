using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] Transform moveObj;
    [SerializeField] float speed;
    List<Transform> points;
    int pointIdx = 0;
    Vector3 nextPos;

    void Start()
    {
        points = new List<Transform>();
        points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        nextPos = points[pointIdx].position;
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
    }
}