using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

public class Menumanager : MonoBehaviour
{
    [SerializeField]
    private QuestDataBase QuestDataBase;
    public GameObject menu, messegedis;
    public static string menuKey;
    public TextMeshProUGUI mesasege, warning;

    [SerializeField] private ItemDataBase itemDataBase;
    public string menuKeysee;
    private string ItemName;
    private Infection2 infection2;
    private Watergaugemanager watergaugemanager;
    private Foodgaugemanager foodgaugemanager;
    private Move move;
    private TasManager tasManager;
    private int questnum;
    [SerializeField]
    GameObject iconPrefab = null;
    [SerializeField]
    Transform iconParent = null;
    private GameObject button_ob;
    bool[] itemFlags;
    [SerializeField] private EventSystem eventSystem;
    Dictionary<int, GameObject> icons = new Dictionary<int, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        itemFlags = new bool[itemDataBase.GetItemLists().Count];
    }
    int Index(string itemName)
    {
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            if (itemName == itemDataBase.GetItemLists()[i].GetItemName())
            {
                return i;
            }
        }
        return 0;
    }
    public void makeicon(string itemName)
    {
        int index = Index(itemName);
        GameObject icon = Instantiate(iconPrefab, iconParent);
        icon.GetComponent<Image>().sprite = GetItem(itemName).GetIcon();
        icon.GetComponent<Button>().onClick.AddListener(onPush);

        icon.name = itemName;
        icons.Add(index, icon);
    }
    public void destroyicon(string itemName)
    {
        var i = Index(itemName);
        GameObject icon = icons[i];
        // アイテムのアイコンを削除
        Destroy(icon);
        // アイコンのディクショナリから対象のアイテムを削除
        icons.Remove(i);
    }

    // Update is called once per frame
    void Update()
    {
        questnum = TasManager.Questnum;
        menuKeysee = menuKey;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (menuKey)
            {
                case "menu":
                    menu.SetActive(false);
                    menuKey = null;
                    break;

                case null:
                    menu.SetActive(true);
                    menuKey = "menu";
                    break;
            }

        }
    }
    public void onPush()
    {
        messegedis.SetActive(true);
        button_ob = eventSystem.currentSelectedGameObject;

        ItemName = button_ob.name;
        
        mesasege.text = GetItem(ItemName).GetItemName() + "\n" + GetItem(ItemName).GetInformation() + "\n" + "を使用しますか？";
    }


    public void Onno() { messegedis.SetActive(false); }

    public async void Onyes()
    {
        if (menuKey == "menu")
        {

            if (ItemName == "マスク" && GetItem(ItemName).Getkosuu() > 0)
            {
                itemDataBase.GetItemLists()[0].Setkosuu(-1);
                Infection2.ismask = true;
                messegedis.SetActive(false);
            }
            if (GetItem(ItemName).Getkosuu() == 0)
            {
                warning.text = "アイテムがありません";
                Invoke(nameof(Delwarning), 3);
            }
            if (ItemName == "おにぎり" && GetItem(ItemName).Getkosuu() > 0)
            {
                Foodgaugemanager.Setfood(20);
                itemDataBase.GetItemLists()[3].Setkosuu(-1);
                messegedis.SetActive(false);
            }
            if (ItemName == "お茶" && GetItem(ItemName).Getkosuu() > 0)
            {
                Watergaugemanager.Setwater(20);
                itemDataBase.GetItemLists()[2].Setkosuu(-1);
                messegedis.SetActive(false);
            }
            if (ItemName == "普通の薬" && GetItem(ItemName).Getkosuu() > 0)
            {
                Move.isdurk = true;

                itemDataBase.GetItemLists()[1].Setkosuu(-1);
                messegedis.SetActive(false);
                await Task.Delay(10000);
                Move.Effecttime();
            }
        }

        if (menuKey == "quest")
        {
            for (int i = 0; i < QuestDataBase.GetQusetLists().Count; i++)
            {
                if (QuestDataBase.GetQusetLists()[i].GetNumber() == questnum)
                {
                    QuestDataBase.GetQusetLists()[i].SetIsQuest(true);
                }
            }
            messegedis.SetActive(false);
        }//yesおしたらそのクエストのisQuestをオンにしたい

    }
    void Delwarning() { warning.text = null; }
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}