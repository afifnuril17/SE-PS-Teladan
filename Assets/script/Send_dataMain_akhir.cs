using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Send_dataMain_akhir : MonoBehaviour
{
    public static Send_dataMain_akhir Control;
    public string ideBentuk;
    public string alasanBentuk;
    public string timePlay;
    public string Skip;
    public string tnya;

    public TextMeshProUGUI TimePlay;
    public Text IdeBentuk;
    public Text AlasanBentuk;
    public Text SkipText;
    public Text tnyaText;



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Control == null)
        {
            Control = this;
        }
    }


    public void Next6Akhir()
    {
        ideBentuk = IdeBentuk.text;
        alasanBentuk = AlasanBentuk.text;
        timePlay = TimePlay.text;
        Skip = SkipText.text;
        tnya = tnyaText.text;

    }

}
