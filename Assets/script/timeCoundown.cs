using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class timeCoundown : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    //public Text timeText;
    public TextMeshProUGUI timeText;

    public TextMeshProUGUI durasiMain;

    public GameObject waktuhabis;
    public GameObject waktuhampirhabis;

    public Text LevelMain;
    public Text tokenLogin;
    public Text idLogin;
    public Text namaPemain;
    public int detik;

    private int seconds;
    private int minutes;
    private float milliseconds;

    public Text Tnya;

    public float time;
    public int myInt;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void DisplayTime(float timeToDisplay)
    {
        detik = Mathf.FloorToInt(timeToDisplay);

        timeToDisplay += 1;

        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);
        milliseconds = Mathf.FloorToInt(timeToDisplay * 100) % 100;

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

       
        /*
        if (minutes == 5 && seconds == 0)
        {
            waktuhampirhabis.SetActive(true);
            StartCoroutine(UploadJPG());
            StartCoroutine(CaptureIt());

            if (minutes == 5 && seconds == 30)
            {
                if (waktuhampirhabis.activeInHierarchy)
                {
                    waktuhampirhabis.SetActive(false);
                }
                else
                {
                   
                }
            }

        } 
        if (minutes == 11 && seconds == 59 && milliseconds == 0)
        {
            StartCoroutine(UploadJPG2a());
            StartCoroutine(CaptureIt2a());
        } 
        if (minutes == 7 && seconds == 59 && milliseconds == 0)
        {
            StartCoroutine(UploadJPG2c());
            StartCoroutine(CaptureIt2c());
        } 
        if (minutes == 5 && seconds == 59 && milliseconds == 0)
        {
            StartCoroutine(UploadJPG2d());
            StartCoroutine(CaptureIt2d());
        }
        if (minutes == 3 && seconds == 59 && milliseconds == 0)
        {
            StartCoroutine(UploadJPG2e());
            StartCoroutine(CaptureIt2e());
        }
        if (minutes == 2 && seconds == 59 && milliseconds == 0)
        {
            StartCoroutine(UploadJPG2f());
            StartCoroutine(CaptureIt2f());
        }
        */
    }

    void Update()
    {

        float a = 1200 - timeRemaining;
        
        float minutesDurasi = (int)(a / 60);
        float secondsDurasi = (int)(a % 60);
        float milisecondDurasi = Mathf.Floor((a * 100) % 100);

        durasiMain.text = string.Format("{0}:{1}:{2}", /*hours.ToString("00"),*/ minutesDurasi.ToString("00"), secondsDurasi.ToString("00"), milisecondDurasi.ToString("00"));

        Tnya.text = detik.ToString();
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

                
            }
            else
            {
                //StartCoroutine(UploadJPG3());
                //StartCoroutine(CaptureIt3());
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                waktuhabis.SetActive(true);
                Debug.Log("mandeng");
            }
        }

        time += Time.deltaTime;

        if (time > 1f && timerIsRunning == true)
        {
            myInt++;
            time = 0f;
            //Debug.Log("manual detik" + myInt);

            if (myInt == 900)
            {
                waktuhampirhabis.SetActive(true);
                StartCoroutine(UploadJPG());
                StartCoroutine(CaptureIt());

                //Debug.Log("tes1");

                if (myInt == 310)
                {
                    waktuhampirhabis.SetActive(false);
                }

            }

            if (myInt == 600)
            {
                StartCoroutine(UploadJPG2a());
                StartCoroutine(CaptureIt2a());
                //Debug.Log("tes2");
            }
            if (myInt == 840)
            {
                StartCoroutine(UploadJPG2c());
                StartCoroutine(CaptureIt2c());
                //Debug.Log("tes3");

            }
            if (myInt == 960)
            {
                StartCoroutine(UploadJPG2d());
                StartCoroutine(CaptureIt2d());
                //Debug.Log("tes3");

            }
            if (myInt == 1080)
            {
                StartCoroutine(UploadJPG2e());
                StartCoroutine(CaptureIt2e());
                //Debug.Log("tes3");

            }
            if (myInt == 1140)
            {
                StartCoroutine(UploadJPG2f());
                StartCoroutine(CaptureIt2f());
                //Debug.Log("tes3");

            }
        }
    }
    IEnumerator CaptureIt()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_5 menit terakhir_" + detik.ToString() + ".jpeg";
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_5 menit terakhir_" + detik.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }

     IEnumerator CaptureIt2()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_5 menit_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForSeconds(1);
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForSeconds(1);

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_5 menit_" + detik.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }IEnumerator CaptureIt2a()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_10 menit terakhir_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2a()
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_10 menit terakhir_" + detik.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }IEnumerator CaptureIt2b()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_12 menit terakhir_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForSeconds(1);
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2b()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForSeconds(1);

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_12 menit terakhir_" + detik.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }IEnumerator CaptureIt2c()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_14 menit terakhir_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2c()
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_14 menit terakhir_" + detik.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }IEnumerator CaptureIt2d()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_16 menit terakhir_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2d()
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_16 menit terakhir_" + detik.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }
    IEnumerator CaptureIt2e()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_18 menit terakhir_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2e()
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_18 menit terakhir_" + detik.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }IEnumerator CaptureIt2f()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_19 menit terakhir_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2f()
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_19 menit terakhir_" + detik.ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text);
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }
     IEnumerator CaptureIt3()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_1_" + LevelMain.text + "_3.jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG3()
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
        string timeStamp = idLogin.text + "_1_" + LevelMain.text + "_3";

        // For testing purposes, also write to a file in the project folder
       // File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

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
        timerIsRunning = false;
        //jika ditekan selesai maka submit waktu dengan cara ngirim timerText.text
    }
    public void waktutidakjadi()
    {
        timerIsRunning = true;
        //jika ditekan selesai maka submit waktu dengan cara ngirim timerText.text
    }

    public void TakeSS()
    {
        StartCoroutine(CaptureIt());
        //StartCoroutine(UploadJPG());
    }

   
}