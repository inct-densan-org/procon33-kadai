using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class aaa : MonoBehaviour
{
    public void PrintSenderName(Button sender)
    {
        if (sender != null)
        {
            Debug.Log(sender.name);
        }
    }
}
