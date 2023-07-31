using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ControlVolumen : MonoBehaviour {

	public AudioMixer audioMixer;

	

	public void SetVolume(float volumen)
	{
		audioMixer.SetFloat("volumen",volumen);
	}
}
