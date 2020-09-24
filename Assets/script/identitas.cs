using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class ConfigDataa
{
    public int id;
    public string attribute;
    public string label;
    public string type;
}

public class getDataa
{
    public ConfigDataa user_id;
}

public class identitas : MonoBehaviour
{
    public Text url;
    public Text no_wa;

    string rootURL = "http://game.psikologicare.com/api/login?name=maverick&password=BinaKarir2020!";

    private void Start()
    {
        StartCoroutine(identitasEnumerator());
    }



    IEnumerator identitasEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post(rootURL, form))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
           
            Debug.Log(dat);
            getDataa json = JsonUtility.FromJson<getDataa>(dat);
            Debug.Log(json.user_id.attribute);

            //no_wa.text = json.atrribute.label;
        }
    }
}
