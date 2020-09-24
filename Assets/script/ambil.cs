using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ambil : MonoBehaviour
{
    //click double
    private const float Double_click_time = .2f;
    private float lastClickTime;
    //click double
    
    //bentuk image
    public GameObject bentuk1;
    //bentuk image

    //drag
    private RectTransform rectTransform; 
    private Canvas canvas;
    //drag

    // Start is called before the first frame update


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        
    }
    void Flip()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
          

            if (timeSinceLastClick <= Double_click_time)
            {
                print("doble klik");
                bentuk1.transform.Rotate(0, 180, 0);
            }
            else
            {
                print("normal klik");
                Drag();

            }
            lastClickTime = Time.time;
        }
    }

    void Drag()
    {
        Debug.Log("Drag Menthod");
        bentuk1.transform.position = bentuk1.transform.position + new Vector3(Input.GetAxis("Mouse X") * 20, Input.GetAxis("Mouse Y") * 20, 0);
    }
    // Update is called once per frame
    void Update()
    {
        Flip();
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Debug.Log(" X :" + Input.GetAxis("Mouse X"));
            Debug.Log(" Y :" + Input.GetAxis("Mouse Y"));
            

            Debug.Log(bentuk1.transform);
        }
    }
}
