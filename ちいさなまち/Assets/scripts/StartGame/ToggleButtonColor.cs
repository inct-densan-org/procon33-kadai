using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonColor : MonoBehaviour
{
    void Start(){
        transform.GetComponent<Toggle>().onValueChanged.AddListener(OnClick);
    }
    void OnClick(bool isOn){
        Image imageComponent = transform.GetComponent<Image>();

        if (isOn){
            imageComponent.color = new Color(0.8f, 0.8f, 0.8f, 1f);
        }else{
            imageComponent.color = new Color(1f, 1f, 1f, 1f);
        }

        //transform.parent.GetComponent<RoomList>().selectedButtonNum = transform.GetSiblingIndex();
    }
}
