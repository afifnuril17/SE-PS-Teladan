using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class loginBtn : MonoBehaviour
{
    public static loginBtn Control;
    public string token;
    public string id;


    public Text nama;
    public Text pass;

 

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(Control ==null)
        {
            Control = this;
        }
    }

    public void masuk()
    {
        StartCoroutine(login());
    }
    IEnumerator login()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (
            UnityWebRequest www = UnityWebRequest.Post("http://game.psikologicare.com/api/login?name=" + nama.text + "&password=" + pass.text + "", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                // Debug.Log (www.error);
                //error.text = www.downloadHandler.text;
                
                //error.text = "Username atau Password Anda Salah";
            }
            else
            {
                //menulogin.SetActive(false);
                //menuindentitas.SetActive(true);
                
                //Debug.Log(www.downloadHandler.text);
                //string dat = www.downloadHandler.text;


                JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(www.downloadHandler.data));
                token = jsonData["token"];
                id = jsonData["user_id"];

                Debug.Log(token);
                Debug.Log(jsonData);

                SceneManager.LoadScene("catatan");

                if (jsonData == null)
                {
                    Debug.Log("ora ono");
                }
                else
                {
                    int namaContoh = jsonData["attribute"].Count;
                    //string namaContoh = jsonData["attribute"]["nama"]["attribute"].ToString();
                    //string replaceNama = namaContoh.Replace("{", "");
                    Debug.Log(namaContoh);



                    if (jsonData["attribute"] == "text")
                    {
                        Debug.Log("attribute" + jsonData["attribute"]);
                    }

                    string namaNama = jsonData["attribute"]["nama"];

                    //Debug.Log(" nama " + namaNama);

                    string[] attributes = { "nama", "tgl_lahir", "jenis_kelamin", "pendidikan", "tempat_lahir", "alamat", "desa" };

                    string[] namaChid = { "attribute", "label", "type", "validator" };

                    for (int i = 0; i <= attributes.Length - 1; i++)
                    {

                        //Debug.Log(jsonData[attributes[0]]);
                        if (jsonData["attribute"][attributes[i]][namaChid[2]] == "text")
                        {

                            //string [] text = { jsonData["attribute"][attributes[i]][namaChid[1]] };

                            //Debug.Log("bentuk "+ jsonData["attribute"][attributes[i]][namaChid[1]]);


                            //Debug.Log("label nama count" + text.Length);

                            //labelTempat_lahir.text = jsonData["attribute"][attributes[i]][namaChid[1]];
                            //Debug.Log("input text" + jsonData["attribute"][attributes[i]][namaChid[1]]);

                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Nama")
                            {
                                //Nama.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Tempat Lahir")
                            {
                                //Tempat_Lahir.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Kewarganegaraan")
                            {
                               // Kewarganegaraan.SetActive(true);
                            }
                        }
                        if (jsonData["attribute"][attributes[i]][namaChid[2]] == "date")
                        {

                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Tgl Lahira")
                            {
                                //Tgl_lahir.SetActive(true);
                            }
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Tgl Tes")
                            {
                                //Tgl_Tes.SetActive(true);
                            }

                            //labelTgl_lahir.text = jsonData["attribute"][attributes[i]][namaChid[1]];

                            //Debug.Log("input date");
                        }
                        if (jsonData["attribute"][attributes[i]][namaChid[2]] == "radio")
                        {
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Gender")
                            {
                                //Jenis_kelamin.SetActive(true);
                            }
                            //labelJenis_kelamin.text = jsonData["attribute"][attributes[i]][namaChid[1]];

                            //Debug.Log("input radio");
                        }
                        if (jsonData["attribute"][attributes[i]][namaChid[2]] == "dropdown")
                        {
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Pendidikan Terakhir")
                            {
                               // Pendidikan.SetActive(true);
                            }
                            //labelPendidikan.text = jsonData["attribute"][attributes[i]][namaChid[1]];

                            //Debug.Log("input dropdown");
                        }
                        if (jsonData["attribute"][attributes[i]][namaChid[2]] == "textarea")
                        {
                            if (jsonData["attribute"][attributes[i]][namaChid[1]] == "Alamat Tinggal")
                            {
                                //Alamat.SetActive(true);
                            }

                            //labelAlamat.text = jsonData["attribute"][attributes[i]][namaChid[1]];

                            //Debug.Log("input textarea");

                        }

                    }

                    string value = "replaceNama";
                    //string[] result = namaContoh.Split(',');

                    ///Debug.Log(result);


                    char[] array = value.ToCharArray();

                    for (int i = 0; i < array.Length; i++)
                    {
                        char letter = array[i];
                        //Debug.Log("letter : " + letter);
                    }
                }

            }

        }

    }

}
