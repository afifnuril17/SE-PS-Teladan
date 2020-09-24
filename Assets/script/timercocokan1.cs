using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.IO;

[SerializeField]

public class SendApiCocokan1
{
    public string DurasiMain;
    public string DurasiCocokan;
    public string Status;

}

public class timercocokan1 : MonoBehaviour
{
    public Text LevelMain;
    public TextMeshProUGUI TimePlay;
    public TextMeshProUGUI TimeCocokan;
    public Text tokenLogin;
    public Text idLogin;

    public Text StatusBerhasil;


    public GameObject waktuhabis;
    TextMeshProUGUI timerText;
    private bool lanjut = true;
    private float t;
    private float ti;
    private int seconds;
    private int minutes;
    private float milliseconds;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {

        startTime = Time.timeSinceLevelLoad;
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
        if(lanjut == true)
        {
            hitung();
        }
    }
    void hitung()
    {
        if (lanjut == true)
        {
            // time since scene loaded
            float t = Time.timeSinceLevelLoad - startTime;

            milliseconds = (Mathf.Floor(t * 100) % 100); // calculate the milliseconds for the timer

            seconds = (int)(t % 60); // return the remainder of the seconds divide by 60 as an int
            t /= 60; // divide current time y 60 to get minutes
            minutes = (int)(t % 60); //return the remainder of the minutes divide by 60 as an int


            //t /= 60; // divide by 60 to get hours
            //int hours = (int)(t % 24); // return the remainder of the hours divided by 60 as an int

            timerText.text = string.Format("{0}:{1}:{2}", /*hours.ToString("00"),*/ minutes.ToString("00"), seconds.ToString("00"), milliseconds.ToString("00"));



            /*"{0}:{0}:{1}:{2}"*/
            if (minutes == 0 && seconds == 50 && milliseconds == 0)
            {
                StartCoroutine(PostRequest());
                StartCoroutine(UploadJPG());
            }
            if (minutes == 1 && seconds == 0)
            {
                StartCoroutine(PostRequest());
                StartCoroutine(UploadJPG());
                waktuhabis.SetActive(true);
                //Debug.Log("mandeng");
                lanjut = false;
            }
        }
        else
        {

        }
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
        string timeStamp = "1-1-" + LevelMain.text;

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
        form.AddBinaryData("image", bytes, timeStamp + ".jpeg");


        // Upload to a cgi script
        UnityWebRequest w = UnityWebRequest.Post("http://game.psikologicare.com/api/game/store-image", form);
        yield return w.SendWebRequest();

        if (w.isNetworkError || w.isHttpError)
        {
            Debug.Log(w.error);
        }
        else
        {
            Debug.Log("Finished Uploading Screenshot");
        }
    }

    IEnumerator PostRequest()
    {
        SendApiCocokan1 myObject = new SendApiCocokan1();

        myObject.DurasiMain = TimePlay.text.ToString();
        myObject.DurasiCocokan = TimeCocokan.text.ToString();
        myObject.Status = StatusBerhasil.text.ToString();

        string json = JsonUtility.ToJson(myObject);

        Debug.Log(json);

        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "Screenshot" + timeStamp + ".jpeg";
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


        UnityWebRequest uwr = UnityWebRequest.Post("https://game.psikologicare.com/api/game/store-score", form);

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

    public void waktupenjelesaiancocokan()
    {
        //Debug.Log(timerText.text);
        lanjut = false;
        //jika ditekan selesai maka submit waktu dengan cara ngirim timerText.text
    }
    public void waktutidakjadi()
    {
       // Debug.Log(timerText.text);
        lanjut = true;
        //jika ditekan selesai maka submit waktu dengan cara ngirim timerText.text
    }
}
