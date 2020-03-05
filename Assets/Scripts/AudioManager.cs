using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour {

	// Use this for initialization
	public Sound[] sounds ;
	public static AudioManager instance ;
	public AudioMixerGroup audioMixer ;

	void Start () {
		Play("Theme");
		
	}

	void Awake(){

		if(instance == null){
			instance = this ;
		}else{
			Destroy(gameObject);
			return ;
		}

		DontDestroyOnLoad(gameObject);

		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip ;
			s.source.outputAudioMixerGroup =  audioMixer;

			s.source.volume = s.volume ;
			s.source.pitch = s.pitch ;
			s.source.loop = s.loop ;
		}
	}

	// Update is called once per frame
	public void Play (string name) {
		Sound s = Array.Find(sounds, sounds => sounds.name == name);
		if(s == null){
			Debug.Log("Sound: " + name + " not found!!");
			return ;
		}
		s.source.Play();
	}
}
