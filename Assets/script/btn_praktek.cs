using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_praktek : MonoBehaviour
{
    public GameObject intruksi;
    public GameObject tutor;
    public GameObject gameplay;

    public void Gametutorial()
    {
        intruksi.SetActive(false);
        tutor.SetActive(true);
        gameplay.SetActive(false);
     
    } 
    public void GameMain()
    {
        intruksi.SetActive(false);
        tutor.SetActive(false);
        gameplay.SetActive(true);
   }

    public void Tutor()
    {
        intruksi.SetActive(false);
        tutor.SetActive(true);

    }

    public void Praktek()
    {
        intruksi.SetActive(false);
        tutor.SetActive(true);
    
    }
}
