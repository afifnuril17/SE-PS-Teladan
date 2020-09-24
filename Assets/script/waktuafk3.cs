using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class waktuafk3 : MonoBehaviour
{
    private int time3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!Input.anyKey)
        {
            time3 = time3 + 1;
        }
        else
        {
            time3 = 0;
        }

        if (time3 == 18000)
        {
            Scene();
        }
        //aa = click.text.ToString();
        //Debug.Log(" parent = " + awalparent + "hai");

        Debug.Log("time ===" + time3);
    }

    public void Scene()
    { 
        Application.Quit();
    }
}
