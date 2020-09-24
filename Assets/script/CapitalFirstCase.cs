using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Text.RegularExpressions;

public class CapitalFirstCase : MonoBehaviour
{
    public InputField Inputan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateField()
    {
        string kata = Inputan.text;
        kata = Regex.Replace(kata, @"[0-9]", "");
        Inputan.text = kata;
    }
    // Update is called once per frame
    void Update()
    {

        string str = Inputan.text;           

        if (str.Length == 0)
        {
            Debug.Log("Empty String");

        }
        else if (str.Length == 1)
        {
            Inputan.text = char.ToUpper(str[0]).ToString();
        }
        else
        {
            Inputan.text = char.ToUpper(str[0]) + str.Substring(1).ToString();

        }
        
    }

}
