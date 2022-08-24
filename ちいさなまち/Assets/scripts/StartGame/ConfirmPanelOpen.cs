using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmPanelOpen : MonoBehaviour
{
    public GameObject descEasy;
    public GameObject descNormal;
    public GameObject descHard;
    public GameObject confirmPanel;
    public TextMeshProUGUI panelVariableText;

    // Start is called before the first frame update
    public void OnClick()
    {
        confirmPanel.SetActive(true);

        Debug.Log(panelVariableText.text);
        if (descEasy.activeInHierarchy){
            panelVariableText.text = "イージー";
        }
        else if (descNormal.activeInHierarchy){
            panelVariableText.text = "ノーマル";
        }
        else if(descHard.activeInHierarchy){
            panelVariableText.text = "ハード";
        }
    }
}
