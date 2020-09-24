using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class scrollrectpos : MonoBehaviour
{
    public GameObject scroll;

    public GameObject panelscrol;
    private bool atas = false;

    public GameObject btn_up;
    public GameObject btn_up1;
    public GameObject btn_down;

    public Vector3 [] startpos;


    public bool bawah;
    float scroll_pos;

    public GameObject [] bentuk_image;
    Vector3 panel_scroll_pos;
    float panel_pos_y;
    float panel_pos_x;

    public int j;
    public int ups = 0;
    private bool up;

    private int t;
    // Start is called before the first frame update
    void Start()
    {
        up = true;
        bawah = true;
        scroll_pos = scroll.transform.position.x;
        panel_scroll_pos = panelscrol.transform.position;

       for(int i = 0;i<=bentuk_image.Length-1;i++)
        {
            if(bentuk_image[i].transform.parent == GameObject.Find("objek_area_scroll").transform )
            {
                bentuk_image[i].GetComponent<Rigidbody2D>().simulated = false;
            }
            else
            {
                bentuk_image[i].GetComponent<Rigidbody2D>().simulated = true;
            }
        }

        //panel_pos_y = panelscrol.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        ups = ups + 1;
        //Debug.Log("UPS" + ups);

       t = t + 1;
        //Debug.Log("int T" + t);
        if (up == true)
        {
            if(t <= 400)
            {
                if (Time.fixedTime % .5 < .2)
                {
                    btn_up.SetActive(false);
                }
                else
                {
                    btn_up.SetActive(true);

                }
            }
            else
            {
                btn_up.SetActive(true);
            }
            

            /*
            if(ups % 2 == 1)
            {
                btn_up.SetActive(false);
            }
            else
            {
                btn_up.SetActive(true);
            }
            */

        }
        else
        {

        }

        if (bawah == true)
        {
            panelscrol.GetComponent<ScrollRect>().enabled = false;
            for (int i = 0; i <= bentuk_image.Length - 1; i++)
            {
                if (bentuk_image[i].transform.parent == scroll.transform)
                {
                    //bentuk_image[i].transform.position = startpos[j];

                    //Debug.Log("kebawah" + i);
                    //bentuk_image[i].GetComponent<ItemIDragHandler1_rotate>().enabled = false;
                    bentuk_image[i].GetComponent<ItemIDragHandler1_rotate>().btn_rotate.SetActive(false);
                    bentuk_image[i].GetComponent<ItemIDragHandler1_rotate>().btn_flip.SetActive(false);

                    //bentuk_image[i].transform.position = startpos[j];
                }
            }
        }
        else
        {
            panelscrol.GetComponent<ScrollRect>().enabled = true;

            for (int i = 0; i <= bentuk_image.Length -1; i++)
            {
                if (bentuk_image[i].transform.parent == scroll.transform)
                {

                    bentuk_image[i].GetComponent<ItemIDragHandler1_rotate>().enabled = true;
                }
            }
        }
       

    }

    public void balik()
    {
        scroll.transform.position = new Vector3(scroll_pos, transform.position.y, transform.position.z);
    }

    public void keatas()
    {
        panelscrol.transform.position = new Vector3(transform.position.x, transform.position.y * 4.3f, transform.position.z);

        btn_up.SetActive(false);
        btn_down.SetActive(true);
        bawah = false;

        up = false;
        btn_up1.SetActive(false);

    }
    public void kebawah()
    {


        //panelscrol.transform.position = panel_scroll_pos;
        panelscrol.transform.position = new Vector3(transform.position.x, transform.position.y / 4.3f, transform.position.z);

        btn_up.SetActive(true);
        btn_down.SetActive(false);
        balik();
        bawah = true;

        for (int i = 0; i <= bentuk_image.Length - 1; i++)
        {
            bentuk_image[i].GetComponent<ItemIDragHandler1_rotate>().btn_rotate.SetActive(false);
            bentuk_image[i].GetComponent<ItemIDragHandler1_rotate>().btn_flip.SetActive(false);
        }
    }
}
