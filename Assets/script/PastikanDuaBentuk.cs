using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastikanDuaBentuk : MonoBehaviour
{
    public GameObject panel2magnet;
   void Update()
    {
        if (GameObject.Find("objek_dibuat").transform.childCount > 1)
        {
            if(panel2magnet.GetComponent<Tutorial>().magnet == false)
            {
                panel2magnet.GetComponent<Tutorial>().klikmagnet();
            }
        }
    }
}
