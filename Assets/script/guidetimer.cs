using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guidetimer : MonoBehaviour
{
    private int time;
    public int tekan;
    public GameObject guide;
    public GameObject help;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        print(tekan);


        time = time + 1;

        if (time == 100)
        {
            guide.SetActive(false);
            time = 0;
        }

        if(tekan == 3)
        {
            help.SetActive(false);
        }
    }
}
