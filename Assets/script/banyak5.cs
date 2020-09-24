using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class banyak5 : MonoBehaviour
{

    public GameObject bentuk1;
    public GameObject bentuk2;
    public GameObject bentuk3;
    public GameObject bentuk4;
    public GameObject bentuk5;

    Vector3 startPosition1;
    Vector3 startPosition2;
    Vector3 startPosition3;
    Vector3 startPosition4;
    Vector3 startPosition5;


    public Text gambarke;
    // Start is called before the first frame update
    void Start()
    {
        startPosition1 = bentuk1.transform.position;
        startPosition2 = bentuk2.transform.position;
        startPosition3 = bentuk3.transform.position;
        startPosition4 = bentuk4.transform.position;
        startPosition5 = bentuk5.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk2.SetActive(false);
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "5";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk2.SetActive(true);
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "4";
        } 
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk3.SetActive(true);
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "3";
        } 
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
          
            bentuk4.SetActive(true);
            bentuk5.SetActive(false);
            gambarke.text = "2";
        } 
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk5.SetActive(true);
            gambarke.text = "1";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position != startPosition5)
        { 
            gambarke.text = " ";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk2.SetActive(true);
            gambarke.text = "1";
        }
        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk3.SetActive(true);
            gambarke.text = "1";

        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk4.SetActive(true);
            gambarke.text = "1";
        }  
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position != startPosition5)
        {
            gambarke.text = "1";
        }
        
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk2.SetActive(false);
            gambarke.text = "2";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk3.SetActive(false);
            gambarke.text = "2";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk4.SetActive(false);
            gambarke.text = "2";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk5.SetActive(false);
            gambarke.text = "2";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk2.SetActive(true);
            bentuk3.SetActive(false);
            gambarke.text = "2";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk2.SetActive(true);
            bentuk4.SetActive(false);
            gambarke.text = "2";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk2.SetActive(true);
            bentuk5.SetActive(false);
            gambarke.text = "2";
        } 
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk3.SetActive(true);
            bentuk4.SetActive(false);
            gambarke.text = "2";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk3.SetActive(true);
            bentuk5.SetActive(false);
            gambarke.text = "2";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk4.SetActive(true);
            bentuk5.SetActive(false);
            gambarke.text = "2";
        }
        
        
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk2.SetActive(false);
            bentuk3.SetActive(false);
            gambarke.text = "3";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk2.SetActive(false);
            bentuk4.SetActive(false);
            gambarke.text = "3";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk2.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "3";
        } 
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            gambarke.text = "3";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk3.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "3";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "3";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk3.SetActive(true);
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "3";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk2.SetActive(true);
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            gambarke.text = "3";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk3.SetActive(true);
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "3";
        } 
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk2.SetActive(true);
            bentuk3.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "3";
        }
        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk2.SetActive(true);
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "3";
        }
        
        
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position != startPosition5)
        {
            bentuk2.SetActive(false);
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            gambarke.text = "4";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk2.SetActive(false);
            bentuk3.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "4";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "4";
        }
        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4 && bentuk5.transform.position == startPosition5)
        {
            bentuk2.SetActive(false);
            bentuk4.SetActive(false);
            bentuk5.SetActive(false);
            gambarke.text = "4";
        }
        


    }
}
