using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Networking;

public class timer5AB1 : MonoBehaviour
{
    public GameObject waktuhabis;
    TextMeshProUGUI timerText;
    private bool lanjut= true;

    private float startTime;
    private int seconds;
    private int minutes;
    private float milliseconds;

    public Text LevelMain;
    public Text tokenLogin;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
        timerText = GetComponentInChildren<TMPro.TextMeshProUGUI>(); // cache the text component
        seconds = 0;
        minutes = 0;
        milliseconds = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lanjut == true)
        {
            hitung();
        }
    }
    void hitung()
    {
        if (lanjut == true)
        {
            float t = Time.timeSinceLevelLoad - startTime; // time since scene loaded


            milliseconds = (Mathf.Floor(t * 100) % 100); // calculate the milliseconds for the timer

            seconds = (int)(t % 60); // return the remainder of the seconds divide by 60 as an int
            t /= 60; // divide current time y 60 to get minutes
            minutes = (int)(t % 60); //return the remainder of the minutes divide by 60 as an int


            //t /= 60; // divide by 60 to get hours
            //int hours = (int)(t % 24); // return the remainder of the hours divided by 60 as an int

            timerText.text = string.Format("{0}:{1}:{2}", /*hours.ToString("00"),*/ minutes.ToString("00"), seconds.ToString("00"), milliseconds.ToString("00"));

            /*"{0}:{0}:{1}:{2}"*/
            if (minutes == 35 && seconds == 0 && milliseconds == 0)
            {
                StartCoroutine(UploadJPG());
                StartCoroutine(CaptureIt());
            }
            /*"{0}:{0}:{1}:{2}"*/
            if (minutes == 40 && seconds == 0 && milliseconds == 0)
            {
                StartCoroutine(UploadJPG());
                StartCoroutine(CaptureIt());
            }
            if (minutes == 40 && seconds == 1 && milliseconds == 0)
            {
                StartCoroutine(UploadJPG());
                StartCoroutine(CaptureIt());
                waktuhabis.SetActive(true);
                Debug.Log("mandeng");
                lanjut = false;
            }
        }
        else
        {

        }
    }
    IEnumerator CaptureIt()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "Screenshot" + timeStamp + ".png";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

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
        string timeStamp = "1-1-" + LevelMain.text + "lewati";

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

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

    public void waktupenjelesaian()
    {
        Debug.Log(timerText.text);
        lanjut = false;
        //jika ditekan selesai maka submit waktu dengan cara ngirim timerText.text
    }
    public void waktutidakjadi()
    {
        Debug.Log(timerText.text);
        lanjut = true;
        //jika ditekan selesai maka submit waktu dengan cara ngirim timerText.text
    }
}
