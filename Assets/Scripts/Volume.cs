using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
   float volumeMaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void volume(float volume)
   {
      volumeMaster = volume;
      AudioListener.volume = volumeMaster;
   }
}
