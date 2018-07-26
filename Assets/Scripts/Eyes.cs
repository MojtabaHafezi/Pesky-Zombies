using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour
{

	private Camera eyes;

	private GameObject weapon;
	private float defaultFOV;


	// Use this for initialization
	void Start ()
	{
		eyes = GetComponent<Camera> ();
		defaultFOV = eyes.fieldOfView;
		weapon = GameObject.FindGameObjectWithTag ("Weapon");

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton ("Fire2")) {
			eyes.fieldOfView = defaultFOV / 1.5f;
//			fovPosition = weapon.transform.localPosition - offset;
//			zoomActivated = true;
		} else {
//			if (!zoomActivated) {
//				defaultPosition = weapon.transform.localPosition;
//			} else {
//				defaultPosition = weapon.transform.localPosition + offset;
//			}
			eyes.fieldOfView = defaultFOV;

		}
	}




}
