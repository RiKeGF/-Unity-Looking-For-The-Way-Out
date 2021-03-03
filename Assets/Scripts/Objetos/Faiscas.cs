using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faiscas : MonoBehaviour
{
   public ParticleSystem faiscas;
   public Personagem scPlayer;
   private float count = 0.3f;
   private float count2 = 3;
   public bool status;

   private void Start()
   {
      faiscas.Clear();
      faiscas.Stop();
   }
   void Update()
    {
      if (scPlayer.scPuzzles.finalizouPuzzle1 && scPlayer.scGerador.funcionando)
      {
         count2 -= Time.deltaTime;
         if (count2 < 0)
         {
            count -= Time.deltaTime;

            if (count <= 0)
            {
               status = !status;
               if (status)
               {
                  faiscas.Play();
               }
               else
               {
                  faiscas.Stop();
                  count2 = 3;
               }

               count = 0.3f;
               
            }
         }
         
      }
    }
}
