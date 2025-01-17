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
    public GameObject menu, messegedis,itemdis,yesbutton,questback;
    public static string menuKey;
    public TextMeshProUGUI mesasege, warning;

    [SerializeField] private ItemDataBase itemDataBase;
    public string menuKeysee;
    private string ItemName;
    private Infection2 infection2;
    private Gaugemanager gaugemanager;
    private bool  kanpou, goodkanpou, greatkanpou;
    private Move move;
    private TasManager tasManager;
    private int questnum;
    public bool KANPOU;
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
                    itemdis.SetActive(false);
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
        warning.text = null;
        if (GetItem(ItemName).GetKindOfItem().ToString() == "quest")
        {
            mesasege.text = GetItem(ItemName).GetItemName() + "\n" + GetItem(ItemName).GetInformation() + "\n";
            yesbutton.SetActive(false);
        }
        else
        {
            mesasege.text = GetItem(ItemName).GetItemName() + "\n" + GetItem(ItemName).GetInformation() + "\n" + "を使用しますか？";
            yesbutton.SetActive(true);
        }
       
    }


    public void Onno()
    { messegedis.SetActive(false);
        if (menuKey == "quest")
        {
            questback.SetActive(true);
        }
        
    }

    public async void Onyes()
    {

        if (menuKey == "menu")
        {
            infection2 = GameObject.FindGameObjectsWithTag("Player")[0].gameObject.GetComponent<Infection2>();
            move = GameObject.FindGameObjectsWithTag("Player")[0].gameObject.GetComponent<Move>();
            if (GetItem(ItemName).Getkosuu() == 0)
            {
                warning.text = "アイテムがありません";
                Invoke(nameof(Delwarning), 3);
            }
            else if (ItemName != null && GetItem(ItemName).Getkosuu() > 0)
            {

                if (infection2.GetPlayerinfeffect(PhotonNetwork.LocalPlayer.ActorNumber) == true && KANPOU == false)
                {
                    if (GetItem(ItemName).GetEatWhenInfected() == true)
                    {
                        gaugemanager.Setfood(GetItem(ItemName).Getfoodrecovery());
                        gaugemanager.SetWater(GetItem(ItemName).Getwaterrecovery());

                        if (GetItem(ItemName).Getother_effect())
                        {
                            if (ItemName == "マスク" && infection2.ismask == false)
                            {
                                infection2.ismask = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                Debug.Log(infection2.ismask);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
                                infection2.ismask = false;
                                Debug.Log(infection2.ismask);
                            }
                            if (ItemName == "マスク" && infection2.ismask == true || ItemName == "普通のせき止め" && infection2.kanpou == true || ItemName == "すごくいいせき止め" && infection2.greatkanpou == false || ItemName == "いいせき止め" && infection2.goodkanpou == false || ItemName == "いい解熱剤" && move.iikai == false || ItemName == "普通の解熱剤" && move.kai == false || ItemName == "すごくいい解熱剤" && move.sugoikai == false)
                            {
                                warning.text = "効果は続いています";
                                Invoke(nameof(Delwarning), 3);
                            }

                            if (ItemName == "普通のせき止め" && infection2.kanpou == false)
                            {
                                infection2.kanpou = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
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
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);

                                infection2.greatkanpou = false;
                            }
                            if (ItemName == "漢方" && KANPOU == false)
                            {
                                KANPOU = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
                                KANPOU = false;
                            }
                            if (ItemName == "いい解熱剤" && move.iikai == false)
                            {
                                move.iikai = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);

                                move.iikai = false;
                            }
                            if (ItemName == "普通の解熱剤" && move.kai == false)
                            {
                                move.kai = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);

                                move.kai = false;
                            }
                            if (ItemName == "すごくいい解熱剤" && move.sugoikai == false)
                            {
                                move.sugoikai = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);

                                move.sugoikai = false;
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
                if (infection2.GetPlayerinfeffect(PhotonNetwork.LocalPlayer.ActorNumber) == true && KANPOU == true)
                {//感染していて漢方飲んだ時

                    if (GetItem(ItemName).GetEatWhenInfected() == true)
                    {
                        gaugemanager.Setfood(GetItem(ItemName).Getfoodrecovery());
                        gaugemanager.SetWater(GetItem(ItemName).Getwaterrecovery());

                        if (GetItem(ItemName).Getother_effect())
                        {

                            if (ItemName == "マスク" && infection2.ismask == false)
                            {
                                infection2.ismask = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                Debug.Log(infection2.ismask);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
                                infection2.ismask = false;
                                Debug.Log(infection2.ismask);
                            }
                            if (ItemName == "マスク" && infection2.ismask == true || ItemName == "普通のせき止め" && infection2.kanpou == true || ItemName == "すごくいいせき止め" && infection2.greatkanpou == true || ItemName == "いいせき止め" && infection2.goodkanpou == true || ItemName == "いい解熱剤" && move.iikai == true || ItemName == "普通の解熱剤" && move.kai == true || ItemName == "すごくいい解熱剤" && move.sugoikai == true || ItemName == "漢方" && KANPOU == true)
                            {
                                warning.text = "効果は続いています";
                                Invoke(nameof(Delwarning), 3);
                            }

                            if (ItemName == "普通のせき止め" && infection2.kanpou == false)
                            {
                                infection2.kanpou = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
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
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);

                                infection2.greatkanpou = false;
                            }

                            if (ItemName == "いい解熱剤" && move.iikai == false)
                            {
                                move.iikai = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);

                                move.iikai = false;
                            }
                            if (ItemName == "普通の解熱剤" && move.kai == false)
                            {
                                move.kai = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);

                                move.kai = false;
                            }
                            if (ItemName == "すごくいい解熱剤" && move.sugoikai == false)
                            {
                                move.sugoikai = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);

                                move.sugoikai = false;
                            }
                        
                        }
                    }
                }
                else//感染してないとき
                {
                    if (ItemName == "普通のせき止め" || ItemName == "いいせき止め" || ItemName == "すごくいいせき止め" || ItemName == "漢方" || ItemName == "すごくいい解熱剤" || ItemName == "いい解熱剤" || ItemName == "普通の解熱剤")
                    {
                        warning.text = "感染してないため使えません";
                    }
                    else
                    {
                        gaugemanager.Setfood(GetItem(ItemName).Getfoodrecovery());
                        gaugemanager.SetWater(GetItem(ItemName).Getwaterrecovery());
                        
                        messegedis.SetActive(false);
                        if (GetItem(ItemName).Getother_effect())
                        {
                            if (ItemName == "マスク" && infection2.ismask == true)
                            {
                                warning.text = "効果は続いています";
                                Invoke(nameof(Delwarning), 3);
                            }
                            if (ItemName == "マスク" && infection2.ismask == false)
                            {
                                infection2.ismask = true;
                                GetItem(ItemName).Setkosuu(-1);
                                messegedis.SetActive(false);
                                Debug.Log(infection2.ismask);
                                await Task.Delay(GetItem(ItemName).Geteffecttime() * 1000);
                                infection2.ismask = false;
                                Debug.Log(infection2.ismask);



                            }
                        }
                        else
                        {
                            GetItem(ItemName).Setkosuu(-1);
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
                questback.SetActive(true);
                messegedis.SetActive(false);
            }//yesおしたらそのクエストのisQuestをオンにしたい
        
    }
    
    void Delwarning() { warning.text = null; }
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
    public void ONPUSHmodoru()
    {
        menu.SetActive(false);
        itemdis.SetActive(false);
        menuKey = null;
        warning.text = null;
    }
}