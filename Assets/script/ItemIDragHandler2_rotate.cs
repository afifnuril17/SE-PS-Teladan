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

public class ItemIDragHandler2_rotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	private RectTransform rectTransform;
	private float clickLast = 0.0f, clickDelay = 0.4f;
	private int clickPointer = 0;
	private float clickRotation = 0.0f;
	private float clickPosition = 100f;


	public GameObject btn_rotate;
	public GameObject btn_flip;

	//area pop o

	public GameObject o_panel;
	public GameObject o_awal_panel;

	public GameObject o_panel_sembunyi;
	//area pop o

	//drop to objek area
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	//drop to objek area

	//bentuk
	public GameObject bentuk_image;
	public GameObject mid_image;
	//

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


	public float deltaRotation;
	public float deltaLimit;
	public float deltaReduce;
	float previousRotation;
	float currentRotation;

	public string aa;
	//rotasi

	//canvasanother
	private GameObject clone;

	public Transform parentawal;
	public string awalparent;
	public GameObject panel1;
	public GameObject panel2;

	//canvasanother

	//time afk

	
	//time afk

	//anim 
	private string anim;
	//anim

	private int bentuk_masuk;

	public int waktu;
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
		//waktu = 0;
		waktu = waktu+1;
		//Debug.Log("waktu +++" + waktu);
		if(!Input.anyKey)
        {
			if (waktu == 50)
			{
				//Debug.Log("waktu +++ berhenti");
				btn_rotate.SetActive(false);
				btn_flip.SetActive(false);
			}
		}
	}

	public void ButtonDrag()
	{
		ButtonAction = 0;
		Debug.Log("DRAG");
	}

	public void ButtonFlip()
	{
		//ButtonAction = 1;
		transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
	}

	public void ButtonRotate()
	{
		//clickPointer = 2;
		//Debug.Log("buttttotntonibdbfuhsjbddsnfsnfgsdbf");
	}

	public void OnPointerDown(PointerEventData data)
	{
		if (o_panel.GetComponent<scrollrectpos1>().bawah == false || bentuk_image.transform.parent == GameObject.Find("objek_dibuat").transform)
		{

			if (TryGetComponent<Image>(out Image image))
			{
				image.alphaHitTestMinimumThreshold = 0.001f;
				
				waktu = 0;
				Debug.Log("ada gambarnya bro");
				btn_rotate.SetActive(true);
				btn_flip.SetActive(true);
				bentuk_image.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			}
			else
			{
				//Error
			}


			//anim = "stop";
			if (anim == "stop")
			{
				//Debug.Log("anim stop");
				bentuk_image.GetComponent<Animator>().enabled = false;
			}

			if (clickPointer == 0)
			{
				clickRotation = rectTransform.eulerAngles.z;
				clickPosition = Input.mousePosition.x;
			}

			if (Input.GetMouseButton(0))
			{
				tempat = data.pointerPressRaycast.gameObject.name;


				if (tempat == btn_rotate.name)
				{
					Debug.Log("GAMBAR WA");
					clickPointer = 2;
				}

				if (tempat == bentuk_image.name)
				{
					Debug.Log("tempat sama dengan image");
					//rotasi();
					//bb = Input.mousePosition.y;
					//clickPointer = 2;
					clickPointer = 1;
				}
				else
				{
					//Debug.Log("tempat tidak sama dengan image");
					//clickPointer = 1;
					//click.text = "1";
				}

				//Debug.Log("Clicked: " + data.pointerCurrentRaycast.gameObject.name);
			}
		}
	}
	public void OnPointerUp(PointerEventData data)
	{
		clickPointer = 0;
	}
	public void OnDrag(PointerEventData data)
	{
		bentuk_image.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

		if (clickPointer == 1)
		{
			if (bentuk_image.transform.parent == o_awal_panel.transform)
			{
				transform.position = Input.mousePosition;

			}
			else
			{
				Rigidbody2D rb = bentuk_image.GetComponent<Rigidbody2D>();

				Vector3 mouse = Input.mousePosition - transform.position;

				rb.AddForce(mouse * speed);

			}
		}
		else if (clickPointer == 2)
		{
			Debug.Log("ButtonAction" + ButtonAction);
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

			Vector3 direction = Input.mousePosition  - transform.position;

			Debug.DrawRay(transform.position, direction, Color.green);

			float angle = (Mathf.Atan2(direction.y, direction.x) * 1) * Mathf.Rad2Deg;

			float angel2 = Mathf.Round((float)(angle / 30)) * 30;

			transform.eulerAngles = Vector3.forward * angel2;

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
		bentuk_image.GetComponent<Rigidbody2D>().simulated = true;

		itemBeingDragged = gameObject;
		startPosition = transform.position;

		if (bentuk_image.transform.parent == GameObject.Find("objek_dibuat").transform)
		{
			bentuk_image.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			bentuk_image.GetComponent<Rigidbody2D>().mass = 1;
			bentuk_image.GetComponent<Rigidbody2D>().gravityScale = 0;
			bentuk_image.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


		}

	}

    public void OnEndDrag(PointerEventData eventData)
    {
		bentuk_image.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


		waktu = 0;
		o_panel.GetComponent<scrollrectpos1>().balik();
		//o_panel.SetActive(false);

		if(clickPointer ==2)
        {
			clickPointer = 0;
        }
		if(o_panel.GetComponent<scrollrectpos1>().bawah == true)
        {
			if (bentuk_image.transform.position != startPosition)
				if (triger == "ya")
				{

				}
				else
				{
					bentuk_image.transform.position = awal;

				}
		}
        else
        {
			//o_panel.GetComponent<scrollrectpos>().balik();

			o_panel.GetComponent<scrollrectpos1>().kebawah();
		}

		
		//Debug.Log(play);
		if (bentuk_image.transform.position != startPosition)
		{
			//Debug.Log(bentuk_image.transform.parent);
			if(triger == "ya")
            {
				
				//bentuk_image.transform.parent = GameObject.Find("play_area").transform;
				//bentuk_image.GetComponent<magnet>().enabled = true;
				//bentuk_image.GetComponent<magnet2ob>().enabled = true;
				//bentuk_image.GetComponent<Rigidbody2D>().AddForce((bentuk_image.transform.position - bentuk_image.transform.position) * 10f* Time.smoothDeltaTime);

			}
            else
            {

				itemBeingDragged = null;
				bentuk_image.transform.position = awal;
				bentuk_image.transform.parent = o_awal_panel.transform;
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

	public void pidah()
    {

    }
	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.CompareTag("dragcollider"))
        {
			//Debug.Log("seharusnya tidak kembali");
			triger = "ya";
			bentuk_image.transform.parent = GameObject.Find("objek_dibuat").transform;
		}
		if (col.gameObject.CompareTag("play_area"))
		{
			triger = "ya";
		}
		if (col.gameObject.CompareTag("guide_cocokan"))
		{
			GameObject.Find("guide_cocokan").GetComponent<guide_cocokan>().bentuk_masuk += 1;
			//Debug.Log("bentuk_masuk" + bentuk_masuk);
		}

	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (bentuk_image.transform.parent == GameObject.Find("objek_dibuat").transform)
		{
			if (coll.gameObject.CompareTag("play_area"))
			{
				triger = "tidak";

				//Debug.Log("Balik ke awal");
				//EdgesScroll.enabled = true;
				bentuk_image.transform.parent = o_awal_panel.transform;
				bentuk_image.transform.position = awal;
				bentuk_image.GetComponent<Rigidbody2D>().simulated = false;

			}
		}

	}
}