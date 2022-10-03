using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asd : MonoBehaviour
{
    // Start is called before the first frame update
   



    private float speed = 0.03f;

    void Start()
    {
    }

    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        else if (Input.GetKey("right"))
        {
            position.x += speed;
        }
        else if (Input.GetKey("up"))
        {
            position.y += speed;
        }
        else if (Input.GetKey("down"))
        {
            position.y -= speed;
        }

        transform.position = position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("asd");
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("osita");
            }
        }
    }
}


    // Update is called once per frame
    

