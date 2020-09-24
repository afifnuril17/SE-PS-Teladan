using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_resize : MonoBehaviour
{
    public Text resize;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ymin()
    {
        resize.text = "ymin";
    } 
    public void ymax()
    {
        resize.text = "ymax";        
    } 
    public void xmin()
    {
        resize.text = "xmin";
    } 
    public void xmax()
    {
        resize.text = "xmax";
    }
    public void normal()
    {
        resize.text = "normal";
    }
}
