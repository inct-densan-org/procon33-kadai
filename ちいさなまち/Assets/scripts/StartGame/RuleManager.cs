using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RuleManager : MonoBehaviour
{
    public GameObject listButtonPrefab;
    public GameObject scrollViewContent;

    void Start(){
        for (int i = 0; i < transform.childCount; i++){
            GameObject button = Instantiate(listButtonPrefab, this.transform.position, Quaternion.identity);
            button.transform.SetParent(scrollViewContent.transform, false);
            button.transform.GetComponent<SelectButtonScript>().changeTarget = gameObject;

            Transform child = transform.GetChild(i);
            button.name = child.name;
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = child.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        }
    }
}
