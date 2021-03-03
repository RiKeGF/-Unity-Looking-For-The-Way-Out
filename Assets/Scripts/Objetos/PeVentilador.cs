using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeVentilador : MonoBehaviour
{
   public Personagem scPlayer;
   public Ventilador scVentilador;


   private void OnTriggerStay(Collider other)
   {
      if (other.tag == "Chao")
      {
         scVentilador.posicao = true;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Chao")
      {
         scVentilador.posicao = false;
      }
   }
}
