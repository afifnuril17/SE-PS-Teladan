using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject panelAwal;
    public GameObject panelAwal2;
    public GameObject panelklikmagnet;
    public GameObject paneldragpotngan;
    public GameObject panelunselect;

    public GameObject PopUpYakin;
    public GameObject PopUpMulaiMain;

    public bool magnet = false;
    public bool tutor = false;
    public bool unselect = false;

    public GameObject glowing;

    public GameObject panelselesai;

    public bool finish = false;

    public void selesai()
    {
        panelselesai.SetActive(false);
    }
    public void Ok()
    {
        panelAwal.SetActive(false);
        panelAwal2.SetActive(true);
    }
    public void Ok2()
    {
        panelAwal2.SetActive(false);
    }
    public void Ok3()
    {
        magnet = true;
        panelklikmagnet.SetActive(false);
        glowing.SetActive(true);
    }
    public void Ok4()
    {
        paneldragpotngan.SetActive(false);
    }
    public void Ok5()
    {
        finish = true;
        panelunselect.SetActive(false);
    }

    public void klikmagnet()
    {
        panelklikmagnet.SetActive(true);
    }

    public void klik2kali()
    {
        unselect = true;
        panelunselect.SetActive(true);
    }

    public void klikdrag()
    {
        paneldragpotngan.SetActive(true);
        tutor = true;
    }

    public void PopUpYakinMulaiGame()
    {
        PopUpYakin.SetActive(true);
        PopUpMulaiMain.SetActive(false);
    }
    public void PopUpTidakMulaiGame()
    {
        PopUpYakin.SetActive(false);
        PopUpMulaiMain.SetActive(false);
    }
    public void PopUpMulaiGame()
    {
        PopUpYakin.SetActive(false);
        PopUpMulaiMain.SetActive(true);
    }


}
