using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class menumanager : MonoBehaviour
{
    public GameObject menu ,gezi;
    public static bool ismenu;
    public TextMeshProUGUI k1,k2,k3,k4;
    public Image icon1,icon2,icon3,icon4;
    [SerializeField] private ItemDataBase itemDataBase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ismenu)
        {
            icon1.sprite = itemDataBase.GetItemLists()[0].GetIcon();
            icon2.sprite = itemDataBase.GetItemLists()[1].GetIcon();
            icon3.sprite = itemDataBase.GetItemLists()[2].GetIcon();
            icon4.sprite = itemDataBase.GetItemLists()[3].GetIcon();
            k1.text = $"{itemDataBase.GetItemLists()[0].Getkosuu()}";
            k2.text = $"{itemDataBase.GetItemLists()[1].Getkosuu()}";
            k3.text = $"{itemDataBase.GetItemLists()[2].Getkosuu()}";
            k4.text = $"{itemDataBase.GetItemLists()[3].Getkosuu()}";
        }
        var isshop = shopmanager.isshop;
        if (Input.GetKeyDown(KeyCode.Escape)&&isshop==false)
        {
            if (ismenu == false)
            {
                menu.SetActive(true);
                ismenu = true;
            }
            else
            {
                menu.SetActive(false);
                ismenu = false;
            }
        }
    }
}
