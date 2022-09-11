using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public float movingTime = 0.05f;
    public Vector2 targetWhenOn;
    public Vector2 targetWhenOff;
    private Vector2 target;
    private Vector2 velocity = Vector2.zero;
    private RectTransform rectTransform;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
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
        rectTransform.anchoredPosition = Vector2.SmoothDamp(rectTransform.anchoredPosition, target, ref velocity, movingTime);
    }
}
