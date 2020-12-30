using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getTokenMagnet : MonoBehaviour
{
    public string token;
    public string id_peserta;

    public Text tokenText;
    public Text idText;

    public void Start()
    {
        tokenRead();
    }
    
    public void tokenRead()
    {
        token = btn_manager_Magnet.Control.token;
        id_peserta = btn_manager_Magnet.Control.id_peserta;

        //Debug.Log("tes"+token);

        tokenText.text = token;
        idText.text = id_peserta;
    }
}
