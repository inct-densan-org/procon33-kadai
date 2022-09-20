using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    public float movingTime = 0.05f;
    public float[] widthTargets = new float[4];
    private RectTransform rectTransform;
    private float scaleYTarget;
    private Vector2 velocity = Vector2.zero;

    void Awake() {
        rectTransform = GetComponent<RectTransform>();
        scaleYTarget = 0f;
    }

    public void Move(int status)
    {
        //非表示0, サーバーセレクター1, ルール2, 設定3
        if (status > 0){
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, widthTargets[status]);
            scaleYTarget = 1;
        }else{
            scaleYTarget = 0;
        }
    }
    void Update()
    {

        float scaleY = Mathf.SmoothDamp(transform.localScale.y, scaleYTarget, ref velocity.y, movingTime);
        transform.localScale = new Vector2(1f, scaleY);
    }
}
