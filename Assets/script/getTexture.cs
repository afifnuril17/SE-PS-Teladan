using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class getTexture : MonoBehaviour
{
    //public Texture texture;
    public Texture2D texture2;

    public GameObject imagenya;

    public void Start()
    {
        DataRead();
    }
    
    public void DataRead()
    {
        texture2 = SendTexture.Control.texture2;
        //texture = SendTexture.Control.texture;

        imagenya.GetComponent<Image>().material.SetTexture(1,texture2);

        //Debug.Log("tes"+token);
    }
}
