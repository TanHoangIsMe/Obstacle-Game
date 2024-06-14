using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Spiner")
        {
            Debug.Log("You are hit !!!");
            GetComponent<GetScore>().score -= 1;
            GetComponent<GetScore>().ShowScore();

        }
        else if(collision.gameObject.tag == "Point")
        {
            GameObject point = GameObject.FindWithTag("Point");
            Destroy(point);
            GetComponent<GetScore>().score += 2;
            GetComponent<GetScore>().ShowScore();
        }
        else if(collision.gameObject.tag == "FallDownCube" || collision.gameObject.tag == "Roller")
        {
            Debug.Log("You are hit hard !!!");
            GetComponent<GetScore>().life -= 1;
            GetComponent<GetScore>().score -= 2;
            GetComponent<GetScore>().ShowScore();
        }
    }
}
