using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmPanel : MonoBehaviour
{
    public TextMeshProUGUI panelVariableText;
    public GameObject descObject;

    // Start is called before the first frame update
    public void Open()
    {
        GameObject Easy = descObject.transform.GetChild(0).gameObject;
        GameObject Normal = descObject.transform.GetChild(1).gameObject;
        GameObject Hard = descObject.transform.GetChild(2).gameObject;

        if (Easy.activeInHierarchy){
            panelVariableText.text = "イージー";
        }
        else if (Normal.activeInHierarchy){
            panelVariableText.text = "ノーマル";
        }
        else if(Hard.activeInHierarchy){
            panelVariableText.text = "ハード";
        }

        transform.gameObject.SetActive(true);
    }

    public void Close(){
        transform.gameObject.SetActive(false);
    }
}
