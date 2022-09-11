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

    void Start(){
        menuButton = transform.Find("MenuButton").gameObject;
        title = transform.Find("Title").gameObject;

        windows = transform.Find("Windows").gameObject;
        roomSelector= windows.transform.Find("RoomSelector").gameObject;
        rules= windows.transform.Find("Rules").gameObject;
        settings = windows.transform.Find("Settings").gameObject;

    }

    void DisableAllWindow(){
        windows.GetComponent<ChangeScale>().Move(false);
        roomSelector.SetActive(false);
        rules.SetActive(false);
        settings.SetActive(false);
    }

    void MenuButton(bool isOn){
        menuButton.GetComponent<MoveAnimation>().Move(isOn);
        title.GetComponent<MoveAnimation>().Move(isOn);
    }

    void Windows(bool isOn){
        windows.SetActive(isOn);
        windows.GetComponent<ChangeScale>().Move(isOn);
    }

    //以下画面遷移
    public void Title(){
        MenuButton(true);
        DisableAllWindow();
    }

    public void RoomSelector(){
        MenuButton(false);
        DisableAllWindow();
        roomSelector.SetActive(true);
        Windows(true);
    }

    public void Rules(){
        MenuButton(false);
        DisableAllWindow();
        rules.SetActive(true);
        Windows(true);
    }

    public void Settings(){
        MenuButton(false);
        DisableAllWindow();
        settings.SetActive(true);
        Windows(true);
    }
}
