using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Trim : MonoBehaviour
{
    public InputField Inputan;

    public void EndIt()
    {
        Inputan.text = Inputan.text.Trim();
    }
}
