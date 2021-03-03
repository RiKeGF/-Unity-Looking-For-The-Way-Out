using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Temperatura : MonoBehaviour
{
   public Personagem scPlayer;


   public float temperaturaSala;
   public float count = 0.5f;
   public float countTimer = 1f;

   public ParticleSystem[] neblinaChao;
   public ParticleSystem neblinaAr;
   public ParticleSystem[] ar;

   public bool checkDesligouAr;

   public bool neblinaChaoAtivada;
   public bool neblinaArAtivada;
   private float countMax;

   public bool iniciouEvento;

   void Start()
   {
      temperaturaSala = 25;

      scPlayer.scHUD.textTimer.GetComponent<Animator>().speed = 1f;

      scPlayer.scHUD.textTimer.text = temperaturaSala.ToString("F1") + "ºC";
      desativarPariculas();
      verificarTemperatura();


      for (int i = 0; i < scPlayer.scLuzes.luzEmergenciaAreaS3.Length; i++)
      {
         scPlayer.scLuzes.luzEmergenciaAreaS3[i].color = new Color(0, 255, 0);
         scPlayer.scLuzes.luzEmergenciaSpotS3[i].color = new Color(0, 255, 0);
      }
   }

   private void FixedUpdate()
   {
      if (scPlayer.scPuzzles.startEvent)
      {
         iniciouEvento = true;
         checkDesligouAr = false;

         if (!scPlayer.scSons.somCronometro.isPlaying)
         {
            scPlayer.scSons.somCronometro.Play();
         }

         if (!scPlayer.scSons.somArCondicionadoLigando.isPlaying)
         {
            scPlayer.scSons.somArCondicionadoLigando.Play();
         }

         alterarHUD();
      }
      else
      {
         if ((!scPlayer.scSons.somArCondicionadoDesligando.isPlaying && !checkDesligouAr) && iniciouEvento)
         {
            scPlayer.scSons.somArCondicionadoDesligando.Play();
            checkDesligouAr = true;
            iniciouEvento = false;
         }

         if (scPlayer.scSons.somCronometro.isPlaying)
         {
            scPlayer.scSons.somCronometro.Stop();
         }

         if (scPlayer.scSons.somArCondicionadoLigando.isPlaying)
         {
            scPlayer.scSons.somArCondicionadoLigando.Stop();
         }

         scPlayer.scHUD.fundoTimer.enabled = false;
         scPlayer.scHUD.textTimer.enabled = false;
      }

   }
   void Update()
   {
      verificarTemperatura();

      if (scPlayer.scPuzzles.retirouChave && !scPlayer.scPuzzles.finalizouPuzzle3)
      {
         if (!neblinaChaoAtivada)
         {
            ativarNeblinaChao();
         }

         if (temperaturaSala < 20 && !neblinaArAtivada)
         {
            ativarNeblinaAr();
         }

         alterarDensidadeNeblina();


         if (temperaturaSala > -15)
         {
            diminuirTemperatura();
         }

      }
      else
      {
         if (temperaturaSala < 25)
         {
            aumentarTemperatura();
         }
         else
         {
            desativarPariculas();
         }

      }


   }

   public void desativarPariculas()
   {
      for (int i = 0; i < neblinaChao.Length; i++)
      {
         neblinaChao[i].Stop();
      }

      neblinaAr.Stop();

      for (int i = 0; i < ar.Length; i++)
      {
         ar[i].Stop();
      }
      neblinaChaoAtivada = false;
   }

   public void desativarArCondicionado()
   {
      for (int i = 0; i < ar.Length; i++)
      {
         ar[i].Stop();
      }

      neblinaArAtivada = false;
   }

   public void ativarNeblinaChao()
   {
      for (int i = 0; i < neblinaChao.Length; i++)
      {
         neblinaChao[i].Play();
      }
      for (int i = 0; i < ar.Length; i++)
      {
         ar[i].Play();
      }
      neblinaChaoAtivada = true;
   }

   public void ativarNeblinaAr()
   {

      neblinaAr.Play();

      neblinaArAtivada = true;
   }

   public void alterarDensidadeNeblina()
   {
      if (temperaturaSala > 25)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 0;
           
         }

         neblinaAr.emissionRate = 0;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[0];
      }
      else if (temperaturaSala == 23)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 1;
         }
         neblinaAr.emissionRate = 1;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[1];
      }
      else if (temperaturaSala == 20)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 3;
         }

         neblinaAr.emissionRate = 2;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[2];
      }
      else if (temperaturaSala == 18)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 5;
         }

         neblinaAr.emissionRate = 3;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[3];
      }
      else if (temperaturaSala == 15)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 8;
         }

         neblinaAr.emissionRate = 6;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[4];

      }
      else if (temperaturaSala == 13)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 10;
         }

         neblinaAr.emissionRate = 8;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[5];
      }
      else if (temperaturaSala == 10)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 13;
         }

         neblinaAr.emissionRate = 10;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[6];
      }
      else if (temperaturaSala == 5)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 15;
         }

         neblinaAr.emissionRate = 13;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[7];

      }
      else if (temperaturaSala == -5)
      {
         for (int i = 0; i < neblinaChao.Length; i++)
         {
            neblinaChao[i].emissionRate = 18;
         }

         neblinaAr.emissionRate = 18;

         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[8];

      }
      else if (temperaturaSala == -9)
      {
         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[9];
      }
      else if (temperaturaSala == -12)
      {
         scPlayer.scHUD.gelo.color = scPlayer.scHUD.alfa[10];
      }
   }

   public void verificarTemperatura()
   {
      if (temperaturaSala >= 25)
      {
         scPlayer.scHUD.textTemperatura.color = new Color(255, 255, 255);
         for (int i = 0; i < scPlayer.scLuzes.luzEmergenciaAreaS3.Length; i++)
         {
            scPlayer.scLuzes.scPiscarLuzS3[i].valorCount = 2;
            scPlayer.scLuzes.luzEmergenciaAreaS3[i].color = new Color(0, 255, 0);
            scPlayer.scLuzes.luzEmergenciaSpotS3[i].color = new Color(0, 255, 0);
         }


      }
      else if (temperaturaSala < 25 && temperaturaSala > 10)
      {
         scPlayer.scHUD.textTemperatura.color = new Color(255, 120, 0);
         for (int i = 0; i < scPlayer.scLuzes.luzEmergenciaAreaS3.Length; i++)
         {
            scPlayer.scLuzes.scPiscarLuzS3[i].valorCount = 0.8f;
            scPlayer.scLuzes.luzEmergenciaAreaS3[i].color = new Color(255, 120, 0);
            scPlayer.scLuzes.luzEmergenciaSpotS3[i].color = new Color(255, 120, 0);
         }


      }
      else if (temperaturaSala <= 10)
      {
         scPlayer.scHUD.textTemperatura.color = new Color(255, 0, 0);

         for (int i = 0; i < scPlayer.scLuzes.luzEmergenciaAreaS3.Length; i++)
         {
            scPlayer.scLuzes.scPiscarLuzS3[i].valorCount = 0.3f;
            scPlayer.scLuzes.luzEmergenciaAreaS3[i].color = new Color(255, 0, 0);
            scPlayer.scLuzes.luzEmergenciaSpotS3[i].color = new Color(255, 0, 0);
         }

      }
   }

   public void alterarHUD()
   {
      scPlayer.scHUD.fundoTimer.enabled = true;
      scPlayer.scHUD.textTimer.enabled = true;

      scPlayer.scHUD.textTimer.text = temperaturaSala.ToString("F1") + "ºC";

      if (temperaturaSala > 20)
      {
         scPlayer.scHUD.textTimer.GetComponent<Animator>().speed = 1f;
         countMax = 1f;

         scPlayer.scSons.somCronometro.pitch = 0.6f;
      }
      else if (temperaturaSala > 10 && temperaturaSala < 15)
      {
         scPlayer.scHUD.textTimer.GetComponent<Animator>().speed = 1.4f;
         countMax = 0.8f;

         scPlayer.scSons.somCronometro.pitch = 0.8f;

      }
      else if (temperaturaSala > 0 && temperaturaSala <= 10)
      {
         scPlayer.scHUD.textTimer.GetComponent<Animator>().speed = 1.7f;
         countMax = 0.5f;

         scPlayer.scSons.somCronometro.pitch = 1f;
      }
      else if (temperaturaSala <= 0)
      {
         scPlayer.scHUD.textTimer.GetComponent<Animator>().speed = 2f;
         countMax = 0.3f;

         scPlayer.scSons.somCronometro.pitch = 1.2f;
      }

   }

   public void aumentarTemperatura()
   {
      count -= Time.deltaTime;

      if (count < 0)
      {
         temperaturaSala++;
         alterarDensidadeNeblina();
         count = countMax;
      }
   }

   public void diminuirTemperatura()
   {
      count -= Time.deltaTime;

      if (count < 0)
      {
         temperaturaSala--;
         alterarDensidadeNeblina();
         count = countMax;
      }
   }
}
