using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
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
    private float milliseconds;
    private int seconds;
    private int minutes;

    public float myInt;

    bool satuKirim = false;
    bool duaKirim = false;
    bool tigaKirim = false;
    bool empatKirim = false;

    // Start is called before the first frame update
    void Start()
    {
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
            myInt += Time.deltaTime;

            DisplayTime(myInt);
            
            if ((int)myInt == 420 && !satuKirim)
            {
                StartCoroutine(SatuUpload());
                satuKirim = true;
            }
            if ((int)myInt == 540 && !duaKirim)
            {
                StartCoroutine(DuaUpload());
                duaKirim = true;
            }
            if ((int)myInt == 720 && !tigaKirim)
            {
                timer5.SetActive(true);
                GetComponent<TextMeshProUGUI>().color = Color.red;
                StartCoroutine(TigaUploadJPG());
                tigaKirim = true;
            }
            if ((int)myInt == 725)
            {
                timer5.SetActive(false);
            }
            if ((int)myInt == 1020 && !empatKirim)
            {
                waktuhabis.SetActive(true);
                StartCoroutine(EmpatUploadJPG());
                lanjut = false;
                empatKirim = true;
            }
        }
    }

    void DisplayTime(float timeDisplay)
    {
        milliseconds = Mathf.FloorToInt(timeDisplay * 100) % 100;

        minutes = Mathf.FloorToInt(timeDisplay / 60);
        seconds = Mathf.FloorToInt(timeDisplay % 60);

        //milliseconds = (Mathf.Floor(timeDisplay * 100) % 100);
        //timeCount.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

    }

    IEnumerator SatuUpload()
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

        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_7 menit terakhir_" + ((int)myInt).ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();

        //===========================================================================================================//
        //EDIT AFIF ALLGAME

        form.AddField("token", btn_manager_Magnet.Control.token);
        form.AddField("id_event", btn_manager_Magnet.Control.id_event);
        form.AddField("id_peserta", btn_manager_Magnet.Control.id_peserta);
        form.AddField("id_game", btn_manager_Magnet.Control.id_game);
        if (SceneManager.GetActiveScene().name == "level2_tanoto")
        {
            form.AddField("nama_hirarki", "level_2");
        }
        else
        {
            form.AddField("nama_hirarki", "level_3");
        }
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }

    IEnumerator DuaUpload()
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
        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_9 menit terakhir_" + ((int)myInt).ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();

        //===========================================================================================================//
        //EDIT AFIF ALLGAME

        form.AddField("token", btn_manager_Magnet.Control.token);
        form.AddField("id_event", btn_manager_Magnet.Control.id_event);
        form.AddField("id_peserta", btn_manager_Magnet.Control.id_peserta);
        form.AddField("id_game", btn_manager_Magnet.Control.id_game);
        if (SceneManager.GetActiveScene().name == "level2_tanoto")
        {
            form.AddField("nama_hirarki", "level_2");
        }
        else
        {
            form.AddField("nama_hirarki", "level_3");
        }
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }
    
    IEnumerator TigaUploadJPG()
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

        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_12 menit terakhir_" + ((int)myInt).ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();

        //===========================================================================================================//
        //EDIT AFIF ALLGAME

        form.AddField("token", btn_manager_Magnet.Control.token);
        form.AddField("id_event", btn_manager_Magnet.Control.id_event);
        form.AddField("id_peserta", btn_manager_Magnet.Control.id_peserta);
        form.AddField("id_game", btn_manager_Magnet.Control.id_game);
        if (SceneManager.GetActiveScene().name == "level2_tanoto")
        {
            form.AddField("nama_hirarki", "level_2");
        }
        else
        {
            form.AddField("nama_hirarki", "level_3");
        }
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }
    
    IEnumerator EmpatUploadJPG()
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

        string timeStamp = idLogin.text + "_" + namaPemain.text + "_" + LevelMain.text + "_17 menit terakhir_" + ((int)myInt).ToString();

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../" + timeStamp + ".jpeg", bytes);

        WWWForm form = new WWWForm();

        //===========================================================================================================//
        //EDIT AFIF ALLGAME

        form.AddField("token", btn_manager_Magnet.Control.token);
        form.AddField("id_event", btn_manager_Magnet.Control.id_event);
        form.AddField("id_peserta", btn_manager_Magnet.Control.id_peserta);
        form.AddField("id_game", btn_manager_Magnet.Control.id_game);
        if (SceneManager.GetActiveScene().name == "level2_tanoto")
        {
            form.AddField("nama_hirarki", "level_2");
        }
        else
        {
            form.AddField("nama_hirarki", "level_3");
        }
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
            Debug.Log("Finished Uploading Screenshot");
        }
    }

    public void waktupenjelesaian()
    {
        lanjut = false;
    }
    public void waktutidakjadi()
    {
        lanjut = true;
    }
}
