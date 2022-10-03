using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
public class Settingmanager : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputField;
    public GameObject SettingSence,Camera,menu, slider;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<TMP_InputField>();
        AudioSource = Camera.gameObject.GetComponent<AudioSource>();
        AudioSource.volume = ClientData.bgmVolume;
        slider.GetComponent<Slider>().value = ClientData.bgmVolume;
        
    }
    public void OnPushsetting()
    {
        menu.SetActive(false);
        SettingSence.SetActive(true);
        Menumanager.menuKey = "Setting";
        inputField.text = null;
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
        ClientData.bgmVolume = newSliderValue;
        AudioSource.volume = ClientData.bgmVolume;
    }
    public void changename()
    {
        PhotonNetwork.LocalPlayer.NickName = $"{inputField.text}";
    }
}
