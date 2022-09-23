using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class judgment : MonoBehaviour
{
    private Gameend gameend;
    public bool iswin;
    public string reason;
    public GameObject gameclear, gameover;
    public TextMeshProUGUI reasontext;
    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        gameclear.SetActive(false);
        iswin = Gameend.iswin;
        reason = Gameend.reason;
        if (iswin == true)
        {
            gameclear.SetActive(true);
        }
        else
        {
            gameover.SetActive(true);
            reasontext.text = reason;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
