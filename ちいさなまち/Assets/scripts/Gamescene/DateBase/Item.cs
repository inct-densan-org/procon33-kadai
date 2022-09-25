

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{

	public enum KindOfItem
	{
		drugstore,
		foodstore,
		restaurant,
		hospital,        
	}

	//�@�A�C�e���̎��
	[SerializeField]
	private KindOfItem kindOfItem;
	//�@�A�C�e���̃A�C�R��
	[SerializeField]
	private Sprite icon;
	//�@�A�C�e���̖��O
	[SerializeField]
	private string itemName;
	//�@�A�C�e���̏��
	[SerializeField]
	private string information;
	
	[SerializeField]
	private int money;
	[SerializeField]
	private int kosuu;
	[SerializeField]
	private int waterrecovery;
	[SerializeField]
	private int foodrecovery;
	[SerializeField]
	private bool other_effect;
	[SerializeField]
	private bool eat_when_infected;
	private GameObject game;
	public KindOfItem GetKindOfItem()
	{
		return kindOfItem;
	}

	public Sprite GetIcon()
	{
		return icon;
	}

	public string GetItemName()
	{
		return itemName;
	}

	public string GetInformation()
	{
		return information;
	}
	
	public int Getmoney()
	{
		return money;
	}
	public int Getkosuu()
	{
		return kosuu;
	}
	public int Getfoodrecovery()
	{
		return foodrecovery;
	}
	public int Getwaterrecovery()
	{
		return waterrecovery;
	}
	public bool Getother_effect()
    {
		return other_effect;
    }
	public bool GetEatWhenInfected()
	{
		return eat_when_infected;
	}
	public void Setkosuu(int itemkazu)
    {
		game = GameObject.Find("menumaneger");

		var mae = kosuu;
		kosuu = itemkazu + kosuu;
		var ato = kosuu;
		
		if (mae == 0 && ato > 0)
        {
			game.GetComponent<Menumanager>().makeicon(itemName);
        }
        if (mae != 0 && ato == 0)
        {
			game.GetComponent<Menumanager>().destroyicon(itemName);
        }
    }
	public void syokika()
    {
		kosuu = 0;
    }
}