using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using SimpleJSON;
using Newtonsoft.Json;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;

 
//[ExecuteInEditMode]

public class btn_manager_Magnet : MonoBehaviour
{
    public static btn_manager_Magnet Control;
    public string token;
    public string id_peserta;
    public string id_event;
    public string id_game;

    public List<string> scene;
    public int sceneInt;

    public Text ide;
    public Text alasan;
    public Text tentang;


    private GUIStyle guiStyle = new GUIStyle();
    public bool debugMode;
    public Rect positionLabel = new Rect(200, 15, 150, 25);
    public string textLabel = "";

    //next_page
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    public GameObject lewati;

    public Text tokenInput;

    public string hal1;
    public string hal2;
    public string hal3;
    public GameObject parent;
    //next_page

    // panel o
    public GameObject o_panel;
    public GameObject o_sembunyi;

    // panel o


    //api login
    public InputField name;
    private string nama;

    public InputField password;
    private string pass;

    public Text error;

    public Text no_wa;


    public string[] items;
    //api login



    //toggle
    public Toggle cat;
    public Toggle cat2;

    public Text toggleError;

    public Toggle laki;
    public Toggle perempuan;

    //toggle

    //canvas main menu dan identitas
    public GameObject awallogin;
    public GameObject menulogin;
    public GameObject menuindentitas;
    //canvas main menu dan identitas

    //canvas6 awal dan akhir
    public GameObject level6depan;
    public GameObject level6tutor;
    public GameObject level6main;
    public GameObject level6akhir;

    public GameObject levelterakhir;
    //canvas6 awal dan akhir

    //cocokkan
    public GameObject guide;
    public GameObject cocokkan;
    public GameObject btn_cocok;
    public GameObject btn_submit;
    public GameObject timercocokan;
    //cocokkan

    public Text label;

    //api identiats
 
    public Text [] labelNama;
   
    //public Text labelTempat_lahir;

    public Text labelTgl_lahir;
    public Text labelJenis_kelamin;
    public Text labelPendidikan;
    public Text labelAlamat;
    //api identiats


    //id
    public Text IdLogin;

    public GameObject waktu_hampir_habis;

    public Text warningIde;
    public Text warningTentang;

    public Text SkipText;

    public GameObject loading;

    public GameObject PopUpSubmit;

    public Text[] labelnya;

    public GameObject[] inputan_text;

    public GameObject[] tanggal_text;

