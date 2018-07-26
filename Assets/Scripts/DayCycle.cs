using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour
{
	[Tooltip ("Numbers of minutes ingame in seconds")]
	public float timeScale = 60;

	private Light light;
	private LensFlare lens;
	private Transform transformSun;

	public GameObject flashlight;
	// Use this for initialization
	void Start ()
	{

		light = GetComponent <Light> ();
		lens = GetComponent <LensFlare> ();
		transformSun = GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float angleThisFrame = Time.deltaTime / 360 * timeScale;
		transform.RotateAround (transform.position, Vector3.forward, angleThisFrame);
		SetLight ();
		 
	}

	private void SetLight ()
	{
		if (transformSun.rotation.eulerAngles.x > 90) {
			light.enabled = false;
			lens.enabled = false;
			Camera.main.clearFlags = CameraClearFlags.SolidColor;
			if (flashlight != null)
				flashlight.SetActive (true);
		} else {
			light.enabled = true;
			lens.enabled = true;
			Camera.main.clearFlags = CameraClearFlags.Skybox;
			if (flashlight != null)
				flashlight.SetActive (false);
		}
	}
}
