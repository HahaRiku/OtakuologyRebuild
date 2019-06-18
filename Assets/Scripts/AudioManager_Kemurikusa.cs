using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Kemurikusa : MonoBehaviour {
	
	//private AudioClip clip;
	private AudioSource Bgm;
	
	// Use this for initialization
	void Start () {
		Bgm = gameObject.AddComponent<AudioSource>();
		StartCoroutine(PlayBgm());
	}
	
	private IEnumerator PlayBgm(){
		Bgm.clip = Resources.Load<AudioClip>("Kemurikusa/KEMURIKUSA_Intro");
		Bgm.Play();
		yield return new WaitForSeconds(Bgm.clip.length);
		Bgm.clip = Resources.Load<AudioClip>("Kemurikusa/KEMURIKUSA_Loop");
		Bgm.Play();
		Bgm.loop = true;
	}
}
