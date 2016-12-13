using UnityEngine;
using System.Collections;
//script by Jessie Cox
public class SoundManager : MonoBehaviour {

	//The Audio source variable
	AudioSource  myAudioSource;

	//the audio clip variable that changes depending on what we collide with
	AudioClip audioToPlay;



	public GameObject objectForAudio;
	public GameObject MouseAudio;




	public float amp = 1f;


	//the game objects "coin" and "gohst"

	public GameObject gohst;


	//audio array with all coin sounds
	static public AudioClip[] coinSounds;


	//audio array with all mouse click sounds
	static public AudioClip[] clickSounds;



	//bool for playing theme music



	void Awake () {

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


	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "pacdot")
		{


			audioToPlay = coinSounds [Random.Range (0, coinSounds.Length)];
			myAudioSource = objectForAudio.GetComponent<AudioSource> ();
			myAudioSource.clip = audioToPlay;
			myAudioSource.Play ();


		}

		if(col.gameObject.tag == "gohst")
		{
			if (GameManager.scared == true) {

				GetComponent<AudioSource> ().Play ();
			}
			else{
			gohst.GetComponent<AudioSource>().Play();
			}
		}


}


	//randomise Amplitude

	/*void PlayRandomPitchAndVolume()
	{
		//Pitch and Amplitude Randomization.
		amp = Random.Range(0.9f, 1.1f);
		GetComponent<AudioSource>().volume = amp;
		GetComponent<AudioSource>().Play();
	}
*/



	/*void PlayAudio(){

	
		myAudioSource = objectForAudio.AddComponent<AudioSource> ();
		myAudioSource.playOnAwake = false;

		//if we add this component, we should destroy it when we finish
		destroyAudioSource = true;
	} else {
		myAudioSource = objectForAudio.GetComponent<AudioSource> ();
		//			existingAudioClip = myAudioSource.clip;
		destroyAudioSource = false;
	}
	myAudioSource.clip = audioToPlay;
	myAudioSource.Play ();
	//		if (existingAudioClip != null) {
	//			myAudioSource.clip = existingAudioClip;
	//		}

	//we will wait for the audioclip to finish playing before destroying, we could also use PlayOneShot instead
	if (destroyAudioSource) {
		Destroy (myAudioSource, audioToPlay.length);
	}
}*/
}
