using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioAnomaly : MonoBehaviour
{
    public AudioSource radioSource;

    public void TurnOnRadio()
    {
        if (radioSource != null)
        {
            radioSource.Play();
        }
    }
}
