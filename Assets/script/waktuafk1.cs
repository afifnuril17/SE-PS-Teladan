using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class waktuafk1 : MonoBehaviour
{
    private int time1;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (!Input.anyKey)
        {
            time1 = time1 + 1;
        }
        else
        {
            time1 = 0;
        }

        if (time1 == 18000)
        {
            Scene();
        }
        //aa = click.text.ToString();
        //Debug.Log(" parent = " + awalparent + "hai");

        //Debug.Log("time ===" + time1);
    }

    public void Scene()
    {
        SceneManager.LoadScene("level2_resize");
    }
}
