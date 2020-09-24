using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFlipnRotate : MonoBehaviour
{
    public GameObject[] bentuk;

    public void Hide()
    {
        for(int i = 0;i <= bentuk.Length -1; i++)
        {
            bentuk[i].GetComponent<ItemIDragHandler1_resivee>().btn_flip.gameObject.SetActive(false);
            bentuk[i].GetComponent<ItemIDragHandler1_resivee>().btn_rotate.gameObject.SetActive(false);
        }
    }
}
