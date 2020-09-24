using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class normalorresize : MonoBehaviour
{
    public GameObject bentuk_image;
    public Text ukuran;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ukuran.text == "normal")
        {
            bentuk_image.GetComponent<ItemIDragHandlercobasize>().enabled = true;
            bentuk_image.GetComponent<resize>().enabled = false;
        }
        else
        {
            bentuk_image.GetComponent<resize>().enabled = true;
            bentuk_image.GetComponent<ItemIDragHandlercobasize>().enabled = false;
        }
    }
}
