using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using System;

public class dragguide : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

	private RectTransform rectTransform;
	private float clickLast = 0.0f, clickDelay = 0.4f;
	private int clickPointer = 0;
	private float clickRotation = 0.0f;
	private float clickPosition = 100f;

	public GameObject mid_image;

	public GameObject objek_area;
	public GameObject panel_tampil;
	private string tempat;

	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		objek_area.SetActive(false);
		panel_tampil.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnPointerDown(PointerEventData data)
	{
		if (TryGetComponent<Image>(out Image image))
		{
			image.alphaHitTestMinimumThreshold = 0.001f;

			//Debug.Log("ada gambarnya bro");
		}
		else
		{
			//Debug.Log("tidak ada gambarnya bro");

			//Error
		}

		if (clickPointer == 0)
		{
			clickRotation = rectTransform.eulerAngles.z;
			clickPosition = Input.mousePosition.x;
		}

		if (Input.GetMouseButton(0))
		{
			tempat = data.pointerPressRaycast.gameObject.name;

			if (tempat == mid_image.name)
			{ 
				//Debug.Log("tempat tidak sama dengan image");
				clickPointer = 1;
				//click.text = "1";
			}

			//Debug.Log("Clicked: " + data.pointerCurrentRaycast.gameObject.name);
		}
	}
	public void OnPointerUp(PointerEventData data)
	{

		clickPointer = 0;
	}
	public void OnDrag(PointerEventData data)
	{

		if (clickPointer == 1)
		{
			transform.position = Input.mousePosition;
			clickPointer = 1;
		}
	}
	
	public void OnBeginDrag(PointerEventData eventData)
	{
	
	}

	public void OnEndDrag(PointerEventData eventData)
	{


	}

}