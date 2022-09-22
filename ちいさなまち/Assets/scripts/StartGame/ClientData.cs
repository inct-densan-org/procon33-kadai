using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientData : MonoBehaviour
{
    public GameObject[] characterButton;
    public AudioSource audioSource;

    public static int currentCharacter = 0;
    public static float bgmVolume = 0.5f;

    void Start(){
        audioSource.volume = bgmVolume;

        foreach (GameObject character in characterButton){
            character.transform.GetComponent<Toggle>().onValueChanged.AddListener(OnClick);
        }
    }

    //キャラクター選択ボタンが押された時currentCharacterを変更
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

    public void BGMVolume(float newSliderValue){
        bgmVolume = newSliderValue;
        audioSource.volume = bgmVolume;
    }
}
