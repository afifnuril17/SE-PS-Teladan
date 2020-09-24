using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet_samping : MonoBehaviour
{
    public GameObject bentuk1;
    public GameObject detectorasal;
    public GameObject detectormusuh;

    Transform awal;
    Transform deteckiri;
    Transform detecmusuh;
    
    Transform awal2;

    // Start is called before the first frame update
    void Start()
    {
        deteckiri = detectorasal.transform;
        detecmusuh = detectormusuh.transform;
       

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
    void OnTriggerEnter2D(Collider2D col)
    {
        
            if(col.gameObject.CompareTag("play_area"))
            {
                bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
            }
            
            if (col.gameObject == detectormusuh)
            {
                bentuk1.GetComponent<ItemIDragHandler>().triger = "ya";
                bentuk1.transform.position = detecmusuh.transform.position;
                Debug.Log("pas kanan");
            }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        //if (bentuk1.transform.rotation.z <= 0.2 & bentuk1.transform.localScale.x == 1)
            if (coll.gameObject == detectormusuh)
            {
                Debug.Log("keluar");
                bentuk1.transform.position = awal.transform.position;
            }
    }

}
