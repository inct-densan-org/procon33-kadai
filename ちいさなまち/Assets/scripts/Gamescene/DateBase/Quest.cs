using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Quest", menuName = "CreateQuest")]
public class Quest : ScriptableObject
{

	
	//?@?A?C?e??????O
	[SerializeField]
	private string QuestInf;
	//?@?A?C?e??????
	[SerializeField]
	private string QuestName;
	[SerializeField]
	private string Questitem;
	[SerializeField]
	private int reward_money;
	[SerializeField]
	private int QuestNumber;
	[SerializeField]
	private bool IsQuest;
	[SerializeField]
	private bool IsQuria;

	public string GetQuestinf()
	{
		return QuestInf;
	}
	public string GetQuestitem()
	{
		return Questitem;
	}
	public string GetQuestName()
	{
		return QuestName;
	}
	public int Getreward()
	{
		return reward_money;
	}
	public int GetNumber()
	{
		return QuestNumber;
	}
	public bool GetIsQuest()
	{
		return IsQuest;
	}
	public bool GetIsQuria()
	{
		return IsQuria;
	}
	public void SetIsQuest(bool isquest)
    {
		IsQuest = isquest;
    }
	public void SetIsQuria(bool isquest)
	{
		IsQuria = isquest;
	}
}
