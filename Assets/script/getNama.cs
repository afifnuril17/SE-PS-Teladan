using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getNama : MonoBehaviour
{
    public string namaPemain;

    public Text NamaPemain;
  
    public void Start()
    {
        tokenRead();
    }
    
    public void tokenRead()
    {
       namaPemain = SendBiodata.Control.namaPemain;
        //Debug.Log("tes"+token);

        NamaPemain.text = namaPemain;
    }
}
