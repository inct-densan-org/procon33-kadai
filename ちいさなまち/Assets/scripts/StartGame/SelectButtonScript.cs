using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButtonScript : MonoBehaviour
{
    [System.NonSerialized]
    public GameObject changeTarget;

    public void OnClick()
    {
        foreach (Transform childObject in changeTarget.transform){
            childObject.gameObject.SetActive(false);
        }

        int mySelfIndex = transform.GetSiblingIndex();
        Transform target = changeTarget.transform.GetChild(mySelfIndex);
        target.gameObject.SetActive(true);
    }
}
