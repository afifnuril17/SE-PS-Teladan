using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bentuk_tutorial : MonoBehaviour
{
    public GameObject PanahMagnet;
    public GameObject PanahObjek;

    public GameObject Potongan;
    public GameObject Kekiri;
    public GameObject Drag;
    public GameObject RotateKlik;
    public GameObject Rotate;
    public GameObject Flip;
    public GameObject Klik_Magnet;
    public GameObject Dua_Magnet;
    public GameObject Pilih_Magnet;
    public GameObject Geser_Magnet;
    public GameObject Unselect_Magnet;


    public GameObject btn_up;

    public bool Pertama = false;
    public bool Kedua = false;
    public bool Ketiga = false;
    public bool Keempat = false;
    public bool Kelima = false;
    public bool Keenam = false;

    public GameObject btn_lanjut;
    public GameObject textLanjut;
    public bool Lanjut = false;

    public void GeserObjekArea()
    {
        PanahObjek.SetActive(false);
        Potongan.SetActive(false);
        Drag.SetActive(true);
        Kekiri.SetActive(true);
        Pertama = true;
    }
    public void GeserPart()
    {
       
        Kekiri.SetActive(false);
        Drag.SetActive(false);
        RotateKlik.SetActive(true);
        Rotate.SetActive(true);
        Flip.SetActive(true);
        //btn_up.GetComponent<Button>().enabled = false;
        Kedua = true;

    }
    public void FlipRotatePart()
    {
        RotateKlik.SetActive(false);
        Rotate.SetActive(false);
        Flip.SetActive(false);
        Dua_Magnet.SetActive(true);

        Kekiri.SetActive(false);
        Drag.SetActive(false);



        //btn_up.GetComponent<Button>().enabled = true;

        Ketiga = true;
    }
    public void MagnetKlik()
    {
        Dua_Magnet.SetActive(false);
        PanahMagnet.SetActive(true);
        Klik_Magnet.SetActive(true);
        Keempat = true;
    }
    public void MagnetPilih()
    {
        PanahMagnet.SetActive(false);
        Klik_Magnet.SetActive(false);
        Pilih_Magnet.SetActive(true);
        Geser_Magnet.SetActive(true);
        Kelima = true;
    }
    public void MagnetUnselect()
    {
        Pilih_Magnet.SetActive(false);
        Geser_Magnet.SetActive(false);
        Unselect_Magnet.SetActive(true);
        Keenam = true;
    }
    public void FinishTutorial()
    {
        Unselect_Magnet.SetActive(false);
        textLanjut.gameObject.SetActive(true);
        btn_lanjut.SetActive(true);
        Lanjut = true;

    }


}
