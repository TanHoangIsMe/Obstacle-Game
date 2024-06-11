using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float newZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(newX, 0, newZ);
    }
}
