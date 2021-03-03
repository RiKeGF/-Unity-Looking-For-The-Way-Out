using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luzes : MonoBehaviour
{
   public Personagem scPlayer;

   public Light luzInfoCaixaEnergia;

   public PiscarLuz[] scPiscarLuzS3;

   public bool pegouLampada = false;
   public Light[] luzLampadaSpot;
   public Light[] luzLampadaArea;
   public GameObject[] lampadas;

   public Light[] luzEmergenciaSpotS3;
   public Light[] luzEmergenciaAreaS3;

   public Light luzEmergenciaAreaGerador;

   public Material corLampadaAcesa;
   public Material corLampadaApagada;

   public GameObject[] barra;

   public Material luzVermelha;
   public Material luzLaraja;
   public Material luzVerde;

   public int qntAcesa = 0;


   private void Start()
   {
      luzInfoCaixaEnergia.enabled = false;

      for (int i = 0; i < luzLampadaSpot.Length; i++)
      {
         luzLampadaSpot[i].enabled = false;
         
      }

      for (int i = 0; i < luzLampadaArea.Length; i++)
      {
         luzLampadaArea[i].enabled = false;
      }
   }

   private void Update()
   {
    

   }


}
