using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class getData6 : MonoBehaviour
{
    public string ideBentuk;
    public string alasanBentuk;
    public string timePlay;
    public string Skip;
    public string Tnya;
    


    public TextMeshProUGUI TimePlay;
    public Text IdeBentuk;
    public Text AlasanBentuk;
    public Text SkipText;
    public Text TnyaText;
    
    
    public void Start()
    {
        DataRead();
    }
    
    public void DataRead()
    {
        ideBentuk = Send_dataMain_akhir.Control.ideBentuk;
        alasanBentuk = Send_dataMain_akhir.Control.alasanBentuk;
        timePlay = Send_dataMain_akhir.Control.timePlay;
        Skip = Send_dataMain_akhir.Control.Skip;
        Tnya = Send_dataMain_akhir.Control.tnya;


        //Debug.Log("tes"+token);

        TimePlay.text = timePlay;
        IdeBentuk.text = ideBentuk;
        AlasanBentuk.text = alasanBentuk;
        SkipText.text = Skip;
        TnyaText.text = Tnya;
    }
}
