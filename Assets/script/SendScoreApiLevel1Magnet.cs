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
public class SendApi1Magnet
{
    public string DurasiMain;
    public string DurasiCocokan;
    public string Status;
    public string Skip;

}

public class SendScoreApiLevel1Magnet : MonoBehaviour
{

    public Text LevelMain;
    public TextMeshProUGUI TimePlay;
    public TextMeshProUGUI TimeCocokan;
    public Text tokenLogin;
    public Text idLogin;
    public Text namaPemain;
    public Text SkipText;

    public Text error;

    public Text progress;
    public int progres_Int = 0;
    public GameObject Loading;

    public int tnya;
    public Text StatusBerhasil;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        tnya = (int)TimePlay.GetComponent<timer>().myInt;

        progress.text = progres_Int.ToString();

        //Debug.Log("tny"+tnya);
    }

    public void Send()
    {
       StartCoroutine(PostRequest());
        StartCoroutine(UploadJPG());

        Loading.SetActive(true);
        progress.text = progres_Int.ToString();
       string path = Application.dataPath;
        //Debug.Log("path" + path);
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

        progres_Int += 10;
        yield return null;

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

        //string encode = Convert.ToBase64String(bytes);

        //Debug.Log("encode"+encode);

        Destroy(tex);
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_checkout_" + tnya.ToString();

        progres_Int += 10;

        yield return null;
        // For testing purposes, also write to a file in the project folder


        //File.WriteAllBytes(Application.dataPath + "/../"+ timeStamp + ".jpeg", bytes);

        Debug.Log("filenyajajsbajbjdbakbdk"+timeStamp);
        
        WWWForm form2 = new WWWForm();
        //===========================================================================================================//
        //EDIT AFIF ALLGAME

        form2.AddField("token", btn_manager_Magnet.Control.token);
        form2.AddField("id_event", btn_manager_Magnet.Control.id_event);
        form2.AddField("id_peserta", btn_manager_Magnet.Control.id_peserta);
        form2.AddField("id_game", btn_manager_Magnet.Control.id_game);
        form2.AddField("nama_hirarki", "level_1");
        form2.AddBinaryData("nama_file", bytes, timeStamp + ".jpeg");
        //===========================================================================================================//

        //error.text = encode.ToString("https://game.psikologicare.com/api/game/store-image");
        // Upload to a cgi script
        UnityWebRequest w = UnityWebRequest.Post(Config.Control.urlImage, form2);

        progres_Int += 10;

        yield return null;
        yield return w.SendWebRequest();
        progres_Int += 10;



        if (w.isNetworkError || w.isHttpError)
        {
            Loading.SetActive(false);

            error.text = w.error.ToString();
        }
        else
        {
            progres_Int += 10;

            yield return null;
            //error.text ="oke";
            Debug.Log("Finished Uploading Screenshot");
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

       // error.text = w.error.ToString();
    }

    IEnumerator PostRequest()
    {
        SendApi1Magnet myObject = new SendApi1Magnet();

        myObject.DurasiMain = TimePlay.text.ToString();
        myObject.DurasiCocokan = TimeCocokan.text.ToString();
        myObject.Status = StatusBerhasil.text.ToString();
        myObject.Skip = SkipText.text.ToString();

        string json = JsonUtility.ToJson(myObject, true);

        json = "{\"level_2\":" + json + "}";


        progres_Int += 10;

        yield return null;
        Debug.Log(json);

        string fileName =  idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_checkout_" + tnya.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        progres_Int += 10;

        yield return null;
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
        progres_Int += 10;

        yield return null;
        yield return uwr.SendWebRequest();

        progres_Int += 10;


        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            Loading.SetActive(false);

        }
        else
        {
            progres_Int += 10;

            yield return null;
            Debug.Log("Received: " + uwr.downloadHandler.text);
            //SceneManager.LoadScene("level2_resize");
        }
    }
}
