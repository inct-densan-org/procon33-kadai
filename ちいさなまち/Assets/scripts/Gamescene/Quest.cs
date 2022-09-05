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
	private int reward_money;
	[SerializeField]
	private int QuestNumber;
	[SerializeField]
	private bool IsQuest;
	public string GetQuestinf()
	{
		return QuestInf;
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
	public void SetIsQuest(bool isquest)
    {
		IsQuest = isquest;
    }
}
