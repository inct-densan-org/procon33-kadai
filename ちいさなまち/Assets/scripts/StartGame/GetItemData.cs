using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetItemData : MonoBehaviour
{
    /*
    public enum Place{
        drugstore,
		foodstore,
		restaurant,
		hospital,
    }
    */

    [SerializeField] private ItemDataBase itemDataBase;
    //[SerializeField] private Place place;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int skipChild = 1;
    public List<List<Item>> itemList = new List<List<Item>>();

    //public var drugstore = new List<item>;
    //public var foodStore = new List<item>;
    //public var restaurant = new List<item>;
    //public var hospital = new List<item>;
    private string outData;



    void Start(){
        for (int i = 0; i < 4; i++){
            itemList.Add(new List<Item>());
        }

        foreach (Item item in GetItem())
        {
            switch (item.GetKindOfItem().ToString()){
                case "drugstore":
                    itemList[0].Add(item);
                    break;
                case "foodstore":
                    itemList[1].Add(item);
                    break;
                case "restaurant":
                    itemList[2].Add(item);
                    break;
                case "hospital":
                    itemList[3].Add(item);
                    break;
            }

        }

        Debug.Log(itemList.Count);
        Debug.Log(itemList[0].Count);
        Debug.Log(itemList[1].Count);
        Debug.Log(itemList[2].Count);
        Debug.Log(itemList[3].Count);

        for(int i = skipChild; i < itemList.Count+skipChild; i++){
            foreach (var item in itemList[i-skipChild]){
                GameObject itemData = Instantiate(prefab, transform.position, Quaternion.identity);
                itemData.transform.SetParent(transform.GetChild(i), false);
                itemData.transform.GetChild(0).GetComponent<Image>().sprite = item.GetIcon();
                outData = $"{item.GetItemName()}\n　単価 : {item.Getmoney()}\n　{item.GetInformation().Replace("<br>", "<br>　")}\n";
                itemData.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = outData;
                //outData = $"{outData}\n・{item.GetItemName()}";
                //outData = $"{outData}\n　単価 : {item.Getmoney()}";
                //outData = $"{outData}\n　{item.GetInformation().Replace("<br>", "<br>　")}\n";
            }
        }
    }

    public List<Item> GetItem(){
        return itemDataBase.GetItemLists();
    }
}
