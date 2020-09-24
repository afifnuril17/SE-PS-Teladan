using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShootlvl6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeSS()
    {
        StartCoroutine(SS());
    }

    IEnumerator SS()
    {
        /*
        yield return new WaitForEndOfFrame();

        int width = 987;
        int height = 1177;
        int startX = -16;
        int startY = -56;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        Rect rex = new Rect(startX, startY, width, height);

        tex.ReadPixels(rex, 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

        File.WriteAllBytes(Application.dataPath + "/../lvl6yang dibuat.png", bytes);
        Debug.Log("SS");

        */

        // We should only read the screen buffer after rendering is complete
        yield return new WaitForSeconds(5);

        // Create a texture the size of the screen, RGB24 format
        int width = 987;
        int height = 1946;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToJPG();
       

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/../lvl6yang dibuat.jpeg", bytes);
        Debug.Log("SS");


    }
}
