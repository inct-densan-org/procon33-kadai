using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
public class Settingmanager : MonoBehaviourPunCallbacks
{
    public GameObject SettingSence,Camera,menu;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = Camera.gameObject.GetComponent<AudioSource>();
        AudioSource.volume = 0.25f;
    }
    public void OnPushsetting()
    {
        menu.SetActive(false);
        SettingSence.SetActive(true);
        Menumanager.menuKey = "Setting";
    }
    public void OnPushBack()
    {
        menu.SetActive(true);
        SettingSence.SetActive(false);
        Menumanager.menuKey = "menu";
    }
    public void SoundSliderOnValueChange(float newSliderValue)
    {
        // ���y�̉��ʂ��X���C�h�o�[�̒l�ɕύX
        AudioSource.volume = newSliderValue;
    }
}
