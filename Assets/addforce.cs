using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class addforce : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject box;
    public float spedd;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rb = transform.GetComponent<Rigidbody2D>();

        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition-transform.position;

            rb.AddForce(mouse * spedd);
        }
       
    }

   
}
