using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Networking;

public class timer2_3 : MonoBehaviour
{
    public Text LevelMain;
    public Text tokenLogin;
    public Text idLogin;
    public Text namaPemain;


    public GameObject waktuhabis;
    TextMeshProUGUI timerText;
    private bool lanjut= true;

    public GameObject timer5;
    public float startTime;
    private float milliseconds;
    private int seconds;
    private int minutes;
    public float t;
    public int detik;

    public float time;
    public int myInt;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
        milliseconds = 0;
        seconds = 0;
        minutes = 0;
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

            if (myInt == 300)
            {
                timer5.SetActive(true);
                GetComponent<TextMeshProUGUI>().color = Color.red;

                StartCoroutine(UploadJPG());
                StartCoroutine(CaptureIt());
                //Debug.Log("tes1");

                if (myInt == 310)
                {
                    timer5.SetActive(false);
                }

            }

            if (myInt == 420)
            {
                StartCoroutine(UploadJPG2());
                StartCoroutine(CaptureIt2());
                //Debug.Log("tes2");
            }
            if (myInt == 540)
            {
                StartCoroutine(UploadJPG2a());
                StartCoroutine(CaptureIt2a());
                //Debug.Log("tes3");

            }
            if (myInt == 600)
            {
                waktuhabis.SetActive(true);
                //Debug.Log("mandeng");
                lanjut = false;
            }

        }
    }
    void hitung()
    {
        if (lanjut == true)
        {
            detik = Mathf.FloorToInt(Time.timeSinceLevelLoad - startTime);
            t = Time.timeSinceLevelLoad - startTime; // time since scene loaded



            milliseconds = (Mathf.Floor(t * 100) % 100); // calculate the milliseconds for the timer

            seconds = (int)(t % 60); // return the remainder of the seconds divide by 60 as an int
            t /= 60; // divide current time y 60 to get minutes
            minutes = (int)(t % 60); //return the remainder of the minutes divide by 60 as an int


            //t /= 60; // divide by 60 to get hours
            //int hours = (int)(t % 24); // return the remainder of the hours divided by 60 as an int

            timerText.text = string.Format("{0}:{1}:{2}", /*hours.ToString("00"),*/ minutes.ToString("00"), seconds.ToString("00"), milliseconds.ToString("00"));




            /*"{0}:{0}:{1}:{2}"*/
            /*
             * 
            if (minutes == 5 && seconds == 0)
            {
                timer5.SetActive(true);
                GetComponent<TextMeshProUGUI>().color = Color.red;

                StartCoroutine(UploadJPG());
                StartCoroutine(CaptureIt());

                if (minutes == 5 && seconds == 30)
                {
                   if(timer5.activeInHierarchy)
                    {
                        timer5.SetActive(false);

                    }
                    else
                    {

                    }
                }

                
            }
            if (minutes == 6 && seconds == 59 && milliseconds == 0)
            {
                StartCoroutine(UploadJPG2());
                StartCoroutine(CaptureIt2());
            }
            if (minutes == 8 && seconds == 59 && milliseconds == 0)
            {
                StartCoroutine(UploadJPG2a());
                StartCoroutine(CaptureIt2a());
            }
            if (minutes == 10 && seconds == 1)
            {
                //StartCoroutine(UploadJPG3());
                //StartCoroutine(CaptureIt3());
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
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_7 menit terakhir_" + detik.ToString() +".jpeg";
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

        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_7 menit terakhir_" + detik.ToString();

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
    IEnumerator CaptureIt2a()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_9 menit terakhir_" + detik.ToString() +".jpeg";
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_9 menit terakhir_" + detik.ToString();

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
        yield return new WaitForSeconds(1);
        Debug.Log("Screenshoot");

    }

    IEnumerator UploadJPG3()
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
