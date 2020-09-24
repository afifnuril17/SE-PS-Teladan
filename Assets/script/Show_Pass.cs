using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Pass : MonoBehaviour
{
    public InputField password;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Showpass()
    {
        if (password.contentType == InputField.ContentType.Password)
        {
            password.contentType = InputField.ContentType.Standard;
            password.ForceLabelUpdate();
        }
        else if (password.contentType == InputField.ContentType.Standard)
        {
            password.contentType = InputField.ContentType.Password;
            password.ForceLabelUpdate();
        }
    }
}
