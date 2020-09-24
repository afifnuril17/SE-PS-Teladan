using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfkIdentitas : MonoBehaviour
{
    public int myTime;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {
            time += Time.deltaTime;

            if (time > 1f)
            {
                myTime++;
                time = 0;
            }

            if (myTime == 600)
            {
                Application.Quit();
            }
        }
        else
        {
            myTime = 0;
        }
    }
}
