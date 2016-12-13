using UnityEngine;
using System.Collections;
//script by Jessie Cox
public class SoundManager : MonoBehaviour {

	//The Audio source variable
	AudioSource  myAudioSource;

	//the audio clip variable that changes depending on what we collide with
	AudioClip audioToPlay;


	//game objects that hold the sound
	public GameObject objectForAudio;
	public GameObject MouseAudio;





	//the game object "gohst"

	public GameObject gohst;


	//audio array with all coin sounds
	static public AudioClip[] coinSounds;


	//audio array with all mouse click sounds
	static public AudioClip[] clickSounds;




	void Awake () {
		//load sound into array
		coinSounds = Resources.LoadAll<AudioClip>("chomp");
	
	}

	//to make a sound when the mouse is being clicked
	void OnGUI(){
		Event e = Event.current;
		if (e.isMouse) {
			MouseAudio.GetComponent<AudioSource> ().Play ();
		}
	}


	// Update is called once per frame
	void Update () {

	}

	//play sound on collision with pacdots
	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "pacdot")
		{

			//play a random sound out of the folder
			audioToPlay = coinSounds [Random.Range (0, coinSounds.Length)];
			myAudioSource = objectForAudio.GetComponent<AudioSource> ();
			myAudioSource.clip = audioToPlay;
			myAudioSource.Play ();


		}
		//on collision with gohst play sound
		if(col.gameObject.tag == "gohst")
		{
			if (GameManager.scared == true) {
				//different sound if gohst is scared and pacman can eat them
				GetComponent<AudioSource> ().Play ();
			}
			else{
			gohst.GetComponent<AudioSource>().Play();
			}
		}


}


}
