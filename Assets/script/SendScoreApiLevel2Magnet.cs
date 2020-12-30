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
public class SendApi2Magnet
{
    public string DurasiMain;
    public string DurasiCocokan;
    public string Status;
    public string Skip;

}

public class SendScoreApiLevel2Magnet : MonoBehaviour
{

    public GameObject Loading;

    public Text LevelMain;
    public TextMeshProUGUI TimePlay;
    public TextMeshProUGUI TimeCocokan;
    public Text tokenLogin;
    public Text idLogin;
    public Text namaPemain;
    public Text SkipText;

    public int tnya;

    public Text StatusBerhasil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tnya = (int)TimePlay.GetComponent<timer2_3>().myInt;
    }

    public void Send()
    {
        StartCoroutine(PostRequest());
        StartCoroutine(UploadJPG());

        Loading.SetActive(true);
    }

    IEnumerator UploadJPG()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, true);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        Texture2D tex2 = new Texture2D(tex.width / 2, tex.height / 2, TextureFormat.RGB24, true);

        // Read screen contents into the texture
        tex2.SetPixels(tex.GetPixels(1));

        tex2.Apply();

        Texture2D tex3 = new Texture2D(tex2.width / 2, tex2.height / 2, TextureFormat.RGB24, true);

        // Read screen contents into the texture
        tex3.SetPixels(tex2.GetPixels(1));

        tex3.Apply();

        // Encode texture into PNG
        byte[] bytes = tex3.EncodeToPNG();
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_checkout_" + tnya.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../"+ timeStamp + ".jpeg", bytes);

        Debug.Log("filenyajajsbajbjdbakbdk"+timeStamp);
        WWWForm form = new WWWForm();
        //===========================================================================================================//
        //EDIT AFIF ALLGAME

        form.AddField("token", btn_manager_Magnet.Control.token);
        form.AddField("id_event", btn_manager_Magnet.Control.id_event);
        form.AddField("id_peserta", btn_manager_Magnet.Control.id_peserta);
        form.AddField("id_game", btn_manager_Magnet.Control.id_game);
        form.AddField("nama_hirarki", "level_2");
        form.AddBinaryData("nama_file", bytes, timeStamp + ".jpeg");
        //===========================================================================================================//

        // Upload to a cgi script
        UnityWebRequest w = UnityWebRequest.Post(Config.Control.urlImage, form);
        yield return w.SendWebRequest();

        if (w.isNetworkError || w.isHttpError)
        {
            Loading.SetActive(false);

            Debug.Log(w.error);
        }
        else
        {
            Loading.SetActive(false);

            if (btn_manager_Magnet.Control.sceneInt < btn_manager_Magnet.Control.scene.Count)
            {
                SceneManager.LoadScene(btn_manager_Magnet.Control.scene[btn_manager_Magnet.Control.sceneInt]);
                btn_manager_Magnet.Control.sceneInt++;
            }
            else
            {
                SceneManager.LoadScene("main_akhir_tanoto");
            }
        }
    }

    IEnumerator PostRequest()
    {
        SendApi2Magnet myObject = new SendApi2Magnet();

        myObject.DurasiMain = TimePlay.text.ToString();
        myObject.DurasiCocokan = TimeCocokan.text.ToString();
        myObject.Status = StatusBerhasil.text.ToString();
        myObject.Skip = SkipText.text.ToString();

        string json = JsonUtility.ToJson(myObject, true);

        json = "{\"level_1\":" + json + "}";


        Debug.Log(json);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        //Debug.Log("Screenshoot");


        WWWForm form = new WWWForm();
        //===========================================================================================================//
        //EDIT AFIF ALLGAME

        form.AddField("token", btn_manager_Magnet.Control.token);
        form.AddField("id_event", btn_manager_Magnet.Control.id_event);
        form.AddField("id_peserta", btn_manager_Magnet.Control.id_peserta);
        form.AddField("id_game", btn_manager_Magnet.Control.id_game);

        //===========================================================================================================//

        form.AddField("level", LevelMain.text.ToString());
        form.AddField("score", json);
        

        UnityWebRequest uwr = UnityWebRequest.Post(Config.Control.urlSaveScore, form);

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Loading.SetActive(false);

            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {

            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
