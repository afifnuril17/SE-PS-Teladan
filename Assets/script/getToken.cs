using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getToken : MonoBehaviour
{
    public string token;
    public string id;

    public Text tokenText;
    public Text idText;

    public void Start()
    {
        tokenRead();
    }
    
    public void tokenRead()
    {
        token = btn_manager.Control.token;
        id = btn_manager.Control.id;

        //Debug.Log("tes"+token);

        tokenText.text = token;
        idText.text = id;
    }
}
