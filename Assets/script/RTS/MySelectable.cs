using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Linq;

public class MySelectable : MonoBehaviour, IPointerClickHandler, ISelectHandler, IDeselectHandler
{
    public static HashSet<MySelectable> allMySelectable = new HashSet<MySelectable>();
    public static HashSet<MySelectable> currentlySelected = new HashSet<MySelectable>();

    public GameObject[] drag;

    [SerializeField]
    Material unSelectedMaterial;

    [SerializeField]
    Material selectedMaterial;

    void Awake()
    {
        allMySelectable.Add(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            DeselectAll(eventData);
        }

        currentlySelected.Add(this);
        Debug.Log(currentlySelected.Count);

            transform.position = Input.mousePosition;

    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("tidak di tekan");
    }

    

    public static void DeselectAll(BaseEventData eventData)
    {
        foreach(MySelectable selectable in currentlySelected)
        {
            selectable.OnDeselect(eventData);
        }
        currentlySelected.Clear();
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}
