using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCards : MonoBehaviour
{
    
    public AudioClip clip;

    private void OnMouseDown()
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}

