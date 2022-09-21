using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gomimanager : MonoBehaviour
{
    public GameObject GameObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject = this.gameObject;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject.SetActive(false);
                Restranquest.gominum++;
            }
        }
    }
}
