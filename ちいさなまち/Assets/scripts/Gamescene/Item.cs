

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
		Mask,
		food,
		medicine,
		water,        
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
	public void Setkosuu(int itemkazu)
    {
		kosuu = itemkazu + kosuu;
    }
	public void syokika()
    {
		kosuu = 0;
    }
}