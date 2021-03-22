using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("MenuStop", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
