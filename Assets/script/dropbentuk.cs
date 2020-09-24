using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dropbentuk : MonoBehaviour, IDropHandler
{

    
    public void OnDrop(PointerEventData data) {
        //Debug.Log("OnDrop");
        if (data.pointerDrag != null) {

            data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
      
        }
    }
}
