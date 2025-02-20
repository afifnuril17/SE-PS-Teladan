﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class moveTagTutorial : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public string tempat;
    public int ButtonAction = -1;
    public GameObject [] bentuk;
    public GameObject batas_drag;
    public GameObject drag_collider;
    public GameObject btn_drag_all;

    public GameObject control_bentuk;

    public GameObject tutorial;

    public GameObject selesai;
    public bool selesai1 = false;

    private const float DOUBLE_CLICK_TIME = .2f;
    private float lastClickTime;

    public bool Drag = false;

    public List<string> rbg;
    public List<string> warnaHitam;
    private int aing = 0;
    public bool clear = false;
    public bool Kliksatu = false;

    public GameObject glowing;
    public void OnPointerDown(PointerEventData eventData)
    {
        tempat = eventData.pointerPressRaycast.gameObject.name.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (GameObject.Find(tempat).transform.parent != GameObject.Find("objek_area_scroll").transform)
            {
                if (timeSinceLastClick <= DOUBLE_CLICK_TIME)
                {
                    if (warnaHitam.Count != 0)
                    {
                        GameObject.Find("btn_up").GetComponent<Button>().enabled = true;
                        batas_drag.SetActive(false);
                        drag_collider.SetActive(true);
                        Drag = false;

                        if (clear == false)
                        {
                            Component[] joints = GameObject.Find(warnaHitam[0].ToString()).GetComponents<FixedJoint2D>() as Component[];
                            foreach (FixedJoint2D joint in joints)
                                Destroy(joint as FixedJoint2D);
                            warnaHitam.Clear();
                            rbg.Clear();
                            clear = true;
                        }
                        for (int i = 0; i <= bentuk.Length - 1; i++)
                        {
                            if (bentuk[i].transform.parent == GameObject.Find("hahaha").transform || bentuk[i].transform.parent == GameObject.Find("objek_dibuat").transform)
                            {

                                bentuk[i].transform.SetParent(GameObject.Find("objek_dibuat").transform);
                                bentuk[i].tag = "Untagged";
                                bentuk[i].GetComponent<Image>().color = Color.white;
                                bentuk[i].GetComponent<ItemIDragHandler_Tutorial>().enabled = true;
                                ButtonAction = 0;
                            }
                        }
                        if (tutorial.GetComponent<Tutorial>().finish == true)
                        {
                            if (selesai1 == false)
                            {
                                selesai.SetActive(true);
                                control_bentuk.GetComponent<Bentuk_tutorial>().FinishTutorial();
                            }
                        }
                    }
                    Debug.Log("KLIK 2 KALI" + tempat);
                }
                else
                {
                    for (int i = 0; i <= bentuk.Length - 1; i++)
                    {
                        if (Drag == true)
                        {
                            if (tempat == bentuk[i].name)
                            {
                                aing++;
                                Kliksatu = true;
                                warnaHitam.Add(tempat);
                                rbg.Add("rb" + aing);
                                Debug.Log("masuk");

                                GameObject.Find(tempat).tag = "bentuk_image";
                                GameObject.Find(tempat).transform.SetParent(GameObject.Find("hahaha").transform);

                                bentuk[i].GetComponent<Image>().color = Color.black;
                            }
                        }
                        if (Kliksatu == true && tempat == bentuk[i].name)
                        {
                            FixedJoint2D fix = GameObject.Find(warnaHitam[0].ToString()).AddComponent<FixedJoint2D>();

                            for (int z = 0; z < warnaHitam.Count; z++)
                            {

                                for (int g = 0; g < rbg.Count; g++)
                                {
                                    Rigidbody2D aa = GameObject.Find(warnaHitam[z].ToString()).GetComponent<Rigidbody2D>();

                                    fix.connectedBody = aa;
                                }


                            }
                        }
                    }
                    Debug.Log("KLIK 1 KALI" + tempat);
                }

                lastClickTime = Time.time;
            }
        }
    }

    public void ButtonLepas()
    {
        ButtonAction = 1;
        batas_drag.SetActive(true);
        drag_collider.SetActive(false);
        Drag = true;
        clear = false;
        Kliksatu = false;
        glowing.SetActive(false);

        if(tutorial.GetComponent<Tutorial>().tutor == false)
        {
            tutorial.GetComponent<Tutorial>().klikdrag();
        }

        for (int i = 0; i <= bentuk.Length - 1; i++)
        {
            bentuk[i].GetComponent<ItemIDragHandler_Tutorial>().enabled = false;
            bentuk[i].GetComponent<ItemIDragHandler_Tutorial>().btn_flip.gameObject.SetActive(false);
            bentuk[i].GetComponent<ItemIDragHandler_Tutorial>().btn_rotate.gameObject.SetActive(false);
        }
        GameObject.Find("btn_up").GetComponent<Button>().enabled = false;

    }
    public void DragSatua()
    {
       
        for(int i =0;i<=bentuk.Length -1;i++)
        {
            bentuk[i].GetComponent<ItemIDragHandler_Tutorial>().enabled = true;
            bentuk[i].GetComponent<Image>().color = Color.white;
            bentuk[i].transform.SetParent(GameObject.Find("objek_dibuat").transform);

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(ButtonAction == 1)
        {
            for(int i = 0; i<=bentuk.Length-1;i++)
            {
                if (bentuk[i].tag == "bentuk_image")
                {
                    Rigidbody2D rb = bentuk[i].GetComponent<Rigidbody2D>();

                    bentuk[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                    Vector3 mouse = Input.mousePosition - GameObject.Find(tempat).transform.position;

                    rb.AddForce(mouse * 5);
                    
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (tutorial.GetComponent<Tutorial>().unselect == false)
        {
            tutorial.GetComponent<Tutorial>().klik2kali();
        }

        for (int i = 0; i <= bentuk.Length - 1; i++)
        {
            bentuk[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.Find("objek_dibuat").transform.childCount > 1 || GameObject.Find("hahaha").transform.childCount > 0)
        {
            btn_drag_all.SetActive(true);
        }
        else
        {
            btn_drag_all.SetActive(false);
        }
    }
}
