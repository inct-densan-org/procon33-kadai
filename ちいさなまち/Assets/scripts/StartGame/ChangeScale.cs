using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    public float movingTime = 0.05f;
    public Vector2 targetWhenOn;
    public Vector2 targetWhenOff;
    private Vector2 target;
    private Vector2 velocity = Vector2.zero;

    void Awake()
    {
        target = targetWhenOn;
    }

    public void Move(bool isOn)
    {
        if (isOn){
            target = targetWhenOn;
        }else{
            target = targetWhenOff;
        }

    }
    void Update()
    {
        float scaleX = Mathf.SmoothDamp(transform.localScale.x, target.x, ref velocity.x, movingTime);
        float scaleY = Mathf.SmoothDamp(transform.localScale.y, target.y, ref velocity.y, movingTime);
        transform.localScale = new Vector2(scaleX, scaleY);
    }
}
