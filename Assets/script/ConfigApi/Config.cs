using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Control;

    public string urlLogin;
    public string urlSaveBiodata;
    public string urlSaveScore;
    public string urlImage;
    public string urlWa;
    public string urlBtnExit;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Control == null)
        {
            Control = this;
        }

        //ALL GAME
        urlLogin = "http://allgame.gamifindo.com/api/login?";
        urlSaveBiodata = "http://allgame.gamifindo.com/api/peserta/insert";
        urlImage = "http://allgame.gamifindo.com/api/hasil/gc/store-file";
        urlSaveScore = "http://allgame.gamifindo.com/api/hasil/update";


        //urlLogin = "https://beta.gamifindo.com/api/login?";

        //urlSaveBiodata = "https://beta.gamifindo.com/api/biodata-save";


        //urlSaveScore = "https://beta.gamifindo.com/api/game/store-score";
        //urlImage = "https://beta.gamifindo.com/api/game/store-image";


        urlWa = "https://beta.gamifindo.com/api/login-form";
        urlBtnExit = "https://beta.gamifindo.com/api/finish-game";
    }

}
