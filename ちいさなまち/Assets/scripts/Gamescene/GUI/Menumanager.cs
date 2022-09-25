using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using Photon.Pun;

public class Menumanager : MonoBehaviourPunCallbacks
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
    private Gaugemanager gaugemanager;
    
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
        
        menuKey = null;
        itemFlags = new bool[itemDataBase.GetItemLists().Count];
        gaugemanager = GameObject.Find("menumaneger").GetComponent<Gaugemanager>();
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
        GameObject kosuutext= icon.transform.GetChild(0).gameObject;
        kosuutext.name = itemName;
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
            infection2 = GameObject.FindGameObjectsWithTag("Player")[0].gameObject.GetComponent<Infection2>();
            if (GetItem(ItemName).Getkosuu() == 0)
            {
                warning.text = "アイテムがありません";
                Invoke(nameof(Delwarning), 3);
            }
            else if(ItemName != null&& GetItem(ItemName).Getkosuu() > 0)
            {
                if (infection2.GetPlayerinf(PhotonNetwork.LocalPlayer.ActorNumber) == true)
                {
                    if (GetItem(ItemName).GetEatWhenInfected() == true)
                    {
                        gaugemanager.Setfood(GetItem(ItemName).Getfoodrecovery());
                        gaugemanager.SetWater(GetItem(ItemName).Getwaterrecovery());
                        GetItem(ItemName).Setkosuu(-1);
                        messegedis.SetActive(false);
                        if (GetItem(ItemName).Getother_effect())
                        {
                            if (ItemName == "マスク")
                            {
                                Infection2.ismask = true;
                            }
                            if (ItemName == "普通の薬")
                            {
                                Move.isdurk = true;
                                await Task.Delay(10000);
                                Move.Effecttime();
                            }
                        }
                    }
                    else
                    {
                        warning.text = "感染してるため使うことが出来ません";
                        Invoke(nameof(Delwarning), 3);
                    }
                }
                else
                {
                    gaugemanager.Setfood(GetItem(ItemName).Getfoodrecovery());
                    gaugemanager.SetWater(GetItem(ItemName).Getwaterrecovery());
                    GetItem(ItemName).Setkosuu(-1);
                    messegedis.SetActive(false);
                    if (GetItem(ItemName).Getother_effect())
                    {
                        if (ItemName == "マスク")
                        {
                            Infection2.ismask = true;
                        }
                        if (ItemName == "普通の薬")
                        {
                            Move.isdurk = true;
                            await Task.Delay(10000);
                            Move.Effecttime();
                        }
                    }
                }
                
                
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