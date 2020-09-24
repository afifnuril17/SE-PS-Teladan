using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragjalan : MonoBehaviour
{ 
    public Transform player;
    public float distanceFromCamera;
    public Camera cam;
    Rigidbody2D r;

   



    // Start is called before the first frame update
    void Start()
    {
        distanceFromCamera = Vector3.Distance(player.position, cam.transform.position);

        r = player.GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition - player.transform.position;
        pos.z = distanceFromCamera;

        pos = cam.ScreenToWorldPoint(pos);
        //player.position = pos;

        r.velocity = (pos - player.transform.position) * 5;
        //player.transform.position = Input.mousePosition;

    }
}
