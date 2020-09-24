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

public class ItemIDragHandler1_resivee : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	private RectTransform rectTransform;
	private float clickLast = 0.0f, clickDelay = 0.4f;
	private int clickPointer = 0;
	private float clickRotation = 0.0f;
	private float clickPosition = 100f;


	public Vector3 tempp;
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
	//anim 
	private string anim;
	//anim

	public int waktu;
	int ButtonAction = 0;

	//resize
	Vector2 prevMousePosition;
	public float sizingFactor = 0.03f;

	//resize

	//distance
	public float distance;
	public float jarak_baru;
	//distance

	//localx
	public bool localXMin = false;

	private int a = 0;

	// Use this for initialization
	void Start()

	{

		rectTransform = GetComponent<RectTransform>();
		awal = transform.position;
		awalparent = bentuk_image.transform.parent.ToString();

		
		//bentuk_image.GetComponent<rotasi>().enabled = false;
	}

	// Update is called once per frame
	void FixedUpdate()
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
		//Debug.Log(clickPointer);
		
	}

	public void ButtonDrag()
	{
		ButtonAction = 0;
		Debug.Log("DRAG");
	}

	public void ButtonFlip()
	{
		localXMin = true;
		//bentuk_image.transform.localRotation = Quaternion.Euler(0, 180, 0);
		//Debug.Log("tra"+transform.position.y);
		//transform.Rotate(0f, transform.position.y * 180, transform.position.z);
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		a++;
		if(a%2 ==0)
        {
			localXMin = false;
        }

	}

	public void ButtonRotate()
	{
		//clickPointer = 2;
		Debug.Log("buttttotntonibdbfuhsjbddsnfsnfgsdbf");
	}

	public void OnPointerDown(PointerEventData data)
	{

		if (TryGetComponent<Image>(out Image image))
			{
			image.alphaHitTestMinimumThreshold = 0.001f;
			waktu = 0;
			Debug.Log("ada gambarnya bro");
			btn_rotate.SetActive(true);
			btn_flip.SetActive(true);

			
		}
		else
			{
			Debug.Log("tidak ada image");
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
				if (Input.touchCount == 2)
				{
					clickPointer = 3;
					
				}
				else
				{
					clickPointer = 1;
				}

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
	public void OnPointerUp(PointerEventData data)
	{
		clickPointer = 0;
	}
	public void OnDrag(PointerEventData data)
	{
		//float jarak = (Input.mousePosition - Camera.main.WorldToScreenPoint(bentuk_image.transform.position)).magnitude;

		//Debug.Log("JARAKnya adalah ahhaha" + jarak);

		if (clickPointer == 1)
		{
			transform.position = Input.mousePosition;
			clickPointer = 1;
		}
		
		else if (clickPointer == 2)
		{
			/*
			float detik = Time.deltaTime;
			bool ambil = true;

			if (ambil == true)
			{
				distance = jarak_baru;
				ambil = false;
			}
			if (detik == detik + 1)
			{
				ambil = true;
			}
			*/


			jarak_baru = Vector2.Distance(Input.mousePosition, bentuk_image.transform.position);


			Debug.Log("jarak awal" +distance+ "jarak baru" + jarak_baru);

			tempp = bentuk_image.transform.localScale;

			if (localXMin == true)
			{
				if (distance <= jarak_baru)
				{
					distance = jarak_baru;
					tempp.x += -Time.deltaTime / 4;
					tempp.y += Time.deltaTime / 4;
				}
				else if (distance >= jarak_baru)
				{
					distance = jarak_baru;
					tempp.x -= -Time.deltaTime / 4;
					tempp.y -= Time.deltaTime / 4;
				}

			}
            else
            {
				if (distance <= jarak_baru)
				{
					distance = jarak_baru;
					tempp.x += Time.deltaTime / 4;
					tempp.y += Time.deltaTime / 4;
				}
				else if (distance >= jarak_baru)
				{
					distance = jarak_baru;
					tempp.x -= Time.deltaTime / 4;
					tempp.y -= Time.deltaTime / 4;
				}

			}

			
			bentuk_image.transform.localScale = tempp;



			
			Vector3 direction = Input.mousePosition - bentuk_image.transform.position;


			Debug.DrawRay(transform.position, direction, Color.green);

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;

			transform.eulerAngles = Vector3.forward * angle;

			/*
			float jarak = Vector2.Distance(Input.mousePosition, bentuk_image.transform.position);

			float jarakmax = jarak++;


			float jarakmin = jarak--;

			Debug.Log("jarakMax" + jarakmax);
			Debug.Log("jarakMin" + jarakmin);

			if (jarak == jarakmax)
            {
				tempp = bentuk_image.transform.localScale;

				tempp.x += Time.deltaTime;
				tempp.y += Time.deltaTime;

				
            }
            if(jarak == jarakmin)
            {
				tempp.x -= Time.deltaTime;
				tempp.y -= Time.deltaTime;

			}
			bentuk_image.transform.localScale = tempp;
			//float matfx = Input.mousePosition.x;
			// float matfy = Input.mousePosition.y ;


			//tempp = bentuk_image.transform.localScale;

			//tempp.x = matfy;

			//tempp.y = matfy;

			//bentuk_image.transform.localScale = tempp;


			/*
			float speeda = 2.0f;

			Vector3 direction = Input.mousePosition - transform.position;


			Debug.DrawRay(transform.position, direction, Color.green);

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 1;

			transform.eulerAngles = Vector3.forward * angle;
			
			float matfx = Mathf.Abs(Input.mousePosition.x);
			float matfy = Mathf.Abs(Input.mousePosition.y);
			
			
			Vector3 mosue = Input.mousePosition;

			tempp = bentuk_image.transform.localScale;

			

			tempp.x = Mathf.Abs(matfx / matfy) * 2f;

			tempp.y = Mathf.Abs(matfx / matfy) * 2f;

			bentuk_image.transform.localScale = tempp;

			Debug.Log("TOUCH 2 SEntuhan asjbhbagdhbabdjknakjk");

			

			//transform.position = Vector3.Lerp(bentuk_image.transform.localScale, transform.eulerAngles, speeda * Time.deltaTime);
			//Vector3 newScale = new Vector3(direction.x * Time.deltaTime, direction.y * Time.deltaTime);


			//transform.localScale = Vector3.Lerp(transform.localScale, newScale, speeda * Time.deltaTime);



			/*
			tempp = bentuk_image.transform.localScale;

			Debug.Log("ButtonAction" + ButtonAction);


			Vector3 direction = Input.mousePosition - transform.position;

			

			
			tempp.x = direction.x * sizingFactor;
			tempp.y = direction.y * sizingFactor;

			//Vector3 tempnew = new Vector3(transform.localScale(temp.x, temp.y));
			bentuk_image.transform.localScale = tempp;
			
			
			Vector2 mousePosition = Input.mousePosition;

				Debug.Log("MOVEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
			transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

				Vector3 scale = bentuk_image.transform.localScale;
				scale.x = mousePosition.x * sizingFactor * Time.deltaTime;
				scale.y = mousePosition.y * sizingFactor * Time.deltaTime;

				bentuk_image.transform.localScale = scale;
			
			prevMousePosition = mousePosition;
			*/
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
    {
		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}

    public void OnEndDrag(PointerEventData eventData)
    {
		waktu = 0;

		if (transform.position != startPosition)
		{
			//Debug.Log(bentuk_image.transform.parent);
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
		if (col.gameObject.CompareTag("play_area"))
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
			//Destroy(bentuk_image);
			//bentuk_image.transform.parent = o_panel.transform;
			//bentuk_image.transform.position = awal;
		}
	}
}
 