using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMusica : MonoBehaviour {

    public Slider volume;
    public AudioSource myMusic;
    private void Start()
    {
        volume.value = myMusic.volume;
    }
    // Update is called once per frame
    void Update () {
        myMusic.volume = volume.value;	
	}
}
