using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public GameObject scenes;
    public GameObject titleScene;
    public GameObject settingPlayerDataScene;
    public GameObject roomSelectorScene;
    public GameObject rulesScene;
    public GameObject settingsScene;
    public TextMeshProUGUI inputField;
    public TextMeshProUGUI playerNameOutput;



    void DisableAllScene(){
        foreach(Transform scene in scenes.transform){
            scene.gameObject.SetActive(false);
        }
    }

    public void GotoTitle(){
        DisableAllScene();
        titleScene.SetActive(true);
    }

    public void GotoSettingPlayerData(){
        DisableAllScene();
        settingPlayerDataScene.SetActive(true);
    }

    public void GotoRoomSelector(){
        DisableAllScene();

        //InputFieldに何も入れないと"ゼロ幅スペース"なるものが代入されている
        //ゼロ幅スペースは \u200b (char型だと8203)
        string playerName = inputField.text.Replace("\u200b", "");

        if (System.String.IsNullOrWhiteSpace(playerName)){
            playerName = "Player";
        }
        else{
            playerName = inputField.text.Replace(" ", "_");
            playerName =playerName.Replace("　", "_");
        }
        
        PhotonNetwork.NickName = playerName;
        playerNameOutput.text = $"プレイヤー名 : {PhotonNetwork.NickName}";
        roomSelectorScene.SetActive(true);
    }

    public void GotoRules(){
        DisableAllScene();
        rulesScene.SetActive(true);
    }

    public void GotoSettings(){
        DisableAllScene();
        settingsScene.SetActive(true);
    }
}
