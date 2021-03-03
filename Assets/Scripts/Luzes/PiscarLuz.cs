using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscarLuz : MonoBehaviour
{
   public int idSala;

   public Light luz;
   public Light[] luzArea;
   public float count;
   public float valorCount;
   public Personagem scPlayer;

   public Material corLampadaAcesa;
   public Material corLampadaApagada;
   public GameObject lampada;

   public bool apagouTodasLuzesEmergencia;

   void Update()
   {
      if (scPlayer.scPuzzles.scCaixaEnergia3.scSlot4.itemCerto)
      {
         piscarLuz();
         apagouTodasLuzesEmergencia = false;
      }
      else
      {
         if (!apagouTodasLuzesEmergencia)
         {
            for (int i = 0; i < scPlayer.scLuzes.barra.Length; i++)
            {
               scPlayer.scLuzes.barra[i].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
            }

            for (int i = 0; i < luzArea.Length; i++)
            {
               luzArea[i].enabled = false;

            }

            luz.enabled = false;

            apagouTodasLuzesEmergencia = true;
         }
         
      }

   }

   void piscarLuz()
   {
      count -= Time.deltaTime;

      if (count <= 0)
      {
         luz.enabled = !luz.enabled;

         for (int i = 0; i < luzArea.Length; i++)
         {
            luzArea[i].enabled = !luzArea[i].enabled;

         }
         if (idSala == 1)
         {
            if (luzArea[0].enabled)
            {
               lampada.GetComponent<MeshRenderer>().material = corLampadaAcesa;

            }
            else
            {
               lampada.GetComponent<MeshRenderer>().material = corLampadaApagada;
            }
         }


         count = valorCount;
      }
      if (idSala == 3)
      {
         if (scPlayer.scPuzzles.scTemperatura.temperaturaSala >= 25)
         {
            for (int i = 0; i < scPlayer.scLuzes.barra.Length; i++)
            {
               if (luz.enabled)
               {
                  scPlayer.scLuzes.barra[i].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.luzVerde;
               }
               else
               {
                  scPlayer.scLuzes.barra[i].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               }

            }
         }
         else if (scPlayer.scPuzzles.scTemperatura.temperaturaSala > 10 && scPlayer.scPuzzles.scTemperatura.temperaturaSala < 25)
         {
            for (int i = 0; i < scPlayer.scLuzes.barra.Length; i++)
            {
               if (luz.enabled)
               {
                  scPlayer.scLuzes.barra[i].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.luzLaraja;
               }
               else
               {
                  scPlayer.scLuzes.barra[i].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               }

            }
         }
         else if (scPlayer.scPuzzles.scTemperatura.temperaturaSala <= 10)
         {
            for (int i = 0; i < scPlayer.scLuzes.barra.Length; i++)
            {
               if (luz.enabled)
               {
                  scPlayer.scLuzes.barra[i].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.luzVermelha;
               }
               else
               {
                  scPlayer.scLuzes.barra[i].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               }

            }
         }


      }


   }
}
