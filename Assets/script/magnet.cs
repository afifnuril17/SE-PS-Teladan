using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    public GameObject bentuk1;
    public GameObject detectorkiri;
    public GameObject detectorkanan;
    public GameObject detectorbawah;

    Transform awal;
    Transform deteckiri;
    Transform deteckanan;
    Transform detecbawah;
    Transform awal2;

    // Start is called before the first frame update
    void Start()
    {
        deteckiri = detectorkiri.transform;
        deteckanan = detectorkanan.transform;
        detecbawah = detectorbawah.transform;

        awal = bentuk1.transform;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(transform(deteckanan, deteckiri));
        //Debug.Log(bentuk1.transform.rotation.z);
        //Debug.Log(bentuk1.transform.localScale.x);
    }
    void sentuh()
    {
        //bentuk1.GetComponent<ItemIDragHandler>().OnEndDrag;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(bentuk1.transform.rotation.z);
        if (bentuk1.transform.rotation.z <= 0.010000f && bentuk1.transform.rotation.z >= -0.010000f && bentuk1.transform.localScale.x == 1f)
        {
            if (col.gameObject == detectorkiri)
            {
                if (bentuk1.transform.rotation.z <= 0.010000f && bentuk1.transform.rotation.z >= -0.010000f && bentuk1.transform.localScale.x == 1f)
                {
                    bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
                    bentuk1.transform.position = deteckiri.transform.position;
                    //bentuk1.transform.rotation = deteckiri.transform.rotation;
                    
                    Debug.Log("pas kiri");
                }
            }
            if(col.gameObject == detectorkanan)
            {
                if (bentuk1.transform.rotation.z <= 0.010000f && bentuk1.transform.rotation.z >= -0.010000f && bentuk1.transform.localScale.x == 1f)
                {
                    bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
                    bentuk1.transform.position = deteckanan.transform.position;
                    //bentuk1.transform.rotation = deteckanan.transform.rotation;
                }
            }
            if(col.gameObject == detectorbawah)
            {
                bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
                bentuk1.transform.position = detecbawah.transform.position;
                //bentuk1.transform.rotation = detecbawah.transform.rotation;
            }
        }
        /*
        if (col.gameObject.CompareTag("play_area"))
        {
                bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
        }
       */
           
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        //if (bentuk1.transform.rotation.z <= 0.2 & bentuk1.transform.localScale.x == 1)

            if (coll.gameObject.CompareTag("play_area"))
            {
                bentuk1.GetComponent<ItemIDragHandler>().triger = "keluar";
            }

            if (coll.gameObject == detectorkiri)
            {
                Debug.Log("keluar");
                bentuk1.transform.position = awal.transform.position;
            }
            if (coll.gameObject == detectorkanan)
            {
                Debug.Log("keluar");
                bentuk1.transform.position = awal.transform.position;
            }
            if (coll.gameObject == detectorbawah)
            {
                Debug.Log("keluar");
                bentuk1.transform.position = awal.transform.position;
            }
           
    }

}
