using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectpindah : MonoBehaviour
{
    public bool menyatu = true;
    public bool biasa = false;
    public float speed= 10;

    public GameObject bentuk_image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector3 mouse = Input.mousePosition - transform.position;
        if (Input.GetMouseButton(1))
        {
            menyatu = false;
            biasa = false;
        }
        if (biasa == true)
        {
            transform.position = Input.mousePosition;
        }
        else
        {
            rb.AddForce(mouse * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("1_2_1"))
        {
            if (menyatu == true)
            {
                Debug.Log("masuk");
                GameObject.Find("juja").transform.parent = transform;
                biasa = true;
            }
        }
        if (col.gameObject.CompareTag("1_2_4"))
        {
            if (menyatu == true)
            {
                Debug.Log("masuk");
                GameObject.Find("juj").transform.parent = transform;
                biasa = true;
            }
        }
        if (col.gameObject.CompareTag("1_2_7"))
        {
            if (menyatu == true)
            {
                Debug.Log("masuk");
                GameObject.Find("Image").transform.parent = transform;
                biasa = true;
            }
        }
    } 
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("1_2_1"))
        {
            if (menyatu == true)
            {
                Debug.Log("masuk");
                GameObject.Find("juja").transform.parent = GameObject.Find("Panel").transform;
                biasa = false;
            }
        }
        if (col.gameObject.CompareTag("1_2_4"))
        {
            if (menyatu == true)
            {
                Debug.Log("masuk");
                GameObject.Find("juj").transform.parent = GameObject.Find("Panel").transform;
                biasa = false;
            }
        } 
        if (col.gameObject.CompareTag("1_2_7"))
        {
            if (menyatu == true)
            {
                Debug.Log("masuk");
                GameObject.Find("Image").transform.parent = GameObject.Find("Panel").transform;
                biasa = false;
            }
        }
        if (col.gameObject.CompareTag("bentuk_image"))
        {
            bentuk_image.transform.parent = GameObject.Find("hahaha").transform;

        }
    }


}
