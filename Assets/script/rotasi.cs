using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotasi : MonoBehaviour
{
    public float deltaRotation;
    public float deltaLimit;
    public float deltaReduce;
    float previousRotation;
    float currentRotation;

    public GameObject bentuk_image;

    public Text click;
    public string a;


    void Start()
    {
        a = click.text.ToString();
        a = "2";
    }

    void Update()
    {
        Vector3 direction = Input.mousePosition - transform.position;

        Debug.DrawRay(transform.position, direction, Color.green);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = Vector3.forward * angle;
    }
}
