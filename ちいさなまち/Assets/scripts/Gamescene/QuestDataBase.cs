using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataBase", menuName = "CreateQuestDataBase")]
public class QuestDataBase : ScriptableObject
{
	[SerializeField]
	private List<Quest> QuestLists = new List<Quest>();

	//?@?A?C?e?????X?g????
	public List<Quest> GetQusetLists()
	{
		return QuestLists;
	}
}
