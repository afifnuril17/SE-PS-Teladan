using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resize : MonoBehaviour
{
    public GameObject bentuk_image;
    public Text size;
   public  Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temp = bentuk_image.transform.localScale;
        if (size.text == "ymin")
        {
            if (Input.GetMouseButtonDown(0) == bentuk_image)
            { 
                temp.y -= Time.deltaTime;
            }
        }
        if(size.text == "ymax")
        {
            if (Input.GetMouseButtonDown(0) == bentuk_image)
            {
                temp.y += Time.deltaTime;
            }

        }
        if(size.text == "xmin")
        {
            if (Input.GetMouseButtonDown(0) == bentuk_image)
            {
                temp.x -= Time.deltaTime;
            }

        }
        if(size.text == "xmax")
        {
            if (Input.GetMouseButtonDown(0) == bentuk_image)
            {
                temp.x += Time.deltaTime;
            }

        }
       
        bentuk_image.transform.localScale = temp;
    }
}
