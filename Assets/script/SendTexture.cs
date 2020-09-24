using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendTexture : MonoBehaviour
{
    public static SendTexture Control;
    public Texture texture;
    public Texture2D texture2;
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Control == null)
        {
            Control = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Image>().material.mainTexture = texture2;
    }

    public void SSTexture()
    {
        StartCoroutine(RecordFrame());
        

    }
    IEnumerator RecordFrame()
    {
        yield return new WaitForEndOfFrame();

        texture = ScreenCapture.CaptureScreenshotAsTexture();

        texture2 = new Texture2D(960, 1129, TextureFormat.RGB24, true); 
        texture2.ReadPixels(new Rect(55, 745, 960, 1129), 0, 0); 

        texture2.Apply(); 
    }

}

