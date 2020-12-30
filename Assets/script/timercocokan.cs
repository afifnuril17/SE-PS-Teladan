using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.IO;

[SerializeField]

public class SendApiCocokan
{
    public string DurasiMain;
    public string DurasiCocokan;
    public string Status;

}

public class timercocokan : MonoBehaviour
{
    public Text namaPemain;
    public Text LevelMain;
    public TextMeshProUGUI TimePlay;
    public TextMeshProUGUI TimeCocokan;
    public Text tokenLogin;
    public Text idLogin;

    public Text StatusBerhasil;


    public GameObject waktuhabis;
    TextMeshProUGUI timerText;
    private bool lanjut = true;
    private int seconds;
    private int minutes;
    private float milliseconds;
    public int timeCocok;

    public int cekOut;
    public float myInt;
    public bool cek = false;

    // Start is called before the first frame update
    void Start()
    {
        lanjut = true;
        timerText = GetComponentInChildren<TMPro.TextMeshProUGUI>(); // cache the text component
        //timerText.text = string.Format("{0}:{1}:{2}", /*hours.ToString("00"),*/ minutes.ToString("00"), seconds.ToString("00"), milliseconds.ToString("00"));

        seconds = 0;
        minutes = 0;
        milliseconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lanjut == true)
        {
            myInt += Time.deltaTime;

            DisplayTime(myInt);

            if ((int)myInt % 60 == 1)
            {
                cek = false;
            }

            if ((int)myInt % 60 == 0 && cek == false)
            {
                StartCoroutine(PostRequest());
                StartCoroutine(UploadJPG());
                cek = true;
            }
            if ((int)myInt == cekOut)
            {
                StartCoroutine(PostRequest());
                StartCoroutine(UploadJPG());

                waktuhabis.SetActive(true);
                lanjut = false;
            }
        }
    }
    void DisplayTime(float timeDisplay)
    {
        milliseconds = Mathf.FloorToInt(timeDisplay * 100) % 100;

        minutes = Mathf.FloorToInt(timeDisplay / 60);
        seconds = Mathf.FloorToInt(timeDisplay % 60);

        //milliseconds = (Mathf.Floor(timeDisplay * 100) % 100);
        //timeCount.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds;

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

    }

    IEnumerator UploadJPG()
    {
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_checkout_" + ((int)myInt).ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../"+ timeStamp + ".jpeg", bytes);

        Debug.Log("filenyajajsbajbjdbakbdk" + timeStamp);
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

            Debug.Log(w.error);
        }
        else
        {
            Debug.Log("Received: " + w.downloadHandler.text);
        }
    }

    IEnumerator PostRequest()
    {
        SendApiCocokan myObject = new SendApiCocokan();

        myObject.DurasiMain = TimePlay.text.ToString();
        myObject.DurasiCocokan = TimeCocokan.text.ToString();
        myObject.Status = StatusBerhasil.text.ToString();

        string json = JsonUtility.ToJson(myObject, true);

        json = "{\"level_2\":" + json + "}";

        Debug.Log(json);

       
        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");


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

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    public void waktupenjelesaiancocokan()
    {
        //Debug.Log(timerText.text);
        lanjut = false;
        //jika ditekan selesai maka submit waktu dengan cara ngirim timerText.text
    }
    public void waktutidakjadi()
    {
        //Debug.Log(timerText.text);
        lanjut = true;
        //jika ditekan selesai maka submit waktu dengan cara ngirim timerText.text
    }
}
