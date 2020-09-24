using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class waktuafk2 : MonoBehaviour
{
    private int time2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!Input.anyKey)
        {
            time2 = time2 + 1;
        }
        else
        {
            time2 = 0;
        }

        if (time2 == 18000)
        {
            Scene();
        }
        //aa = click.text.ToString();
        //Debug.Log(" parent = " + awalparent + "hai");

        Debug.Log("time ===" + time2);
    }

    public void Scene()
    {
        SceneManager.LoadScene("level3_resize");
    }
}
