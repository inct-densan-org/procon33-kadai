using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    void Start(){
        transform.GetComponent<Toggle>().onValueChanged.AddListener(OnClick);
    }
    void OnClick(bool isOn){
        Debug.Log(isOn);
    }
}
