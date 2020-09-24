using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet_coba : MonoBehaviour
{
    public GameObject bentuk1;
    public GameObject detectorasalkiri;
    public GameObject detectorasalkanan;
    public GameObject detectorasalatas;
    public GameObject detectorasalbawah;


    public GameObject detectormusuhkiri;
    public GameObject detectormusuhkanan;
    public GameObject detectormusuhatas;
    public GameObject detectormusuhbawah;

    Transform awal;
    Transform detecasalkiri;
    Transform detecasalkanan;
    Transform detecasalatas;
    Transform detecasalbawah;

    Transform detecmusuhkiri;
    Transform detecmusuhkanan;
    Transform detecmusuhatas;
    Transform detecmusuhbawah;

    Transform awal2;

    // Start is called before the first frame update
    void Start()
    {
        detecasalkiri = detectorasalkiri.transform;
        detecasalkanan = detectorasalkanan.transform;
        detecasalatas = detectorasalatas.transform;
        detecasalbawah = detectorasalbawah.transform;
        
        detecmusuhkiri = detectormusuhkiri.transform;
        detecmusuhkanan = detectormusuhkanan.transform;
        detecmusuhatas = detectormusuhatas.transform;
        detecmusuhbawah = detectormusuhbawah.transform;

        
        awal = bentuk1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bentuk1.transform.rotation.z);
        //Debug.Log(bentuk1.transform.localScale.x);
    }

    
    void OnTriggerStay2D(Collider2D col)
    {
                
        if(detecasalkiri = detecmusuhkanan)
        {
            Debug.Log("Kiri Kanan");
            bentuk1.transform.position = detecmusuhkanan.transform.position;
            bentuk1.transform.rotation = detecmusuhkanan.transform.rotation;
        }
        if(detecasalkanan = detecmusuhkiri)
        {
            Debug.Log("Kiri Kanan");
            bentuk1.transform.position = detecmusuhkiri.transform.position;
            bentuk1.transform.rotation = detecmusuhkiri.transform.rotation;
        }
        
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        //if (bentuk1.transform.rotation.z <= 0.2 & bentuk1.transform.localScale.x == 1)
        if (detecasalkiri = detecmusuhkanan)
        {
            Debug.Log("Kiri kanan end");
            
        }
    }

}
