using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class ConfigData2
{
    public int id;
    public string contact1;
    public string contact2;
}

public class getData2
{

    public ConfigData2 config;
}

public class api_waakhir : MonoBehaviour
{
  
    public Text no_waAkhir;
 
    public bool Tampil2 = false;

    void Start()
    {
        if(Tampil2 == false)
        {
            StartCoroutine(AkhirWa());
        }
    }
    IEnumerator AkhirWa()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Config.Control.urlWa))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
            getData2 json = JsonUtility.FromJson<getData2>(dat);

            //Debug.Log(json.config.id);

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                StartCoroutine(AkhirWa());
            }
            else
            {
                no_waAkhir.text = json.config.contact2;
                Tampil2 = true;
            }
        }
    }

    public void waAkhir()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=" + no_waAkhir.text.ToString() + "&text=Hai");
        //Application.OpenURL("https://api.whatsapp.com/send?phone=6282233477637&text=hai");
        //Debug.Log("https://whatsapp.com/send?phone=" + no_wa.text.ToString() + "&text=hai");
    }
}
