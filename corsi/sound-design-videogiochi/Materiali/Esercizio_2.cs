using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esercizio_2 : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    private float volume = 1.0f;

    private float cambioSuono = 0.0f;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/TonoVolume");
        instance.start();
    }

    void Update()
    {
        volume = 1.0f / (Punteggio.punteggio + 1);
        Debug.Log(volume);
        instance.setParameterByName("Volume_Dinamico", volume);

        if (Variabili_Globali.azzeraAudio) {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        if (gameObject.transform.position.x < -2)
        {
            cambioSuono = 0.0f;
        } else if (gameObject.transform.position.x > 2)
        {
            cambioSuono = 1.0f;
        } else 
        {
            cambioSuono = 0.5f;
        }

        instance.setParameterByName("Zone", cambioSuono);
    }
}
