using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public enum AudioSources {
        main,
        wrong,
        wall
    };

    public AudioSource mainSource;
    public AudioSource wrongSource;

    public void EnableMain(){
        mainSource.volume = 1;
        wrongSource.volume = 0;
    }

    public void EnableWrong(){
        mainSource.volume = 0;
        wrongSource.volume = 1;
    }

    public void Enable(AudioSources source){
        switch (source)
        {
            case AudioSources.main:
                mainSource.volume = 1;
                wrongSource.volume = 0;
                Debug.Log("Main!");
                break;
            case AudioSources.wrong:
                mainSource.volume = 0;
                wrongSource.volume = 1;
                Debug.Log("Wrong!");

                break;
            case AudioSources.wall:
                break;
        };
    }


}
