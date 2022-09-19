using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerothercol : MonoBehaviour
{
    public Vector3 targetpo = Move.popo;
    public GameObject col;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        col = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        targetpo = Move.popo;
        offset = new Vector3(0, 0, -1);
        transform.position = targetpo + offset;
    }
}
