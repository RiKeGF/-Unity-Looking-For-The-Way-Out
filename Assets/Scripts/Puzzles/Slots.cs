using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
   public int IDPuzzle;
   public int IDSlot;
   public Personagem scPlayer;
   public bool ocupado;

   public bool itemCerto;

   private void OnTriggerStay(Collider col)
   {

      switch (IDPuzzle)
      {
         case 1:
         {
            switch (IDSlot)
            {
               case 1:
               {

                  if (scPlayer.scPuzzles.itensSlotsPz1_s1.transform.childCount == 0)
                  {
                     ocupado = false;
                  }
                  else
                  {
                     ocupado = true;
                  }



                  if (col.transform.tag == "Vazio")
                  {
                     ocupado = false;
                  }

                  if (col.tag == "Fuzivel" && ocupado)
                  {
                     itemCerto = true;
                  }
                  else if ((col.transform.tag == "Resistor" || col.transform.tag == "Indutor") && ocupado)
                  {
                     itemCerto = false;
                  }
                  else if (!ocupado)
                  {
                     itemCerto = false;
                  }


                  break;
               }
               case 2:
               {

                  if (scPlayer.scPuzzles.itensSlotsPz1_s2.transform.childCount == 0)
                  {
                     ocupado = false;
                  }
                  else
                  {
                     ocupado = true;
                  }

                  if (col.tag == "Fuzivel" && ocupado)
                  {
                     itemCerto = true;
                  }
                  else if ((col.transform.tag == "Resistor" || col.transform.tag == "Indutor") && ocupado)
                  {
                     itemCerto = false;
                  }
                  else if (!ocupado)
                  {
                     itemCerto = false;
                  }

                  break;
               }
            }
            break;
         }
         case 2:
         {
            switch (IDSlot)
            {
               case 1:
               {

                  if (scPlayer.scPuzzles.itensSlotsPz2_s1.transform.childCount == 0)
                  {
                     ocupado = false;
                  }
                  else
                  {
                     ocupado = true;
                  }

                  if (col.tag == "StaticBotaoElevador"  && ocupado)
                  {
                     itemCerto = true;
                     
                  }
                  else if (!ocupado)
                  {
                     itemCerto = false;
                  }


                  break;
               }
               case 2:
               {

                  if (scPlayer.scPuzzles.itensSlotsPz2_s2.transform.childCount == 0)
                  {
                     ocupado = false;
                  }
                  else
                  {
                     ocupado = true;
                  }

                  if (col.tag == "ChaveMestra" && ocupado)
                  {
                     itemCerto = true;
                  }
                  else if (!ocupado)
                  {
                     itemCerto = false;
                  }

                  break;
               }
            }
            break;
         }
         case 3:
         {
            switch (IDSlot)
            {
               case 1:
               {

                  if (scPlayer.scPuzzles.itensSlotsPz3_s1.transform.childCount == 0)
                  {
                     ocupado = false;
                  }
                  else
                  {
                     ocupado = true;
                  }

                  if (col.tag == "Indutor" && ocupado)
                  {
                     itemCerto = true;
                  }
                  else if ((col.transform.tag == "Resistor" || col.transform.tag == "Fuzivel") && ocupado)
                  {
                     itemCerto = false;
                  }
                  else if (!ocupado)
                  {
                     itemCerto = false;
                  }

                  break;
               }
               case 2:
               {

                  if (scPlayer.scPuzzles.itensSlotsPz3_s2.transform.childCount == 0)
                  {
                     ocupado = false;
                  }
                  else
                  {
                     ocupado = true;
                  }

                  if (col.tag == "Resistor" && ocupado)
                  {
                     itemCerto = true;
                  }
                  else if ((col.transform.tag == "Indutor" || col.transform.tag == "Fuzivel") && ocupado)
                  {
                     itemCerto = false;
                  }
                  else if (!ocupado)
                  {
                     itemCerto = false;
                  }

                  break;
               }
               case 3:
               {

                  if (scPlayer.scPuzzles.itensSlotsPz3_s3.transform.childCount == 0)
                  {
                     ocupado = false;
                  }
                  else
                  {
                     ocupado = true;
                  }

                  if (ocupado)
                  {
                     itemCerto = false;
                  }
                  else 
                  {
                     itemCerto = true;
                  }
                  break;
               }
               case 4:
               {

                  if (scPlayer.scPuzzles.itensSlotsPz3_s4.transform.childCount == 0)
                  {
                     ocupado = false;
                  }
                  else
                  {
                     ocupado = true;
                  }

                  if (col.tag == "Fuzivel" && ocupado)
                  {
                     itemCerto = true;
                  }
                  else if ((col.transform.tag == "Indutor" || col.transform.tag == "Resistor") && ocupado)
                  {
                     itemCerto = false;
                  }
                  else if (!ocupado)
                  {
                     itemCerto = false;
                  }
                  break;
               }
            }
            break;
         }

      }



   }

}

