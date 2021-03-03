using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localização : MonoBehaviour
{
   public Personagem scPlayer;

   public int localizacaoID;
   private void OnTriggerStay(Collider col)
   {
      if (this.transform.tag == "Localização")
      {
         if (col.transform.tag == "Sala1")
         {
            localizacaoID = 1;
         }
         else if (col.transform.tag == "Sala2")
         {
            localizacaoID = 2;
         }

         else if (col.transform.tag == "Sala3")
         {
            localizacaoID = 3;
         }

         else if (col.transform.tag == "Sala4")
         {
            localizacaoID = 4;
         }
         else if (col.transform.tag == "Elevador")
         {
            localizacaoID = 5;
         }
      }
      
   }
}
