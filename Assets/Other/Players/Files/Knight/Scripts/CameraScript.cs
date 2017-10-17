using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform rotationCentreLeftRight, rotationCentreUpDown, mainCamera;
	public float mouseSpeed = 1;
	public float cameraSpeed = 7;
	public bool touchSth = false;
	public Transform player;
	Vector3 rotVect = new Vector3();
	Vector3 startCamPosition = new Vector3();
	float camBackCD = 1;
		
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		mainCamera = Camera.main.transform;
		startCamPosition = gameObject.transform.localPosition;
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.layer == 8)
		{
			touchSth = true;
			if(transform.localPosition.z < -2)
			gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 40,Space.Self);
		}
	} 

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.layer == 8)
		{
			touchSth = false;
			camBackCD = 1;
		}
	}
		
	void FixedUpdate()
	{
		
	}

	void LateUpdate()
	{
		rotationCentreLeftRight.position = Vector3.Lerp(rotationCentreLeftRight.position, player.position, Time.deltaTime * cameraSpeed);


		if(camBackCD >= 0)
			camBackCD -= Time.deltaTime;

		if(!touchSth && gameObject.transform.localPosition.z > startCamPosition.z && camBackCD < 0)
			gameObject.transform.Translate(Vector3.back * Time.deltaTime * 10,Space.Self);

		mainCamera.localPosition = Vector3.Lerp(mainCamera.localPosition,transform.localPosition,0.2f);


		rotVect.x = 0;
		rotVect.y = Input.GetAxis("Mouse X");

		rotationCentreLeftRight.Rotate(rotVect*mouseSpeed,Space.Self);

		rotVect.y = 0;
		rotVect.x = -Input.GetAxis("Mouse Y");

		rotationCentreUpDown.Rotate(rotVect*mouseSpeed,Space.Self);

		rotVect = rotationCentreUpDown.localEulerAngles;

		if(rotVect.x < 180)
		{
			
		}
		else
		{
			rotVect.x -= 360;
		}

		rotVect.x = Mathf.Clamp(rotVect.x, -15,70);

		rotationCentreUpDown.localEulerAngles = rotVect;
	
		rotVect = Vector3.zero;
	}



}
