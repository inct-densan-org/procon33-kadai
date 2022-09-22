using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Itemnum : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemDataBase;
    private GameObject kosuu;
    private TextMeshProUGUI kosuutext;
    private string itemName;
    // Start is called before the first frame update
    void Start()
    {
        kosuu = this.gameObject;
      kosuutext=  kosuu.GetComponent<TextMeshProUGUI>();
        itemName = kosuu.name;
    }

    // Update is called once per frame
    void Update()
    {
        kosuutext.text = $"{GetItem(itemName).Getkosuu()}";
    }
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
