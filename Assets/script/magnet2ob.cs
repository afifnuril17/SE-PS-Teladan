using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet2ob : MonoBehaviour
{
    public GameObject bentuk1;
    public GameObject detectorkiri;
    public GameObject detectorkanan;

    Transform awal;
    Transform deteckiri;
    Transform deteckanan;
    Transform awal2;

    // Start is called before the first frame update
    void Start()
    {
        deteckiri = detectorkiri.transform;
        deteckanan = detectorkiri.transform;

        awal = bentuk1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bentuk1.transform.rotation.z);
        //Debug.Log(bentuk1.transform.localScale.x);
    }
    void sentuh()
    {
        //bentuk1.GetComponent<ItemIDragHandler>().OnEndDrag;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        
            if(col.gameObject.CompareTag("play_area"))
            {
                bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
            }

            if (col.gameObject == detectorkiri)
            {
                //bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
                bentuk1.transform.position = deteckiri.transform.position;
                bentuk1.transform.rotation = deteckiri.transform.rotation;
                
                Debug.Log("pas kiri");
            }
            else if (col.gameObject == detectorkanan)
            {
                //bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
                bentuk1.transform.position = deteckanan.transform.position;
                bentuk1.transform.rotation = deteckanan.transform.rotation;
                
                Debug.Log("pas kiri");
            }
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
           
    }

}
