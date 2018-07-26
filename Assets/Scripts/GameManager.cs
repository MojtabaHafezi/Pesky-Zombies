using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Threading;



public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	public GameObject gamesPanel;
	public GameObject controlsPanel;
	public GameObject winPanel, losePanel;
	public GameObject timeBackground;
	private AudioListener audioMaster;
	public Text timeRemaining;
	private bool timeRunning;
	private Helicopter heli;
	



	// Use this for initialization
	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}
	

		DontDestroyOnLoad (gameObject);

	}

	void Start ()
	{

		controlsPanel.SetActive (false);
		winPanel.SetActive (false);
		losePanel.SetActive (false);
		timeBackground.SetActive (false);
		timeRunning = false;
		StartGame ();
	
	}
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetButtonDown ("Cancel")) {
			PauseGame ();
			gamesPanel.SetActive (true);
		}
		if (timeRunning) {
			float timeLeft = 300 - heli.GetTime ();
			timeRemaining.text = "Time: " + timeLeft.ToString ("F1");
		}
	}



	public void Win ()
	{
		//WIN RESULTS
		PauseGame ();
		winPanel.SetActive (true);
	}

	public void GameOver ()
	{
		//Death results
		PauseGame ();
		losePanel.SetActive (true);
	}

	public void StartGame ()
	{
		gamesPanel.SetActive (true);
		Cursor.visible = true;
		//controlsPanel.SetActive (true);
		PauseGame ();


	}

	//Loading the level after game ends or on death
	public void LoadLevel ()
	{
		SceneManager.LoadScene ("Game");
		Start ();
	}

	//For pausing and starting the game
	public void PauseGame ()
	{
		Time.timeScale = 0;
		Cursor.visible = true;
		
	}

	public void ContinueGame ()
	{
		gamesPanel.SetActive (false);
		controlsPanel.SetActive (false);
		winPanel.SetActive (false);
		losePanel.SetActive (false);

		Cursor.visible = false;
		Time.timeScale = 1;

	}

	//Quitting the application
	public void QuitRequest ()
	{
		Application.Quit ();
	}
		
	//Open control panel for controls and close
	public void OpenControlPanel ()
	{
		gamesPanel.SetActive (false);
		controlsPanel.SetActive (true);
	
	}

	public void CloseControlPanel ()
	{
		gamesPanel.SetActive (true);
		controlsPanel.SetActive (false);
	}



	//Activate the time left text
	public void ActivateTimeText ()
	{
		timeBackground.SetActive (true);
		timeRunning = true;
		heli = FindObjectOfType <Helicopter> ();
	}
}
