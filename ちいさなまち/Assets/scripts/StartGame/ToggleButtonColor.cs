using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonColor : MonoBehaviour
{
    public Color on = new Color(0.8f, 0.8f, 0.8f, 1f);
    public Color off = new Color(1f, 1f, 1f, 1f);

    void Start(){
        GetComponent<Toggle>().onValueChanged.AddListener(OnClick);
    }
    public void OnClick(bool isOn){
        Image imageComponent = GetComponent<Image>();

        if (isOn){
            imageComponent.color = on;
        }else{
            imageComponent.color = off;
        }

        //transform.parent.GetComponent<RoomList>().selectedButtonNum = transform.GetSiblingIndex();
    }
}
