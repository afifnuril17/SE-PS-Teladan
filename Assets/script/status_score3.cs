using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class status_score3 : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;
    public GameObject part5;
    public GameObject part6;
    public GameObject part7;
    public GameObject part8;
    public GameObject part9;
    public GameObject part10;
    public GameObject part11;
    public GameObject part12;
    public GameObject part13;
    public GameObject part14;

    public Text status;
    public GameObject objek_dibuat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(part1.transform.parent == objek_dibuat.transform && part2.transform.parent == objek_dibuat.transform && part3.transform.parent == objek_dibuat.transform && part4.transform.parent == objek_dibuat.transform && part5.transform.parent == objek_dibuat.transform && part6.transform.parent == objek_dibuat.transform && part7.transform.parent == objek_dibuat.transform && part8.transform.parent == objek_dibuat.transform && part9.transform.parent == objek_dibuat.transform && part10.transform.parent == objek_dibuat.transform && part11.transform.parent == objek_dibuat.transform && part12.transform.parent == objek_dibuat.transform && part13.transform.parent == objek_dibuat.transform && part14.transform.parent == objek_dibuat.transform)
        {
            //Debug.Log("Score 1");
            status.text = "1";
        }
        else
        {
            status.text = "0";
        }
    }
}
