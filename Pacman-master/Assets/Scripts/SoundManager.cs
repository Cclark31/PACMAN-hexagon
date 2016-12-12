using UnityEngine;
using System.Collections;


//script by Jessie Cox Decmeber 2016
//for Unity Pacman Project team Hexagon, Logic and Programming in Berklee College of Music
public class SoundManager : MonoBehaviour {

	//The Audio source variable
	AudioSource  myAudioSource;

	//the audio clip variable that changes depending on what we collide with
	AudioClip audioToPlay;


//the gameobjects that hold my audiofiles
	public GameObject objectForAudio;
	public GameObject MouseAudio;





	//the game object "gohst"
	public GameObject gohst;


	//audio array with all coin sounds
	static public AudioClip[] coinSounds;


	//audio array with all mouse click sounds
	static public AudioClip[] clickSounds;





	void Awake () {


//to load all the sounds when the game is started
		coinSounds = Resources.LoadAll<AudioClip>("chomp");

		clickSounds = Resources.LoadAll<AudioClip>("Sounds");

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

//to make a sound on collision
	void OnTriggerEnter2D (Collider2D col)
	{
		//ifcolliding with pacdot
		if(col.gameObject.tag == "pacdot")
		{
//then I play a pacdot sound which is chosen randomly out of the folde loaded on Awake
			audioToPlay = coinSounds [Random.Range (0, coinSounds.Length)];
			myAudioSource = objectForAudio.GetComponent<AudioSource> ();
			myAudioSource.clip = audioToPlay;
			myAudioSource.Play ();


		}
//if colliding with a gohst
		if(col.gameObject.tag == "gohst")
		{
			//if the gohst is scared/blus then I play one sound
			if (GameManager.scared == true) {

				GetComponent<AudioSource> ().Play ();
			}
			//if the gohst isn't scared I play another sound
			else{
			gohst.GetComponent<AudioSource>().Play();
			}
		}


}

}
