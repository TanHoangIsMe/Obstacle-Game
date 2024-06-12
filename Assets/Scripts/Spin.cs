using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private float xValue;

    [SerializeField]
    private float yValue;

    [SerializeField]
    private float zValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xValue, yValue, zValue);
    }
}
