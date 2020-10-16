using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class ConfigData2
{
    public int id;
    public string contact1;
    public string contact2;
}

public class getData2
{

    public ConfigData2 config;
}

public class api_waakhir : MonoBehaviour
{
  
    public Text no_waAkhir;
 
    public bool Tampil2 = false;

    void Start()
    {
        if(Tampil2 == false)
        {
            StartCoroutine(AkhirWa());
        }
    }
    IEnumerator AkhirWa()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Config.Control.urlWa))
        {
            yield return www.SendWebRequest();


            string dat = www.downloadHandler.text;
            getData2 json = JsonUtility.FromJson<getData2>(dat);

            //Debug.Log(json.config.id);

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                StartCoroutine(AkhirWa());
            }
            else
            {
                no_waAkhir.text = json.config.contact2;
                Tampil2 = true;
            }
        }
    }

    public void waAkhir()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=" + no_waAkhir.text.ToString() + "&text=Terima%20kasih%20telah%20menghubungi%20kami.%0A%0AMohon%20hapus%20pesan%20ini%20jika%20Anda%20tidak%20mengalami%20kendala%20selama%20proses%20bermain%20games.%0A%0ANamun%20Jika%20Anda%20mengalami%20kendala,%20laporkan%20dengan%20mengisi%20form%20berikut%20Klik:%20bit.ly/TesDaring2Akhir%0A%0ALaporan%20wajib%20kami%20terima%20maksimal%203%20jam%20setelah%20anda%20mengalami%20kendala.%0A%0AKami%20tidak%20menerima%20komunikasi%20via%20whatsapp%20ini%20dan%20juga%20media%20lainnya%20selain%20link%20aduan%20di%20atas.%0A%0ATerima%20kasih");
        //Application.OpenURL("https://api.whatsapp.com/send?phone=6282233477637&text=hai");
        //Debug.Log("https://whatsapp.com/send?phone=" + no_wa.text.ToString() + "&text=hai");
    }
}
