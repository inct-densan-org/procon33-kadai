using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject scenes;
    public GameObject titleScene;
    public GameObject selectingDifficultyScene;
    public GameObject rulesScene;
    public GameObject settingsScene;



    void DisableAllScene(){
        foreach(Transform scene in scenes.transform){
            scene.gameObject.SetActive(false);
        }
    }

    public void GotoTitle(){
        DisableAllScene();
        titleScene.SetActive(true);
    }

    public void GotoSelectingDifficulty(){
        DisableAllScene();
        selectingDifficultyScene.SetActive(true);
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
