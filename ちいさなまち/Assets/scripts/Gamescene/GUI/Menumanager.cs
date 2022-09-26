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
    private bool KANPOU, kanpou, goodkanpou, greatkanpou;
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
        
        icon.GetComponent<Button>().onClick.AddListener(onPush);
        GameObject kosuutext= icon.transform.GetChild(0).gameObject;
        kosuutext.name = itemName;
        GameObject iconsprite = icon.transform.GetChild(1).gameObject;
        iconsprite.GetComponent<Image>().sprite = GetItem(itemName).GetIcon();
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
                if (infection2.GetPlayerinf(PhotonNetwork.LocalPlayer.ActorNumber) == true&&KANPOU==false)
                {
                    if (GetItem(ItemName).GetEatWhenInfected() == true)
                    {
                        gaugemanager.Setfood(GetItem(ItemName).Getfoodrecovery());
                        gaugemanager.SetWater(GetItem(ItemName).Getwaterrecovery());
                        
                        if (GetItem(ItemName).Getother_effect())
                        {
                            if (ItemName == "マスク"&& infection2.ismask ==false)
                            {
                                infection2.ismask = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
                                infection2.ismask = false;
                                
                            }
                            if (ItemName == "マスク" && infection2.ismask == true||ItemName== "普通のせき止め" && infection2.kanpou == true|| ItemName == "すごくいいせき止め" && infection2.greatkanpou == false|| ItemName == "いいせき止め" && infection2.goodkanpou == false)
                            {
                                warning.text="効果は続いています";
                                Invoke(nameof(Delwarning), 3);
                            }
                            
                            if (ItemName == "普通のせき止め" && infection2.kanpou == false)
                            {
                                infection2.kanpou = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime()*1000);
                                infection2.kanpou = false;
                                
                            }
                            if (ItemName == "いいせき止め" && infection2.goodkanpou == false)
                            {
                                infection2.goodkanpou = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
                                infection2.goodkanpou = false;
                                
                            }
                            if (ItemName == "すごくいいせき止め" && infection2.greatkanpou == false)
                            {
                                infection2.greatkanpou = true;
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                infection2.greatkanpou = false;
                                
                            }
                            if (ItemName == "漢方" && KANPOU==false)
                            {
                                KANPOU = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
                                KANPOU = false;
                                
                            }
                        }
                        else
                        {
                            GetItem(ItemName).Setkosuu(-1);
                            messegedis.SetActive(false);
                        }
                        
                        
                    }
                    else
                    {
                        warning.text = "感染してるため使うことが出来ません";
                        Invoke(nameof(Delwarning), 3);
                    }
                }
                else//感染してないとき
                {
                    if (ItemName == "普通のせき止め" || ItemName == "いいせき止め" || ItemName == "すごくいいせき止め"||ItemName=="漢方")
                    {
                        warning.text = "感染してないため使えません";
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
                                infection2.ismask = true;
                            }


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