using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class ConfigData
{
    public int id;
    public string contact1;
    public string contact2;
}

public class getData
{

    public ConfigData config;
}

public class api_wa : MonoBehaviour
{
    public Text no_waAwal;
   //public Text no_waAkhir;
    public bool Tampil1 = false;

    //public bool Tampil2 = false;

    void Start()
    {

        if(Tampil1 == false)
        {
            StartCoroutine(LoginWa());
        }
        /*
        if(Tampil2 == false)
        {
            StartCoroutine(AkhirWa());
        }
        */
    }
    
    IEnumerator LoginWa()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Config.Control.urlWa))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
            getData json = JsonUtility.FromJson<getData>(dat);

            //Debug.Log(json.config.id);

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);

                StartCoroutine(LoginWa());
            }
            else
            {
                no_waAwal.text = json.config.contact1;
                //Debug.Log("Berhasil");
                Tampil1 = true;
            }
        }
    }
    /*
    IEnumerator AkhirWa()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Config.Control.urlWa))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
            getData json = JsonUtility.FromJson<getData>(dat);

            Debug.Log(json.config.id);

            no_waAkhir.text = json.config.contact2;
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Tampil2 = true;
            }
        }
    }
    */

    public void waAwal()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=" + no_waAwal.text.ToString() + "&text=Hai");
        //Application.OpenURL("https://api.whatsapp.com/send?phone=6282233477637&text=hai");
        //Debug.Log("https://whatsapp.com/send?phone=" + no_wa.text.ToString() + "&text=hai");
    }
    /*
    public void waAkhir()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=" + no_waAkhir.text.ToString() + "&text=Hai");
        //Application.OpenURL("https://api.whatsapp.com/send?phone=6282233477637&text=hai");
        //Debug.Log("https://whatsapp.com/send?phone=" + no_wa.text.ToString() + "&text=hai");
    }
    */
}
