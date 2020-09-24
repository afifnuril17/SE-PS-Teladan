using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_intruksi : MonoBehaviour
{
    public GameObject intruksi;
    public GameObject tutor;
    public GameObject gameplay;

    public int myTime;
    private float time;
    private bool Timernya = false;

    void Update()
    {
        time += Time.deltaTime;

        if(time > 1f && Timernya == false)
        {
            myTime++;
            time = 0;
        }

        if(myTime == 120)
        {
            Tutor();
            Timernya = true;
        }
    }
    public void Gametutorial()
    {
        intruksi.SetActive(false);
        tutor.SetActive(true);
        gameplay.SetActive(false);
        myTime = 0;

    } 
    public void GameMain()
    {
        intruksi.SetActive(false);
        tutor.SetActive(false);
        gameplay.SetActive(true);
        myTime = 0;

    }

    public void Tutor()
    {
        intruksi.SetActive(false);
        tutor.SetActive(true);
        myTime = 0;

    }

    public void Praktek()
    {
        intruksi.SetActive(false);
        tutor.SetActive(true);
        myTime = 0;

    }
}