    //COBA KELOMPOKAN AB,C,D EDIT AFIF
    public int[] game_id;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "main_menu_magnet")
        {
            DontDestroyOnLoad(gameObject);
            if (Control == null)
            {
                Control = this;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hal1 = "aktif";
        hal2 = "takaktif";
        hal3 = "takaktif";

        //StartCoroutine(no_wa_awal());
        //StartCoroutine(api_wa());
    }


    // Update is called once per frame
    void Update()
    {
        OnGUI();
        //StartCoroutine(no_wa_awal());
        //StartCoroutine(no_wa_akhir());
        //print(hal1);
    }

    public void PopUpSelesai()
    {
        PopUpSubmit.SetActive(true);
    }
    public void PopUpBelumSelesai()
    {
        PopUpSubmit.SetActive(false);
    }

    public void tutup_waktu_hampir_habis()
    {
        waktu_hampir_habis.SetActive(false);
    }
    public void panel_tampil()
    {
        o_panel.SetActive(true);
    }
    public void panel_sembunyi()
    {
        o_panel.SetActive(false);
    }

    public void cocok()
    {
        //StartCoroutine(PostRequest());

        cocokkan.SetActive(true);
    }

    public void cocokiya()
    {
        cocokkan.SetActive(false);
        guide.SetActive(true);
        timercocokan.SetActive(true);
        timercocokan.GetComponent<timercocokan>().enabled = true;
        btn_cocok.SetActive(false);
        btn_submit.SetActive(true);
    }
    public void cocokiya30detik()
    {
        cocokkan.SetActive(false);
        guide.SetActive(true);
        timercocokan.SetActive(true);

        btn_cocok.SetActive(false);
        btn_submit.SetActive(true);
    }
   
    public void cocoktidak()
    {
        cocokkan.SetActive(false);
        btn_cocok.SetActive(true);
    }

    public void halaman2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page3.SetActive(false);

        hal1 = "takaktif";
        hal2 = "aktif";
        hal3 = "takaktif";
    }

    public void halaman1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);

        hal1 = "aktif";
        hal2 = "takaktif";
        hal3 = "takaktif";
    }
    public void halaman3()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);

        hal1 = "takaktif";
        hal2 = "takaktif";
        hal3 = "aktif";
    }

    public void lewat()
    {
        SkipText.text = "1";
        lewati.SetActive(true);
    }

    public void tdklewat()
    {
        SkipText.text = "0";
        lewati.SetActive(false);
    }
    public void iyalewat()
    {
        //SceneManager.LoadScene("level2");
        Debug.Log("Pindah Scene");
    }

    public void showpass()
    {
        password.contentType = InputField.ContentType.Standard;
    }
    public void menu_login()
    {
        awallogin.SetActive(false);
        menulogin.SetActive(true);
        menuindentitas.SetActive(false);
      
    }
    public void iden()
    {
        nama = name.text.ToString();
        pass = password.text.ToString();
        StartCoroutine(login());
        
        loading.SetActive(true);
        
        //awallogin.SetActive(false);
        //menulogin.SetActive(false);
        //menuindentitas.SetActive(true);

    }
    public void catat()
    {
        StartCoroutine(catatan());
    }

    IEnumerator catatan()
    {
        SceneManager.LoadScene("catatan");
        yield return new WaitForSeconds(100);

    }


    public void help()
    {
        guide.SetActive(true);

        guide.GetComponent<guidetimer>().tekan++;
    }

    public void level1()
    {
        if (cat.GetComponent<Toggle>().isOn == true && cat2.GetComponent<Toggle>().isOn == true)
        {
            loading.SetActive(true);

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
        else
        {
            toggleError.text = "Anda Belum Mencentang Seluruh Persetujuan";
        }
    }

    public void level2()
    {
        SceneManager.LoadScene("level2_tanoto");
    }
    public void level3()
    {
        SceneManager.LoadScene("level3_tanoto");
    }
    public void level4A()
    {
        SceneManager.LoadScene("level4_tanoto");
    } 
    public void level4B()
    {
        SceneManager.LoadScene("level5_tanoto");
    }
    public void level5A()
    {
        SceneManager.LoadScene("level5A_tanoto_magnet");
    }
    public void level5B()
    {
        SceneManager.LoadScene("level5B_tanoto_magnet");
    } 
    public void level6()
    {
        SceneManager.LoadScene("level6_tanoto");
    }

    public void level6videonya()
    {
        if (ide.text != "" && alasan.text != "")
        {
            level6depan.SetActive(false);
            level6tutor.SetActive(true);
            level6main.SetActive(false);
            //level6akhir.SetActive(false);
        }
        else
        {
            warningIde.text = "Anda harus mengisi semua inputan";
        }
        
    }

    public void level6mainnya()
    {
        if (ide.text != "" && alasan.text != "")
        {
            level6depan.SetActive(false);
            level6tutor.SetActive(false);
            level6main.SetActive(true);
            CaptureIt();
        }
        else
        {
            warningIde.text = "Anda harus mengisi semua inputan";
        }
        //level6akhir.SetActive(false);
    }

    public void halaman_akhir()
    {
        SceneManager.LoadScene("main_akhir");
    }

    public void halaman_paling_akhir()
    {
        if (tentang.text != "")
        {
            level6akhir.SetActive(false);
            levelterakhir.SetActive(true);
        }

        else
        {
            warningTentang.text = "Anda harus mengisi semua inputan";
        }
    }

    

    void CaptureIt()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "level6" + timeStamp + ".png";
        string pathToSave = fileName;

        ScreenCapture.CaptureScreenshot(pathToSave);

          //submit ke api( ScreenCapture.CaptureScreenshot(pathToSave);
        Debug.Log("Screenshoot");

    }

    IEnumerator login()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (
            UnityWebRequest www = UnityWebRequest.Post(Config.Control.urlLogin + "username=" + nama + "&password=" + pass + "", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                // Debug.Log (www.error);
                //error.text = www.downloadHandler.text;
                error.text = "Username atau Password Anda Salah";
                loading.SetActive(false);


            }
            else
            {
                loading.SetActive(false);

                menulogin.SetActive(false);
                menuindentitas.SetActive(true);
                //Debug.Log(www.downloadHandler.text);
                //string dat = www.downloadHandler.text;


                JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(www.downloadHandler.data));


                token = jsonData["data"]["token"];
                id_peserta = jsonData["data"]["id_peserta"];
                id_event = jsonData["data"]["id_event"];
                id_game = jsonData["data"]["listGame"][0]["id_game"];

                tokenInput.text = token;

                Debug.Log(jsonData);
                if (jsonData == null)
                {
                    Debug.Log("ora ono");
                }
                else
                {
                    //int namaContoh = jsonData["attribute"]["nama"].Count;
                    //string namaContoh = jsonData["attribute"]["nama"]["attribute"].ToString();
                    //string replaceNama = namaContoh.Replace("{", "");

                    //Debug.Log( "jumlah chil nama" +namaContoh);


                    /*
                    for (int i = 0; i < code.Length; i++)
                    {
                        if (code[i] == "SFEA")
                        {
                            scene.Add("level1_tanoto");
                            scene.Add("level2_tanoto");
                            scene.Add("level3_tanoto");
                        }
                        if (code[i] == "SFEB")
                        {
                            scene.Add("level4_tanoto");
                            scene.Add("level5_tanoto");
                            scene.Add("level6_tanoto");
                        }
                        if (code[i] == "SFEC")
                        {
                            scene.Add("level7_tanoto");
                        }
                        if (code[i] == "SFED")
                        {
                            scene.Add("level8_tanoto");
                        }
                        if (code[i] == "SFEX")
                        {
                            scene.Add("level1_tanoto");
                            scene.Add("level2_tanoto");
                            scene.Add("level3_tanoto");
                            scene.Add("level4_tanoto");
                            scene.Add("level5_tanoto");
                            scene.Add("level6_tanoto");
                            scene.Add("level7_tanoto");
                            scene.Add("level8_tanoto");
                        }
                    }
                    */

                    //=======================================================================================================================
                    
                    
                    for (int i = 0; i < jsonData["data"]["listGame"].Count; i++)
                    {
                        for (int j = 0; j < game_id.Length; j++)
                        {
                            if (jsonData["data"]["listGame"][i]["id_game"] == game_id[j])
                            {

                                if (jsonData["data"]["listGame"][i]["code_game"] == "SFEA")
                                {
                                    scene.Add("level1_tanoto");
                                    scene.Add("level2_tanoto");
                                    scene.Add("level3_tanoto");
                                }
                                if (jsonData["data"]["listGame"][i]["code_game"] == "SFEB")
                                {
                                    scene.Add("level4_tanoto");
                                    scene.Add("level5_tanoto");
                                    scene.Add("level6_tanoto");
                                }
                                if (jsonData["data"]["listGame"][i]["code_game"] == "SFEC")
                                {
                                    scene.Add("level7_tanoto");
                                }
                                if (jsonData["data"]["listGame"][i]["code_game"] == "SFED")
                                {
                                    scene.Add("level8_tanoto");
                                }
                                if (jsonData["data"]["listGame"][i]["code_game"] == "SFEX")
                                {
                                    scene.Add("level1_tanoto");
                                    scene.Add("level2_tanoto");
                                    scene.Add("level3_tanoto");
                                    scene.Add("level4_tanoto");
                                    scene.Add("level5_tanoto");
                                    scene.Add("level6_tanoto");
                                    scene.Add("level7_tanoto");
                                    scene.Add("level8_tanoto");
                                }
                            }
                        }
                    }

                    //============================================================================================================================
                   
                    for (int i =0; i<= jsonData["data"]["biodata"].Count - 1; i++)
                    {
                      //Debug.Log(" text string attribute" + i + " -" + jsonData["attribute"][i].ToString());

                        //EDIT AFIF
                        //for(int j = 0; j <= jsonData["data"]["biodata"].Count - 1; j++)
                        //{

                            if (jsonData["data"]["biodata"][i][2] == "text")
                            {
                                labelnya[i].text = jsonData["data"]["biodata"][i][1];
                                labelnya[i].gameObject.SetActive(true);
                                labelnya[i].transform.Find("chillAttribute").GetComponent<Text>().text = jsonData["data"]["biodata"][i][0];

                                inputan_text[i].SetActive(true);
                                //inputan_text[i].GetComponent<GridLayoutGroup>().cellSize= new Vector3(350, 100);
                                inputan_text[i].transform.Find("InputField").gameObject.SetActive(true);
                                
                                inputan_text[i].transform.Find("InputField").GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Wajib diisi";

                                inputan_text[i].transform.Find("DatePicker").gameObject.SetActive(false);
                            }
                            if (jsonData["data"]["biodata"][i][2] == "date")
                            {
                                labelnya[i].text = jsonData["data"]["biodata"][i][1];
                                labelnya[i].gameObject.SetActive(true);
                                labelnya[i].transform.Find("chillAttribute").GetComponent<Text>().text = jsonData["data"]["biodata"][i][0];

                                inputan_text[i].SetActive(true);
                                inputan_text[i].GetComponent<GridLayoutGroup>().cellSize = new Vector3(350, 200);
                                inputan_text[i].transform.Find("InputField").gameObject.SetActive(false);
                                inputan_text[i].transform.Find("DatePicker").gameObject.SetActive(true);
                            }
                            if (jsonData["data"]["biodata"][i][2] == "textarea")
                            {
                                labelnya[i].text = jsonData["data"]["biodata"][i][1];
                                labelnya[i].gameObject.SetActive(true);
                                labelnya[i].transform.Find("chillAttribute").GetComponent<Text>().text = jsonData["data"]["biodata"][i][0];

                                inputan_text[i].SetActive(true);
                                inputan_text[i].transform.Find("InputField").gameObject.SetActive(true); 
                                inputan_text[i].transform.Find("InputField").GetComponent<InputField>().lineType = InputField.LineType.MultiLineNewline;
                                inputan_text[i].transform.Find("InputField").GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Wajib diisi";
                                inputan_text[i].transform.Find("DatePicker").gameObject.SetActive(false);

                            }
                            if(jsonData["data"]["biodata"][i][2] == "dropdown")
                            {
                                Debug.Log("VALUE DROBDON"+ jsonData["attribute"][i][3].Count);

                                labelnya[i].text = jsonData["data"]["biodata"][i][1];
                                labelnya[i].gameObject.SetActive(true);
                                labelnya[i].transform.Find("chillAttribute").GetComponent<Text>().text = jsonData["data"]["biodata"][i][0];

                                inputan_text[i].SetActive(true);
                                inputan_text[i].transform.Find("Dropdown").gameObject.SetActive(true);
                                inputan_text[i].transform.Find("InputField").gameObject.SetActive(false);
                                inputan_text[i].transform.Find("DatePicker").gameObject.SetActive(false);

                                var dropdown = inputan_text[i].transform.Find("Dropdown").GetComponent<Dropdown>();

                                dropdown.options.Clear();;                                
                                for (int x = 0; x <= jsonData["data"]["biodata"][i][3].Count - 1; x++)
                                {
                                    List<String> valueDropdown = new List<string>();

                                    valueDropdown.Add(jsonData["data"]["biodata"][i][3][x]);

                                    foreach (var item in valueDropdown)
                                    {
                                        dropdown.options.Add(new Dropdown.OptionData() { text = item });
                                    }
                                    //dropdown.options.Add(new Drop)
                                }
                              
                        }
                        
                    }
                }

            }

        }

    }
   


    IEnumerator PostRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9nYW1lLnBzaWtvbG9naWNhcmUuY29tXC9hcGlcL2xvZ2luIiwiaWF0IjoxNTk3NzQyMjg4LCJleHAiOjE1OTc3NDU4ODgsIm5iZiI6MTU5Nzc0MjI4OCwianRpIjoiYzdLNUp1b2F1OHJaODd6cCIsInN1YiI6MSwicHJ2IjoiODdlMGFmMWVmOWZkMTU4MTJmZGVjOTcxNTNhMTRlMGIwNDc1NDZhYSJ9.JD2vXB6qzFaAyoybhmvT5yKa0vJf16sMx3wBuSSz_EA");
        form.AddField("score", "226");

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

    public void OnGUI()
    {
        if (debugMode || Application.isPlaying)
        {
            guiStyle.fontSize = 50;
            //GUI.Label(positionLabel, textLabel, guiStyle);
        }
    }

}