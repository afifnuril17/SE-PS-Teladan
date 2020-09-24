using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coba2 : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mathf.Abs(obj1.transform.position.x - transform.position.x) < 1)
        //{
        // obj2.transform.position = obj1.transform.position;
        //}

        //Debug.Log(obj1.transform.position);
        //Debug.Log(obj2.transform.position);

        //Vector3 box1 = obj1.GetComponent<Collider2D>().bounds.size; 
        //Vector3 box2 = obj2.GetComponent<Collider2D>().bounds.size;

        //obj1.transform.position = box2;
        //Debug.Log("box1" + box1);
        //Debug.Log("box2" + box2);

        Debug.Log(" 1" + obj1.transform.position.x);
        
        Debug.Log(" 2" + obj2.transform.position.x);

        if((obj1.transform.position.x - transform.position.x) > 100)
        {
            Debug.Log("BImisalah");
        }
    }
}
