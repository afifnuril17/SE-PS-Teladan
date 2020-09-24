using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BiodataGetnPost : MonoBehaviour
{
    public Text TokenText;
    public Text no_waAkhir;

    public string token;
    string rootURL = "https://game.psikologicare.com/api/attribute-biodata";

    private void Start()
    {

        token = TokenText.text.ToString();

        StartCoroutine(GetBiodata());
    }

    IEnumerator GetBiodata()
    {
        using ( UnityWebRequest www = UnityWebRequest.Get(rootURL + "?token=" + token))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
            getData json = JsonUtility.FromJson<getData>(dat);

            Debug.Log(json.config.id);
        }
    }
}
