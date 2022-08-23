using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    public float infectionDistance = 2.0f; // 感染する距離
    public int infectionProbability = 1;   // 1フレームごとに感染する確率

    public bool infected = false;          // 感染したかどうか

    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (infected == false) 
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < players.Length; i++)
            {
                GameObject playerObj = players[i];
                Infection playerInfection = playerObj.GetComponent<Infection>();
                float dist = Vector2.Distance(transform.position, playerObj.transform.position);
                if (dist < infectionDistance && playerInfection.infected)
                {
                    DoInfection();
                }
            }
        }
    }

    private void DoInfection()
    {
        int rnd = Random.Range(0, 100);
        if (rnd <= infectionProbability)
        {
            infected = true;
        }
    }
}