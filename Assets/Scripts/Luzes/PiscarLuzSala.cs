using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscarLuzSala : MonoBehaviour
{
   public Personagem scPlayer;

   public bool ligou;
   public bool desligou;
   public bool ligada;

   public bool piscou1;
   public bool piscou2;
   public bool checkLigou;
   public bool checkDesl;

   public bool interruptor;

   public bool verificarLuz;

   int countLigar = 0;
   private float timerLigar = 1;
   int countDesl = 0;
   private float timerDeslig = 1;

   void Update()
   {
      timerLigar -= Time.deltaTime;
      timerDeslig -= Time.deltaTime;

      if (interruptor)
      {
         ligou = true;
         desligou = false;
      }
      else
      {
         ligou = false;
         desligou = true;
      }

      /*
      if (checkLigou)
      {
         if (!verificarLuz)
         {
            if (interruptor)
            {
               scPlayer.scLuzes.qntAcesa++;
            }
            
            verificarLuz = true;         
         }
      }
      else
      {
         if (verificarLuz)
         {
            if (!interruptor)
            {
               scPlayer.scLuzes.qntAcesa--;
            }
            
            verificarLuz = false;
         }
         
      }*/

      if (scPlayer.scPuzzles.finalizouPuzzle1 && scPlayer.scGerador.funcionando)
      {
         if (ligou)
         {
            if (!piscou1)
            {
               piscarLuz();
            }
         }
         else if (desligou)
         {
            if (!piscou2)
            {
               escolhaLuzes(0);
               statusLuz();

               checkDesl = true;
               countDesl = 0;
               timerDeslig = 1;

               checkLigou = false;
               countLigar = 0;
               timerLigar = 1;

               piscou1 = false;

               piscou2 = true;
            }
         }

      }
      else
      {
         for (int i = 0; i < scPlayer.scLuzes.luzLampadaSpot.Length; i++)
         {
            scPlayer.scLuzes.luzLampadaSpot[i].enabled = false;
            
         }
         for (int i = 0; i < scPlayer.scLuzes.luzLampadaArea.Length; i++)
         {
            scPlayer.scLuzes.luzLampadaArea[i].enabled = false;

         }
         
         for (int j = 0; j < scPlayer.scLuzes.lampadas.Length; j++)
         {
            scPlayer.scLuzes.lampadas[j].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
         }
         scPlayer.scLuzes.qntAcesa = 0;
      }

      if (!scPlayer.scPuzzles.finalizouPuzzle1 && scPlayer.scInventario.pegouFuzivel)
      {
         desligou = true;

         if (!piscou2)
         {
            desligarLuz();
         }

      }

     
   }
  


   public void desligarLuz()
   {

      if (countDesl < 3)
      {

         if (timerDeslig < 0)
         {
            //scPlayer.scLuzes.corLampadaAcesa.SetColor("_EmissionColor", new Color(255f, 255f, 255f));

            escolhaLuzes(1);

            timerDeslig = Random.Range(0.1f, 0.6f);
            countDesl++;
         }
         else
         {
            //scPlayer.scLuzes.corLampada.

            escolhaLuzes(0);
         }
      }
      else
      {

         statusLuz();

         checkDesl = true;
         countDesl = 0;
         timerDeslig = 1;

         checkLigou = false;
         countLigar = 0;
         timerLigar = 1;

         piscou1 = false;

         piscou2 = true;


      }
   }

   void escolhaLuzes(int acao)
   {
      if (acao == 0)
      {
         switch (scPlayer.scLocalizacao.localizacaoID)
         {
            case 1:
            {
               scPlayer.scLuzes.luzLampadaSpot[0].enabled = false;
               scPlayer.scLuzes.luzLampadaArea[0].enabled = false;
               scPlayer.scLuzes.lampadas[0].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[1].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               break;
            }
            case 2:
            {
               scPlayer.scLuzes.luzLampadaSpot[1].enabled = false;
               scPlayer.scLuzes.luzLampadaArea[1].enabled = false;
               scPlayer.scLuzes.luzLampadaSpot[2].enabled = false;
               scPlayer.scLuzes.luzLampadaArea[2].enabled = false;
               scPlayer.scLuzes.lampadas[2].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[3].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[4].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[5].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               break;
            }
            case 3:
            {
               scPlayer.scLuzes.luzLampadaSpot[3].enabled = false;
               scPlayer.scLuzes.luzLampadaArea[3].enabled = false;
               scPlayer.scLuzes.luzLampadaSpot[4].enabled = false;
               scPlayer.scLuzes.luzLampadaArea[4].enabled = false;
               scPlayer.scLuzes.luzLampadaSpot[5].enabled = false;
               scPlayer.scLuzes.luzLampadaArea[5].enabled = false;
               scPlayer.scLuzes.lampadas[6].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[7].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[8].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[9].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[10].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               scPlayer.scLuzes.lampadas[11].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
               break;
            }
         }
      }
      else if (acao == 1)
      {

         switch (scPlayer.scLocalizacao.localizacaoID)
         {
            case 1:
            {
               scPlayer.scLuzes.luzLampadaSpot[0].enabled = true;
               scPlayer.scLuzes.luzLampadaArea[0].enabled = true;
               scPlayer.scLuzes.lampadas[0].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[1].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               break;
            }
            case 2:
            {
               scPlayer.scLuzes.luzLampadaSpot[1].enabled = true;
               scPlayer.scLuzes.luzLampadaArea[1].enabled = true;
               scPlayer.scLuzes.luzLampadaSpot[2].enabled = true;
               scPlayer.scLuzes.luzLampadaArea[2].enabled = true;
               scPlayer.scLuzes.lampadas[2].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[3].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[4].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[5].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               break;
            }
            case 3:
            {
               scPlayer.scLuzes.luzLampadaSpot[3].enabled = true;
               scPlayer.scLuzes.luzLampadaArea[3].enabled = true;
               scPlayer.scLuzes.luzLampadaSpot[4].enabled = true;
               scPlayer.scLuzes.luzLampadaArea[4].enabled = true;
               scPlayer.scLuzes.luzLampadaSpot[5].enabled = true;
               scPlayer.scLuzes.luzLampadaArea[5].enabled = true;
               scPlayer.scLuzes.lampadas[6].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[7].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[8].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[9].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[10].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               scPlayer.scLuzes.lampadas[11].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaAcesa;
               break;
            }
         }
      }



   }

   void piscarLuz()
   {
      if (countLigar < 3)
      {
         if (timerLigar < 0)
         {
            escolhaLuzes(1);

            timerLigar = Random.Range(0.1f, 0.6f);
            countLigar++;
         }
         else
         {

            escolhaLuzes(0);
         }
      }
      else
      {
         statusLuz();
         checkLigou = true;
         countLigar = 0;
         timerLigar = 1;

         checkDesl = false;
         countDesl = 0;
         timerDeslig = 1;

         piscou2 = false;

         piscou1 = true;
      }

   }

   void statusLuz()
   {
      if (scPlayer.scPuzzles.finalizouPuzzle1)
      {
         if (ligou)
         {
            escolhaLuzes(1);
         }
         else if (desligou)
         {
            escolhaLuzes(0);
         }
         
      }
      else
      {
         escolhaLuzes(0);
      }
   }
}
