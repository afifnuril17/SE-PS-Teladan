using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using System;

public class dragkecil : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

	private RectTransform rectTransform;
	private float clickLast = 0.0f, clickDelay = 0.4f;
	private int clickPointer = 0;
	private float clickRotation = 0.0f;
	private float clickPosition = 100f;


	//drop to objek area
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	//drop to objek area

	//bentuk
	public GameObject o_panel;
	public GameObject bentuk_image;
	public GameObject mid_image;
	//

	//play area
	Vector3 play_a;
	public GameObject play_area;
	string triger;
	//play area

	//tempat_awal
	Vector3 awal;
	//tempat_awal

	//rotasi
	string tempat;
	//rotasi


	//anim 
	private string anim;
	//anim

	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		awal = transform.position;

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

		anim = "stop";
		if (anim == "stop")
		{
			//Debug.Log("anim stop");
			bentuk_image.GetComponent<Animator>().enabled = false;
		}

		if (clickLast + clickDelay > Time.time)
		{
			transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);

			clickLast = 0.0f;
		}
		else
		{
			clickLast = Time.time;
		}
		if (clickPointer == 0)
		{
			clickRotation = rectTransform.eulerAngles.z;
			clickPosition = Input.mousePosition.x;
		}

		if (Input.GetMouseButton(0))
		{
			tempat = data.pointerPressRaycast.gameObject.name;

			if (tempat == bentuk_image.name)
			{
				//Debug.Log("tempat sama dengan image");
				clickPointer = 2;
			}
			else
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
		if (triger == "ya")
		{
			bentuk_image.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			bentuk_image.GetComponent<Rigidbody2D>().useAutoMass = true;

		}

		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		o_panel.SetActive(false);

		bentuk_image.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

		//Debug.Log(play);
		if (transform.position != startPosition)
		{
			if (triger == "ya")
			{
				//bentuk_image.transform.parent = GameObject.Find("play_area").transform;
				//bentuk_image.GetComponent<magnet>().enabled = true;
				//bentuk_image.GetComponent<magnet2ob>().enabled = true;
			}
			else
			{

				itemBeingDragged = null;
				transform.position = awal;
				bentuk_image.transform.parent = GameObject.Find("objek_area").transform;
				//bentuk_image.GetComponent<magnet>().enabled = false;
				//bentuk_image.GetComponent<magnet2ob>().enabled = false;

			}
		}
		else
		{
			//animasi berjalan
			//bentuk_image.GetComponent<Animator>().enabled = true;
		}

	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.CompareTag("dragcollider"))
		{
			//Debug.Log("seharusnya tidak kembali");
			triger = "ya";
			bentuk_image.transform.parent = GameObject.Find("play_area").transform;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.CompareTag("play_area"))
		{
			triger = "tidak";
			//Debug.Log("Balik ke awal");
			//EdgesScroll.enabled = true;
			bentuk_image.transform.parent = o_panel.transform;
			bentuk_image.transform.position = awal;
			bentuk_image.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

		}
	}

}