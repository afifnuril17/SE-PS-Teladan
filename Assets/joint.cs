using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joint : MonoBehaviour
{
    public bool nyala;
    public int a =1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void bersatu()
    {

        if(a == 1)
        {
            nyala = true;
        }
        else
        {
            nyala = false;
        }


        if (nyala == true)
        {
            GameObject.Find("Panel").GetComponent<moveTag>().enabled = true;
            a = 1;
        }
        else
        {
            GameObject.Find("Panel").GetComponent<moveTag>().enabled = false;
            a = 0;
        }
        //GameObject.Find("Image").GetComponent<selectpindah>().enabled = true;
        //GameObject.Find("Image").GetComponent<selectpindah>().menyatu = true;


    }

    public void dragSatu()
    {

    }
}
