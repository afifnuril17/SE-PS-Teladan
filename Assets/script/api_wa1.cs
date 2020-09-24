using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class ConfigData1
{
    public int id;
    public string contact1;
    public string contact2;
}

public class getData1
{

    public ConfigData config;
}

public class api_wa1 : MonoBehaviour
{
    public Text no_wa;

    string rootURL = "https://game.psikologicare.com/api/login-form";

    private void Start()
    {
        StartCoroutine(LoginEnumerator());
    }



    IEnumerator LoginEnumerator()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(rootURL))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
            getData1 json = JsonUtility.FromJson<getData1>(dat);

            
            Debug.Log(json.config.contact2);

            no_wa.text = json.config.contact2; 
        }
    }

    public void wa()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=" + no_wa.text.ToString() + "&text=hai");
        //Application.OpenURL("https://api.whatsapp.com/send?phone=6282233477637&text=hai");
        //Debug.Log("https://whatsapp.com/send?phone=" + no_wa.text.ToString() + "&text=hai");
    }
}
