using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takescreenshoot : MonoBehaviour
{
    public GameObject bentuk_image;
    public Text size;
   public  Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void takeSS()
    {
        StartCoroutine(CaptureIt());
    }

    // Update is called once per frame
    IEnumerator CaptureIt()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "Screenshot" + timeStamp + ".png";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Debug.Log("Screenshoot");

    }
}
