using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
   public Personagem scPlayer;
   public bool mandouEnergia;

   // Update is called once per frame
   void Update()
   {
      if (scPlayer.scPuzzles.scValvula.checkAbriu && !mandouEnergia)
      {
         scPlayer.scGerador.energiaMaxAtual = 100;

         scPlayer.scGerador.energia += 20;

         if (scPlayer.scGerador.energia >= 100)
         {
            scPlayer.scGerador.energia = 100;
         }
         mandouEnergia = true;
      }

   }
}
