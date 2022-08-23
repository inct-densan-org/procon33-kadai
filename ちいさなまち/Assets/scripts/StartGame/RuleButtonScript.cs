using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleButtonScript : MonoBehaviour
{
    public GameObject rules;

    public void OnClick()
    {
        foreach (Transform rule in rules.transform){
            rule.gameObject.SetActive(false);
        }

        int mySelfIndex = transform.GetSiblingIndex();
        Debug.Log(mySelfIndex);
        Transform targetRule = rules.transform.GetChild(mySelfIndex);
        targetRule.gameObject.SetActive(true);
    }
}
