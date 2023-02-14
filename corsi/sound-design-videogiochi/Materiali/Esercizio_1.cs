using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esercizio_1 : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    private float volume = 1.0f;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/TonoVolume");
        instance.start();
    }

    void Update()
    {
        volume = 1.0f / (Punteggio.punteggio + 1);
        instance.setParameterByName("Volume_Dinamico", volume);

        if (Variabili_Globali.azzeraAudio) {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
