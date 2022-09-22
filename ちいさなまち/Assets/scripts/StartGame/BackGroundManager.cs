using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public float movingTime = 0.1f;
    public Sprite[] images;
    List<Sprite> shuffle = new List<Sprite>();

    Image background;
    RectTransform rectTransform;
    Vector2 from, target, velocity = Vector2.zero;
    int randomNum;


    void Start()
    {
        Vector3 scale;
        scale.x = 1.5f;
        scale.y = 1.5f;
        scale.z = 1f;
        transform.localScale = scale;

        background = transform.GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Update(){
        if(Vector2.Distance(rectTransform.anchoredPosition, target) < 1){
            ChangeImage();
        }
        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, target, movingTime);
    }

    void ChangeImage(){
        if(shuffle.Count < 1){
            foreach(Sprite image in images){
                shuffle.Add(image);
            }
        }
        randomNum = Random.Range(0,shuffle.Count);
        background.sprite = shuffle[randomNum];
        shuffle.RemoveAt(randomNum);

        Move();
    }

    void Move(){
        float width = rectTransform.sizeDelta.x;
        width *= 0.25f;
        float height = rectTransform.sizeDelta.y;
        height *= 0.25f;

        from = new Vector2(Random.Range(width*-1, width) , Random.Range(height*-1, height));
        target = new Vector2(Random.Range(width*-1, width) , Random.Range(height*-1, height));
        while (Vector2.Distance(from, target) < 300){
            from = new Vector2(Random.Range(width*-1, width) , Random.Range(height*-1, height));
            target = new Vector2(Random.Range(width*-1, width) , Random.Range(height*-1, height));
        }
        rectTransform.anchoredPosition = from;
    }
}
