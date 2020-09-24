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
    public Text no_waAkhir;

    private void Start()
    {
        StartCoroutine(LoginWa());
        StartCoroutine(AkhirWa());
    }



    IEnumerator LoginWa()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Config.Control.urlWa))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
            getData json = JsonUtility.FromJson<getData>(dat);

            Debug.Log(json.config.id);

            no_waAwal.text = json.config.contact1; 
        }
    }
    IEnumerator AkhirWa()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Config.Control.urlWa))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
            getData json = JsonUtility.FromJson<getData>(dat);

            Debug.Log(json.config.id);

            no_waAkhir.text = json.config.contact2; 
        }
    }

    public void waAwal()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=" + no_waAwal.text.ToString() + "&text=hai");
        //Application.OpenURL("https://api.whatsapp.com/send?phone=6282233477637&text=hai");
        //Debug.Log("https://whatsapp.com/send?phone=" + no_wa.text.ToString() + "&text=hai");
    }
    public void waAkhir()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=" + no_waAkhir.text.ToString() + "&text=hai");
        //Application.OpenURL("https://api.whatsapp.com/send?phone=6282233477637&text=hai");
        //Debug.Log("https://whatsapp.com/send?phone=" + no_wa.text.ToString() + "&text=hai");
    }
}
