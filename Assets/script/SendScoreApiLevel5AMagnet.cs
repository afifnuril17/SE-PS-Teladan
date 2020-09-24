using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

[Serializable]
public class SendApi5AMagnet
{
    public string DurasiMain;
    public string Skip;

}

public class SendScoreApiLevel5AMagnet : MonoBehaviour
{

    public Text LevelMain;
    public TextMeshProUGUI TimePlay;
    public Text tokenLogin;
    public Text idLogin;
    public Text namaPemain;
    public Text SkipText;
    public int tnya;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tnya = TimePlay.GetComponent<timer4B>().detik;

    }

    public void send()
    {
        StartCoroutine(PostRequest());
        StartCoroutine(UploadJPG());

        Debug.Log(tnya.ToString());
        string path = Application.dataPath;
        Debug.Log("path" + path);
    }

    IEnumerator UploadJPG()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_checkout_" + tnya.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../"+ timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text.ToString());
        form.AddBinaryData("image", bytes, timeStamp + ".jpeg");


        // Upload to a cgi script
        UnityWebRequest w = UnityWebRequest.Post(Config.Control.urlImage, form);
        yield return w.SendWebRequest();

        if (w.isNetworkError || w.isHttpError)
        {
            Debug.Log(w.error);
        }
        else
        {
            SceneManager.LoadScene("level5B_tanoto_magnet");

            Debug.Log("Finished Uploading Screenshot");
        }
    }

    IEnumerator PostRequest()
    {
        SendApi5AMagnet myObject = new SendApi5AMagnet();

        myObject.DurasiMain = TimePlay.text.ToString();
        myObject.Skip = SkipText.text.ToString();

        string json = JsonUtility.ToJson(myObject);

        Debug.Log(json);

        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_checkout_" + tnya.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");


        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text.ToString());
        form.AddField("id_user", idLogin.text.ToString());
        form.AddField("id_game", "1");
        form.AddField("level", LevelMain.text.ToString());
        form.AddField("score", json);
        

        UnityWebRequest uwr = UnityWebRequest.Post(Config.Control.urlSaveScore, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {

            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
