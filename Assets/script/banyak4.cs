using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class banyak4 : MonoBehaviour
{

    public GameObject bentuk1;
    public GameObject bentuk2;
    public GameObject bentuk3;
    public GameObject bentuk4;

    Vector3 startPosition1;
    Vector3 startPosition2;
    Vector3 startPosition3;
    Vector3 startPosition4;


    public Text gambarke;
    // Start is called before the first frame update
    void Start()
    {
        startPosition1 = bentuk1.transform.position;
        startPosition2 = bentuk2.transform.position;
        startPosition3 = bentuk3.transform.position;
        startPosition4 = bentuk4.transform.position;
    }


    // Update is called once per frame
    void Update()
    {


        if(bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk2.SetActive(false);
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            gambarke.text = "4";
        }

        if(bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk2.SetActive(true);
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            gambarke.text = "3";
        }

        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk3.SetActive(true);
            bentuk4.SetActive(false);
            gambarke.text = "2";
        }
        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk4.SetActive(true);
            gambarke.text = "1";
        }
        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4)
        {
            bentuk2.SetActive(true);
            gambarke.text = "1";
        } 
        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4)
        {
            bentuk3.SetActive(true);
            gambarke.text = "1";
        } 
        if (bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4)
        {
            gambarke.text = "1";
        }
        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4)
        {
            gambarke.text = " ";
        }
       
       
        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk3.SetActive(true);
            bentuk4.SetActive(false);
            gambarke.text = "2";
        } 
        if (bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position != startPosition4)
        {
            bentuk2.SetActive(false);
            gambarke.text = "2";
        }
        if (bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4)
        {
            bentuk3.SetActive(false);
            gambarke.text = "2";
        }
        if (bentuk1.transform.position == startPosition1 && bentuk2.transform.position != startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk4.SetActive(false);
            gambarke.text = "2";
        } 
        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4)
        {
            bentuk2.SetActive(true);
            bentuk3.SetActive(false);
            gambarke.text = "2";
        } 
        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk2.SetActive(true);
            bentuk4.SetActive(false);
            gambarke.text = "2";
        }


        if (bentuk1.transform.position != startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk2.SetActive(true);
            bentuk3.SetActive(false);
            bentuk4.SetActive(false);
            gambarke.text = "3";
        }
        if (bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position == startPosition3 && bentuk4.transform.position != startPosition4)
        {
            bentuk2.SetActive(true);
            bentuk3.SetActive(false);
            gambarke.text = "3";
        } 
        if (bentuk1.transform.position == startPosition1 && bentuk2.transform.position == startPosition2 && bentuk3.transform.position != startPosition3 && bentuk4.transform.position == startPosition4)
        {
            bentuk2.SetActive(true);
            bentuk4.SetActive(false);
            gambarke.text = "3";
        }





    }
}
