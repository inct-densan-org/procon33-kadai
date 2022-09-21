using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientData : MonoBehaviour
{
    public GameObject[] characterButton;

    public static int currentCharacter = 0;

    void Start(){
        foreach (GameObject character in characterButton){
            character.transform.GetComponent<Toggle>().onValueChanged.AddListener(OnClick);
        }
    }

    public void OnClick(bool isOn){
        if (isOn){
            for (int i = 0; i < characterButton.Length; i++){
                if (characterButton[i].transform.GetComponent<Toggle>().isOn){
                    currentCharacter = i;
                    break;
                }
            }
        }
    }
}
