using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPanelClose : MonoBehaviour
{
    public GameObject panel;
    public void OnClick(){
        panel.SetActive(false);
    }
}
