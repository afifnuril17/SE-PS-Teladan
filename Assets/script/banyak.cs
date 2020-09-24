using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class banyak : MonoBehaviour
{

    public GameObject bentuk1;
    public GameObject bentuk2;

    Vector3 startPosition1;
    Vector3 startPosition2;

    Vector3 startPosition1atas;
    Vector3 startPosition2atas;


    public Text gambarke;
    // Start is called before the first frame update
    void Start()
    {
        startPosition1 = bentuk1.transform.position;
        startPosition2 = bentuk2.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("1" + startPosition1);
        Debug.Log("2" + startPosition2);
            
        Debug.Log("1atas" + startPosition1atas);
        Debug.Log("2atas" + startPosition2atas);

        if (GameObject.Find("objek_area").GetComponent<scrollrectpos>().bawah == true)
        {
           
            if (bentuk1.transform.position == startPosition1 & bentuk2.transform.position == startPosition2)
            {
                bentuk2.SetActive(false);
                gambarke.text = "2";
            }
            if (bentuk1.transform.position == startPosition1 & bentuk2.transform.position != startPosition2)
            {
                gambarke.text = "1";
            }
            if (bentuk1.transform.position != startPosition1 & bentuk2.transform.position == startPosition2)
            {
                bentuk2.SetActive(true);
                gambarke.text = "1";
            }
            if (bentuk1.transform.position != startPosition1 & bentuk2.transform.position != startPosition2)
            {
                gambarke.text = " ";
            }

        }
        if (GameObject.Find("objek_area").GetComponent<scrollrectpos>().bawah == false)
        {
            if (bentuk1.transform.position == startPosition1atas & bentuk2.transform.position == startPosition2atas)
            {
                bentuk2.SetActive(false);
                gambarke.text = "2";
            }
            if (bentuk1.transform.position == startPosition1atas & bentuk2.transform.position != startPosition2atas)
            {
                gambarke.text = "1";
            }
            if (bentuk1.transform.position != startPosition1atas & bentuk2.transform.position == startPosition2atas)
            {
                bentuk2.SetActive(true);
                gambarke.text = "1";
            }
            if (bentuk1.transform.position != startPosition1atas & bentuk2.transform.position != startPosition2atas)
            {
                gambarke.text = " ";
            }

            Debug.Log("bawah false");
        }

        
    }
}
