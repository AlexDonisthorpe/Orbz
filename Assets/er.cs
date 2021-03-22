using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class er : MonoBehaviour

{
    //set your RTPCID to the name of your desired gameparameter (under GameSyncs)
    public static string rtpcID = "Modulation";

    [SerializeField] int scaleMultiplier = 2;
    [SerializeField] int smoothingMultiplier = 4;

    // Update is called once per frame
    void Update()
    {
        // RTPCValue_type.RTPCValue_Global
        // for whatever reason, this constant isn't exposed by name by WWise C#/Unity headers
        int type = 1;

        // will contain the value of the RTPC parameter after the GetRTPCValue call
        float value;

        // retrieves current value of the RTPC parameter and stores it in 'value'
        AkSoundEngine.GetRTPCValue(rtpcID, gameObject, 0, out value, ref type);
     

        // Scaling the value down and smoothing the value a little for visual representation
        value = scaleMultiplier * (value + 48) / 48;
        value = Mathf.Round(value * 1000f) / 1000f;
        value = Mathf.Pow(value, 2);

        // Setting the scale ~
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(value, value, value), (Time.deltaTime * smoothingMultiplier));
    }

  
}
