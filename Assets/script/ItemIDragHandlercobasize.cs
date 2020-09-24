using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using System;
using Unity.Mathematics;
using UnityEngine.Experimental.Playables;
using UnityEngine.SceneManagement;

public class ItemIDragHandlercobasize : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
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
	public GameObject bentuk_image;
	public GameObject mid_image;
	//

	//rotasi
	public Vector3 temp;
	//rotasi

	//play area
	Vector3 play_a;
	public GameObject play_area;
	public string triger;
	//play area

	//tempat_awal
	Vector3 awal;
	//tempat_awal

	//rotasi
	public Text click;
	string tempat;
	public float bb;
	public string minplus;
	public float RotationSpeed = 5;
	public float speed;


	public string aa;
	//rotasi

	//canvasanother
	private GameObject clone;

	public Transform parentawal;
	public string awalparent;
	public GameObject panel1;
	public GameObject panel2;

	//canvasanother

	//resize
	public Text resize;
	//resize

	//anim 
	private string anim;
	//anim

	int ButtonAction = 0;
	// Use this for initialization
	void Start()

	{

		rectTransform = GetComponent<RectTransform>();
		awal = transform.position;
		awalparent = bentuk_image.transform.parent.ToString();

		
		//bentuk_image.GetComponent<rotasi>().enabled = false;
	}

	// Update is called once per frame
	void Update()
    {
		
    }

	public void ButtonDrag()
	{
		ButtonAction = 1;
	}

	public void ButtonFlip()
	{
		ButtonAction = 2;
	}

	public void ButtonRotate()
	{
		ButtonAction = 3;
	}
	public void OnPointerDown(PointerEventData data)
	{
		if(resize.text == "normal")
		{ 
		if (TryGetComponent<Image>(out Image image))
		{
			image.alphaHitTestMinimumThreshold = 0.001f;

			//Debug.Log("ada gambarnya bro");
		}
		else
		{
			//Error
		}

		//anim = "stop";
		if(anim == "stop")
        {
			//Debug.Log("anim stop");
			bentuk_image.GetComponent<Animator>().enabled = false;
		}

		if (clickLast + clickDelay > Time.time)
		{

				transform.Rotate(0f, 0f, 180f);
			
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
					//rotasi();
					bb = Input.mousePosition.y;
					clickPointer = 2;

				}
				else
				{
					//Debug.Log("tempat tidak sama dengan image");
					clickPointer = 1;
					//click.text = "1";
				}
			}
			//Debug.Log("Clicked: " + data.pointerCurrentRaycast.gameObject.name);
		}
        else
        {
			temp = bentuk_image.transform.localScale;

			if(resize.text == "ymin")
            {
				temp.y -= Time.deltaTime;
            }
			if(resize.text == "ymax")
            {
				temp.y += Time.deltaTime;
            }
			if(resize.text == "xmin")
            {
				temp.x -= Time.deltaTime;
            }
			if(resize.text == "xmax")
            {
				temp.x += Time.deltaTime;
            }
			bentuk_image.transform.localScale = temp;
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
		else if (clickPointer == 2)
		{
			//Debug.Log(Input.GetAxis("Mouse X"));

			//if (Input.GetAxis("Mouse X") != 0)
			//{
			//transform.Rotate(0, 0, -speed);
			//}
			//else
			//{
			//transform.Rotate(0, 0, speed);
			//}

			//aa = "2";
			//click.text = aa;
			//if (aa == "2")
			//{
			//click.text = "2";
			//bentuk_image.GetComponent<rotasi>().enabled = true;
			//bentuk_image.GetComponent<ItemIDragHandler>().enabled = false;
			//}
			//else
			//{
			//click.text = "1";
			//}

			//transform.localRotation = Quaternion.Euler(0.0f, 0.0f, clickRotation * 0.5f + (clickPosition - Input.mousePosition.x));

			//Vector3 destination = new Vector3(0, 0, 90);
			//transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles,destination,Time.deltaTime);

			//click.text = "2";

			Vector3 direction = Input.mousePosition - transform.position;

			Debug.DrawRay(transform.position, direction, Color.green);

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

			transform.eulerAngles = Vector3.forward * 1f * angle;

			//float angle = Mathf.Atan2(dir.y, dir.x) * Time.deltaTime;
			//Quaternion rotation = Quaternion.AngleAxis(angle - 20f, Vector3.forward * Time.deltaTime);
			//transform.rotation = rotation;

			//Debug.Log(transform.position.x);
			//Debug.Log(Input.mousePosition.x);
			//float x = Input.GetAxis("Mouse X");
			//float y = Input.GetAxis("Mouse Y");

			//Debug.Log(y);
			//if(x == -x)
			//{
			//Debug.Log("X = MIN");

			//transform.Rotate(Vector3.forward * Time.deltaTime, 2f);
			//transform.localRotation = Quaternion.Euler(0.0f, 0.0f, clickRotation + (clickPosition - Input.mousePosition.x));
			//}
			//else
			//{
			//transform.Rotate(Vector3.back * Time.deltaTime, 2f);
			//aa = 2;

			//Debug.Log("y ="+ Input.mousePosition.y);

			//float x = bb;

			//if(x++ != bb)
			//{
			//minplus = "tambah";
			//}
			//if(x-- != bb)
			//{
			//minplus = "kurang";
			//}
			//Debug.Log(minplus);


			///jadiididiid

			//if (bb < Input.mousePosition.y)
			//{
			//transform.Rotate(Vector3.forward * Time.deltaTime, 0.5f);
			//}
			//else
			//{
			//transform.Rotate(Vector3.back * Time.deltaTime, 0.5f);
			//}
			///jadiididiid


			//float xx = clickRotation * 2f + (clickPosition + Input.mousePosition.y);
			//transform.localRotation = Quaternion.Euler(0.0f, 0.0f,xx);

			//Debug.Log("X = Plus");
			//}



			//transform.Rotate(0, 0, (Input.GetAxis("Mouse X"))* Time.deltaTime * 100f); this

			//transform.localRotation = Quaternion.Euler(0.0f, 0.0f, clickRotation + (clickPosition - Input.mousePosition.x));


			//transform.Rotate(new Vector3(0.0f, 0.0f,100f) * Time.deltaTime);

			//transform.localRotation = Quaternion.Euler(0.0f,0.0f, clickRotation + (clickPosition - Input.mousePosition.x) * Time.deltaTime * 10f);
		}
	}

	float angleBetweenPoints(Vector2 position1, Vector2 position2)
	{
		Vector2 fromLine = position2 - position1;
		Vector2 toLine = new Vector2(1, 0);

		float angle = Vector2.Angle(fromLine, toLine);

		Vector3 cross = Vector3.Cross(fromLine, toLine);

		// did we wrap around?
		if (cross.z > 0)
		{
			angle = 360f - angle;
		}

		return angle;
	}

	public void OnBeginDrag(PointerEventData eventData)
    {
		
		itemBeingDragged = gameObject;
		startPosition = transform.position;


	}

    public void OnEndDrag(PointerEventData eventData)
    {

		//Debug.Log(play);
		if (transform.position != startPosition)
		{
			//Debug.Log(bentuk_image.transform.parent);
			if(triger == "ya")
            {
				//bentuk_image.transform.parent = GameObject.Find("play_area").transform;
				bentuk_image.GetComponent<magnet>().enabled = true;
				bentuk_image.GetComponent<magnet2ob>().enabled = true;
			}
            else
            {
			
				itemBeingDragged = null;
				transform.position = awal;
				//bentuk_image.SetActive(false);
				Destroy(bentuk_image);
				bentuk_image.transform.parent = GameObject.Find("objek_area").transform;
				bentuk_image.GetComponent<magnet>().enabled = false;
				bentuk_image.GetComponent<magnet2ob>().enabled = false;

			}
		}
		else
        {
			//animasi berjalan
			//bentuk_image.GetComponent<Animator>().enabled = true;
        }

	}

	public void pidah()
    {

    }
	void OnTriggerStay2D(Collider2D col)
    {
		if(col.gameObject.CompareTag("play_area"))
        {
			//Debug.Log("seharusnya tidak kembali");
			triger = "ya";
			bentuk_image.transform.parent = GameObject.Find("play_area").transform;
		}
		
    }

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.CompareTag("play_area"))
        {
			triger = "tidak";
			//Debug.Log("Balik ke awal");
			//EdgesScroll.enabled = true;
			//Destroy(bentuk_image);
			//bentuk_image.transform.parent = o_panel.transform;
			//bentuk_image.transform.position = awal;
		}

	}
}