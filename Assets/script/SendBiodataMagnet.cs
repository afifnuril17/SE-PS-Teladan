using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SendBiodataMagnet : MonoBehaviour
{
    public static SendBiodataMagnet Control;
    public string namaPemain;

    /*
    public Text namaInputan;
    public Text alamatInputan; 
    public Text tgl_lahirDay;
    public Text tgl_lahirMont;
    public Text tgl_lahirYear;
    public Text pendidikanInputan;
    public Text jenis_kelaminInputan;
    public Text tempat_lahirInputan;
    public Text kewarganegaraanInputan;
    public Text tgl_tesDay;
    public Text tgl_tesMont;
    public Text tgl_tesYear;
    public Text jabatanInputan;
    public Text departementInputan;
    public Text devisiInputan;
    public Text jenis_identitasInputan;
    public Text agamaInputan;
    public Text emailInputan;
    public Text institusi_pendidikanInputan;
    public Text jurusanInputan;
    public Text mengetahui_lowonganInputan;
    public Text penyakit_beratInputan;
    public Text no_sippInputan;
    public Text no_telpInputan;
    public Text NPMInputan;
    public Text tahun_masukInputan;
    public Text tahun_lulusInputan;
    public Text status_pernikahanInputan;
    public Text alamat_identitasInputan;
    public Text alamat_tinggalInputan;
    */
    public Text warning;

    public GameObject[] labelnya;
    public GameObject[] inputan_keAPi;

    public GameObject loading;
    public Text nama;
    public Text pass;


    public Text tokenLogin;

    public string tgl_lahir;
    public string tgl_tes;
    // Start is called before the first frame update

    public bool textwarning = false;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Control == null)
        {
            Control = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //tgl_lahir = tgl_lahirYear.text + "-" + tgl_lahirMont.text + "-" + tgl_lahirDay.text;
        //tgl_tes = tgl_tesYear.text + "-" + tgl_tesMont.text + "-" + tgl_tesDay.text;
    }

    public void Send()
    {
        StartCoroutine(PostRequest());
        loading.SetActive(true);
    }

    IEnumerator PostRequest()
    {

        WWWForm form2 = new WWWForm();

        for (int j = 0; j <= labelnya.Length - 1; j++)
        {

            //Debug.Log("label DBnya" + jsonData["attribute"][j][0]);
            form2.AddField("token", tokenLogin.text.ToString());

            if (inputan_keAPi[j].activeInHierarchy == true && labelnya[j].activeInHierarchy == true)
            {
                if (inputan_keAPi[j].transform.Find("InputField").gameObject.activeInHierarchy)
                {

                    form2.AddField(labelnya[j].transform.Find("chillAttribute").GetComponent<Text>().text.ToString(), inputan_keAPi[j].transform.Find("InputField").GetComponent<InputField>().text.ToString());


                    if (inputan_keAPi[j].transform.Find("InputField").GetComponent<InputField>().text == "")
                    {
                        textwarning = true;
                        //Debug.Log("kosong" + inputan_keAPi[j].name);
                        break;

                    }
                    else
                    {
                        textwarning = false;
                    }
                    
                    if (labelnya[j].transform.Find("chillAttribute").GetComponent<Text>().text == "nama")
                    {
                        namaPemain = inputan_keAPi[j].transform.Find("InputField").GetComponent<InputField>().text.ToString();
                        Debug.Log("NamaPemain" + namaPemain);
                    }
                    //Debug.Log("INPUT TEXT NYALA");

                }

                if (inputan_keAPi[j].transform.Find("DatePicker").gameObject.activeInHierarchy)
                {
                    form2.AddField(labelnya[j].transform.Find("chillAttribute").GetComponent<Text>().text.ToString(), inputan_keAPi[j].transform.Find("DatePicker").transform.Find("GameObject").transform.Find("year").transform.Find("year").GetComponent<InputField>().text.ToString() + "-" + inputan_keAPi[j].transform.Find("DatePicker").transform.Find("GameObject").transform.Find("month").transform.Find("month").GetComponent<InputField>().text.ToString() + "-" + inputan_keAPi[j].transform.Find("DatePicker").transform.Find("GameObject").transform.Find("day").transform.Find("day").GetComponent<InputField>().text.ToString());
                    //Debug.Log(jsonData["attribute"][j][0] + "coba lihat" + inputan_keAPi[j].transform.Find("DatePicker").transform.Find("GameObject").transform.Find("year").transform.Find("year").GetComponent<InputField>().text.ToString() + "-" + inputan_keAPi[j].transform.Find("DatePicker").transform.Find("GameObject").transform.Find("month").transform.Find("month").GetComponent<InputField>().text.ToString() + "-" + inputan_keAPi[j].transform.Find("DatePicker").transform.Find("GameObject").transform.Find("day").transform.Find("day").GetComponent<InputField>().text.ToString());
                }

                if (inputan_keAPi[j].transform.Find("Dropdown").gameObject.activeInHierarchy)
                {

                    int menuIndex = inputan_keAPi[j].transform.Find("Dropdown").GetComponent<Dropdown>().value;

                    List <Dropdown.OptionData> menuOption =  inputan_keAPi[j].transform.Find("Dropdown").GetComponent<Dropdown>().options;

                    string value = menuOption[menuIndex].text;

                    form2.AddField(labelnya[j].transform.Find("chillAttribute").GetComponent<Text>().text.ToString(), value);

                    Debug.Log("label dropdown" + value);
                
                }
            }
        }

        /*
        for (int i = 0; i <= inputan_keAPi.Length - 1; i++)
        {
            for(int y = 0; y<= jsonData["attribute"].Count; y++)
            {
                for(int x = 0; x<= jsonData["attribute"][y].Count; x++)
                if (inputan_keAPi[i].activeInHierarchy)
                {
                    if (inputan_keAPi[i].GetComponent<InputField>().placeholder.GetComponent<Text>().text == "Enter Text")
                    {
                        Debug.Log("Enter Text");
                        form2.AddField(jsonData["attribute"][i][y].ToString(), inputan_keAPi[i].GetComponent<InputField>().text.ToString());
                    }
                    if (inputan_keAPi[i].GetComponent<InputField>().placeholder.GetComponent<Text>().text == "YYYY-MM-DD")
                    {
                            Debug.Log("YYYY-MM-DD");
                            form2.AddField(jsonData["attribute"][i][y].ToString(), "2020-04-29");
                    }
                }

            }

        }

        */

        Debug.Log("SEND BIODATANYA BRO");
        /*

        form.AddField("alamat", alamatInputan.text.ToString());
        form.AddField("tgl_lahir", tgl_lahir);
        form.AddField("pendidikan", pendidikanInputan.text.ToString());
        form.AddField("jenis_kelamin", jenis_kelaminInputan.text.ToString());
        form.AddField("tempat_lahir", tempat_lahirInputan.text.ToString());


        form.AddField("tgl_tes", tgl_tes);

        form.AddField("kewarganegaraan", kewarganegaraanInputan.text.ToString());

        form.AddField("jabatan", jabatanInputan.text.ToString());


        form.AddField("departement", departementInputan.text.ToString());

        form.AddField("devisi", devisiInputan.text.ToString());
        form.AddField("no_sipp", no_sippInputan.text.ToString());
        form.AddField("jenis_identitas", jenis_identitasInputan.text.ToString());
        form.AddField("alamat_identitas", alamatInputan.text.ToString());
        form.AddField("status_pernikahan", status_pernikahanInputan.text.ToString());

        form.AddField("no_telp", no_telpInputan.text.ToString());
        form.AddField("agama", agamaInputan.text.ToString());
        form.AddField("email", emailInputan.text.ToString());
        form.AddField("institusi_pendidikan", institusi_pendidikanInputan.text.ToString());
        form.AddField("jurusan", jurusanInputan.text.ToString());
        form.AddField("tahun_masuk", tahun_masukInputan.text.ToString());
        form.AddField("tahun_lulus", tahun_lulusInputan.text.ToString());
        form.AddField("mengetahui_lowongan", mengetahui_lowonganInputan.text.ToString());
        form.AddField("penyakit_berat", pendidikanInputan.text.ToString());
        form.AddField("npm", NPMInputan.text.ToString());
      */

        UnityWebRequest biodata = UnityWebRequest.Post(Config.Control.urlSaveBiodata, form2);


        yield return biodata.SendWebRequest();

        //Debug.Log(biodata);

        if (biodata.isNetworkError || biodata.isHttpError)
        {
            Debug.Log("Error While Sending: " + biodata.error);
            loading.SetActive(false);
        }
        else
        {
            Debug.Log("Received: " + biodata.downloadHandler.text);

            if (textwarning == true)
            {
                loading.SetActive(false);

                warning.text = "Biodata harus disi";
            }
            else
            {
                loading.SetActive(false);

                SceneManager.LoadScene("catatan_magnet");
            }
        }
    }
}
