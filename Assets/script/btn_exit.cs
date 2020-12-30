using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class btn_exit : MonoBehaviour
{
    public Text tokenLogin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exit()
    {
        //StartCoroutine(UploadExit());
        Application.Quit();

        Debug.Log("Exit");
    }

    IEnumerator UploadExit()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", tokenLogin.text.ToString());

        UnityWebRequest uwr = UnityWebRequest.Post(Config.Control.urlBtnExit, form);

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
