using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject w;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("q");
        w.SetActive(true);
        a();
    }
    public async void a()
    {
        await Task.Delay(1000);
        w.SetActive(false);
        await Task.Delay(1000);
        w.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
