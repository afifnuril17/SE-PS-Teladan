using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kedap_kedip : MonoBehaviour
{
    public GameObject timerKedip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime % .5 < .2)
        {
            timerKedip.SetActive(false);

        }
        else
        {
            timerKedip.SetActive(true);

        }
    }
}
