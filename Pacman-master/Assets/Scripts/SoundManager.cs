using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	//The Audio source variable
	AudioSource  myAudioSource;
	//the audio clip variable that changes depending on what we collide with
	AudioClip audioToPlay;
	GameObject objectForAudio;
	bool destroyAudioSource;


	public float amp = 1f;


	//the game objects "coin" and "gohst"
	public GameObject coin;
	public GameObject gohst;


	//audio array with all coin sounds
	static public AudioClip[] coinSounds;

	//audio array with all gohst sounds
	static public AudioClip[] gohstSounds;


	//audio array with all mouse click sounds
	static public AudioClip[] clickSounds;



	//bool for playing theme music
	public bool themeMusic = true;


	void Awake () {
		
		coinSounds = Resources.LoadAll<AudioClip>("Sounds");
		gohstSounds = Resources.LoadAll<AudioClip>("Sounds");
		clickSounds = Resources.LoadAll<AudioClip>("Sounds");



	}

	//to make a sound when the mouse is being clicked
	void OnMouseDown(){
		audioToPlay = clickSounds [Random.Range (0, coinSounds.Length)];
		PlayAudio ();
	}


	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "coin")
		{

			audioToPlay = coinSounds [Random.Range (0, coinSounds.Length)];
			PlayAudio ();
		}

		if(col.gameObject.tag == "gohst")
		{
			audioToPlay = gohstSounds [Random.Range (0, gohstSounds.Length)];
			PlayAudio ();
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



	void PlayAudio(){

	if (objectForAudio.GetComponent<AudioSource>() == null) {
		//we can instantiate an audiosource on any object at runtime if needed
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
}
}
