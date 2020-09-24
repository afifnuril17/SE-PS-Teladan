using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Networking;

public class timer5AB : MonoBehaviour
{
    public GameObject waktuhabis;
    public GameObject timer5;

    TextMeshProUGUI timerText;
    private bool lanjut= true;

    public Text LevelMain;
    public Text tokenLogin;
    public Text idLogin;
    public Text namaPemain;
    public int detik;

    public float time;
    public int myInt;
    // Start is called before the first frame update
    void Start()
    {
        
        timerText = GetComponentInChildren<TMPro.TextMeshProUGUI>(); // cache the text component
    }

    // Update is called once per frame
    void Update()
    {
        if (lanjut == true)
        {
            hitung();
        }
        time += Time.deltaTime;

        if (time > 1f && lanjut == true)
        {
            myInt++;
            time = 0f;
            //Debug.Log("manual detik" + myInt);

            if (myInt == 900)
            {
                GetComponent<TextMeshProUGUI>().color = Color.red;

                timer5.SetActive(true);
                StartCoroutine(UploadJPG());
                StartCoroutine(CaptureIt());

                //Debug.Log("tes1");

                if (myInt == 310)
                {
                    timer5.SetActive(false);
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
            if (myInt == 1200)
            {
                waktuhabis.SetActive(true);
                Debug.Log("mandeng");
                lanjut = false;
            }

        }
    }
    void hitung()
    {
        if (lanjut == true)
        {
            detik = Mathf.FloorToInt(Time.timeSinceLevelLoad);

            float t = Time.timeSinceLevelLoad; // time since scene loaded


            float milliseconds = (Mathf.Floor(t * 100) % 100); // calculate the milliseconds for the timer

            int seconds = (int)(t % 60); // return the remainder of the seconds divide by 60 as an int
            t /= 60; // divide current time y 60 to get minutes
            int minutes = (int)(t % 60); //return the remainder of the minutes divide by 60 as an int


            //t /= 60; // divide by 60 to get hours
            //int hours = (int)(t % 24); // return the remainder of the hours divided by 60 as an int

            timerText.text = string.Format("{0}:{1}:{2}", /*hours.ToString("00"),*/ minutes.ToString("00"), seconds.ToString("00"), milliseconds.ToString("00"));

            /*
             * 
            if (minutes == 20 && seconds == 0 && milliseconds == 0)
            {
                GetComponent<TextMeshProUGUI>().color = Color.red;
                timer5.SetActive(true);
                StartCoroutine(UploadJPG());
                StartCoroutine(CaptureIt());

                if (minutes == 20 && seconds == 30)
                {
                    if (timer5.activeInHierarchy)
                    {
                        timer5.SetActive(false);
                    }
                    else
                    {
                    }
                }
                
            }
            "{0}:{0}:{1}:{2}"
            if (minutes == 25 && seconds == 0 && milliseconds == 0)
            {
                StartCoroutine(UploadJPG2());
                StartCoroutine(CaptureIt2());
            }
            if (minutes == 25 && seconds == 1 && milliseconds == 0)
            {
               // StartCoroutine(UploadJPG());
                //StartCoroutine(CaptureIt());
                waktuhabis.SetActive(true);
                Debug.Log("mandeng");
                lanjut = false;
            }
            */
        }
        else
        {

        }
    }
    IEnumerator CaptureIt()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_5 menit terakhir_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForSeconds(1);
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG()
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
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_25 menit habis_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2()
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_25 menit habis_" + detik.ToString();

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
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
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
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_25 menit habis_" + detik.ToString() + ".jpeg";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);

        //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
    IEnumerator UploadJPG2b()
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_25 menit habis_" + detik.ToString();

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
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
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
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
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
    }IEnumerator CaptureIt2e()
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
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
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
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
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
