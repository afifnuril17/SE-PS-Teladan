using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendTexture : MonoBehaviour
{
    public GameObject playArea;
    public static SendTexture Control;
    public Texture texture;
    public Texture2D texture2;
    public int width;
    public int height;
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
        width = (int)playArea.GetComponent<RectTransform>().rect.width;
        height= (int)playArea.GetComponent<RectTransform>().rect.height;

        Debug.Log((width - 960) + "," + (height - 1129));
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

        texture2 = new Texture2D(width, height, TextureFormat.RGB24, true); 
        texture2.ReadPixels(new Rect(55, 745, width, height), 0, 0);  
        //texture2.ReadPixels(new Rect(5, 10, width, height), 0, 0);  

        texture2.Apply(); 
    }

}

