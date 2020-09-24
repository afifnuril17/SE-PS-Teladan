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
    public string id;


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

    public GameObject Nama;
    public GameObject Tgl_lahir;
    public GameObject Jenis_kelamin;
    public GameObject Pendidikan;
    public GameObject Tempat_Lahir;
    public GameObject Alamat;
    public GameObject Tgl_tes;
    public GameObject Kewarganegaraan;
    public GameObject Jabatan;
    public GameObject Departement;
    public GameObject Devisi;
    public GameObject Jenis_identitas;
    public GameObject Agama;
    public GameObject Email;
    public GameObject Institusi_pendidikan;
    public GameObject Jurusan;
    public GameObject Mengetahui_lowongan;
    public GameObject Penyakit_berat;
    public GameObject No_sipp;
    public GameObject No_telp;
    public GameObject NPM;
    public GameObject Tahun_masuk;
    public GameObject Tahun_lulus;
    public GameObject Status_Pernikahan;
    public GameObject Alamat_Identitas;
    public GameObject Alamat_Tinggal;


    public Text warningIde;
    public Text warningTentang;

    public Text SkipText;

    public GameObject loading;

    public GameObject PopUpSubmit;

    public Text[] labelnya;

    public GameObject[] inputan_text;

    public GameObject[] tanggal_text;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Control == null)
        {
            Control = this;
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

            SceneManager.LoadScene("level1_tanoto");
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
            UnityWebRequest www = UnityWebRequest.Post(Config.Control.urlLogin + "name=" + nama + "&password=" + pass + "", form))
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


                token = jsonData["token"];
                id = jsonData["user_id"];

                tokenInput.text = token;

                Debug.Log(jsonData);
                if (jsonData == null)
                {
                    Debug.Log("ora ono");
                }
                else
                {
                    int namaContoh = jsonData["attribute"]["nama"].Count;
                    //string namaContoh = jsonData["attribute"]["nama"]["attribute"].ToString();
                    //string replaceNama = namaContoh.Replace("{", "");

                    //Debug.Log( "jumlah chil nama" +namaContoh);

                    for(int i =0; i<= jsonData["attribute"].Count - 1; i++)
                    {
                      //Debug.Log(" text string attribute" + i + " -" + jsonData["attribute"][i].ToString());

                        for(int j = 0; j <= jsonData["attribute"][0].Count - 1; j++)
                        {

                            if (jsonData["attribute"][i][j] == "text")
                            {
                                labelnya[i].text = jsonData["attribute"][i][1];
                                labelnya[i].gameObject.SetActive(true);
                                labelnya[i].transform.Find("chillAttribute").GetComponent<Text>().text = jsonData["attribute"][i][0];

                                inputan_text[i].SetActive(true);
                                //inputan_text[i].GetComponent<GridLayoutGroup>().cellSize= new Vector3(350, 100);
                                inputan_text[i].transform.Find("InputField").gameObject.SetActive(true);
                                
                                inputan_text[i].transform.Find("InputField").GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Wajib diisi";

                                inputan_text[i].transform.Find("DatePicker").gameObject.SetActive(false);
                            }
                            if (jsonData["attribute"][i][j] == "date")
                            {
                                labelnya[i].text = jsonData["attribute"][i][1];
                                labelnya[i].gameObject.SetActive(true);
                                labelnya[i].transform.Find("chillAttribute").GetComponent<Text>().text = jsonData["attribute"][i][0];

                                inputan_text[i].SetActive(true);
                                inputan_text[i].GetComponent<GridLayoutGroup>().cellSize = new Vector3(350, 200);
                                inputan_text[i].transform.Find("InputField").gameObject.SetActive(false);
                                inputan_text[i].transform.Find("DatePicker").gameObject.SetActive(true);
                            }
                            if (jsonData["attribute"][i][j] == "textarea")
                            {
                                labelnya[i].text = jsonData["attribute"][i][1];
                                labelnya[i].gameObject.SetActive(true);
                                labelnya[i].transform.Find("chillAttribute").GetComponent<Text>().text = jsonData["attribute"][i][0];

                                inputan_text[i].SetActive(true);
                                inputan_text[i].transform.Find("InputField").gameObject.SetActive(true); 
                                inputan_text[i].transform.Find("InputField").GetComponent<InputField>().lineType = InputField.LineType.MultiLineNewline;
                                inputan_text[i].transform.Find("InputField").GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Wajib diisi";
                                inputan_text[i].transform.Find("DatePicker").gameObject.SetActive(false);

                            }
                            if(jsonData["attribute"][i][j] == "dropdown")
                            {
                                Debug.Log("VALUE DROBDON"+ jsonData["attribute"][i][3].Count);

                                labelnya[i].text = jsonData["attribute"][i][1];
                                labelnya[i].gameObject.SetActive(true);
                                labelnya[i].transform.Find("chillAttribute").GetComponent<Text>().text = jsonData["attribute"][i][0];

                                inputan_text[i].SetActive(true);
                                inputan_text[i].transform.Find("Dropdown").gameObject.SetActive(true);
                                inputan_text[i].transform.Find("InputField").gameObject.SetActive(false);
                                inputan_text[i].transform.Find("DatePicker").gameObject.SetActive(false);

                                var dropdown = inputan_text[i].transform.Find("Dropdown").GetComponent<Dropdown>();

                                dropdown.options.Clear();;                                
                                for (int x = 0; x <= jsonData["attribute"][i][3].Count - 1; x++)
                                {
                                    List<String> valueDropdown = new List<string>();

                                    valueDropdown.Add(jsonData["attribute"][i][3][x]);

                                    foreach (var item in valueDropdown)
                                    {
                                        dropdown.options.Add(new Dropdown.OptionData() { text = item });
                                    }
                                    //dropdown.options.Add(new Drop)
                                }
                                

                            }

                        }
                        
                    }



                    //NamaRoot root = JsonUtility.FromJson<NamaRoot>(jsonData.ToString());

                    //Debug.Log(root);
                    //Debug.Log("label ke 0 " + root.attribute[0].label);

                    /*

                    if (jsonData["attribute"] == "text")
                    {
                        Debug.Log("attribute" + jsonData["attribute"]);
                    }

                   // string [] namaNama = { jsonData["attribute"].ToString() };


                  //  Debug.Log(" nama " + namaNama);

                    string[] attributes = {"nama", "tgl_lahir", "jenis_kelamin", "pendidikan", "tempat_lahir", "alamat","tgl_tes","kewarganegaraan","jabatan","departement","devisi","no_sipp","jenis_identitas", "alamat_identitas", "alamat_tinggal","status_pernikahan","no_telp","agama","email","institusi_pendidikan","jurusan","tahun_masuk","tahun_lulus","mengetahui_lowongan","penyakit_berat","npm"};

                    string[] namaChid = { "attribute", "label", "type", "validator" };

                    for(int i = 0;i <= attributes.Length-1;i++)
                    {
                        
                        //Debug.Log(jsonData[attributes[0]]);
                        if (jsonData["attribute"][attributes[i]][namaChid[2]] == "text")
                        {

                            if(jsonData["attribute"][attributes[i]][namaChid[1]] == "Nama")
                            {
                                 Nama.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Tempat Lahir")
                            {
                                Tempat_Lahir.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Kewarganegaraan")
                            {
                                Kewarganegaraan.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Jabatan")
                            {
                                
                                Jabatan.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Departement")
                            {
                                Departement.SetActive(true);
                            } 
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Devisi")
                            {
                                Devisi.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Jenis Identitas")
                            {
                                Jenis_identitas.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Agama")
                            {
                                Agama.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Email")
                            {
                                Email.SetActive(true);
                            } 
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Institusi Pendidikan")
                            {
                                Institusi_pendidikan.SetActive(true);
                            } 
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Jurusan")
                            {
                                Jurusan.SetActive(true);
                            } 
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Mengetahui Lowongan")
                            {
                                Mengetahui_lowongan.SetActive(true);
                            } 
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Penyakit Berat")
                            {
                                Penyakit_berat.SetActive(true);
                            }
                        }
                        if (jsonData["attribute"][attributes[i]][namaChid[2]] == "integer")
                        {
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Nomor SIPP")
                            {
                                No_sipp.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "No Telpon")
                            {
                                No_telp.SetActive(true);
                            }if (jsonData["attribute"][attributes[i]][namaChid[1]] == "NPM")
                            {
                                NPM.SetActive(true);
                            }

                        }
                        if(jsonData["attribute"][attributes[i]][namaChid[2]] == "date")
                        {

                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Tgl Lahira")
                            {
                                Tgl_lahir.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Tgl Tes")
                            {
                                Tgl_tes.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Tahun Masuk")
                            {
                                Tahun_masuk.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Tahun Lulus")
                            {
                                Tahun_lulus.SetActive(true);
                            }

                            //labelTgl_lahir.text = jsonData["attribute"][attributes[i]][namaChid[1]];

                            //Debug.Log("input date");
                        } 
                        if(jsonData["attribute"][attributes[i]][namaChid[2]] == "radio")
                        {
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Gender")
                            {
                                Jenis_kelamin.SetActive(true);
                            }
                            //labelJenis_kelamin.text = jsonData["attribute"][attributes[i]][namaChid[1]];

                            //Debug.Log("input radio");
                        }
                        if(jsonData["attribute"][attributes[i]][namaChid[2]] == "dropdown")
                        {
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Pendidikan Terakhir")
                            {
                                Pendidikan.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Status Pernikahan")
                            {
                                Status_Pernikahan.SetActive(true);
                            }
                           //labelPendidikan.text = jsonData["attribute"][attributes[i]][namaChid[1]];

                            //Debug.Log("input dropdown");
                        }
                        if(jsonData["attribute"][attributes[i]][namaChid[2]] == "textarea")
                        {
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Alamat Tinggal")
                            {
                                Alamat.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Alamat Identitas")
                            {
                                Alamat_Identitas.SetActive(true);
                            }

                            //labelAlamat.text = jsonData["attribute"][attributes[i]][namaChid[1]];

                            //Debug.Log("input textarea");

                        }

                    }

                    string value =  "replaceNama";
                    //string[] result = namaContoh.Split(',');

                    ///Debug.Log(result);


                    char[] array = value.ToCharArray();

                    for(int i = 0; i< array.Length; i++)
                    {
                        char letter = array[i];
                        //Debug.Log("letter : " + letter);
                    }
                    */
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