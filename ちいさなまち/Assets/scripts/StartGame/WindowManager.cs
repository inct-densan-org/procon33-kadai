using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    private GameObject menuButton;
    private GameObject title;
    private GameObject windows;
    private GameObject roomSelector;
    private GameObject rules;
    private GameObject settings;

    public static WindowManager instance;

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start(){
        menuButton = transform.Find("MenuButton").gameObject;
        title = transform.Find("Title").gameObject;

        windows = transform.Find("Windows").gameObject;
        roomSelector= windows.transform.Find("RoomSelector").gameObject;
        rules= windows.transform.Find("Rules").gameObject;
        settings = windows.transform.Find("Settings").gameObject;

    }

    void DisableAllWindow(){
        roomSelector.SetActive(false);
        rules.SetActive(false);
        settings.SetActive(false);
    }

    void MenuButton(bool isOn){
        menuButton.GetComponent<MoveAnimation>().Move(isOn);
        title.GetComponent<MoveAnimation>().Move(isOn);
    }

    void Windows(int status){
        windows.SetActive(true);
        windows.GetComponent<ChangeScale>().Move(status);

    }

    //以下画面遷移
    public void Title(){
        MenuButton(true);
        DisableAllWindow();
        Windows(0);
    }

    public void RoomSelector(){
        MenuButton(false);
        DisableAllWindow();
        roomSelector.SetActive(true);
        Windows(1);
    }

    public void Rules(){
        MenuButton(false);
        DisableAllWindow();
        rules.SetActive(true);
        Windows(2);
    }

    public void Settings(){
        MenuButton(false);
        DisableAllWindow();
        settings.SetActive(true);
        Windows(3);
    }
}
