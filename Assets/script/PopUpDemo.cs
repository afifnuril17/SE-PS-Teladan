using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDemo : MonoBehaviour
{
    public GameObject popup;
    public GameObject main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pop()
    {
        popup.SetActive(true);
    }
    public void Poptidak()
    {
        popup.SetActive(false);
    }
    public void Popiya()
    {
        popup.SetActive(false);
        main.SetActive(true);
    }


}
