using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gerador : MonoBehaviour
{
   public Personagem scPlayer;

   public bool funcionando;
   public bool primeiraTentativa;

   public float timer;
   public bool podeLigar;
   public bool tentouLigar;
   private bool atribuiuEnergia;
   public bool ativarSomLigando;
   public bool ativarSomDesligando;

   public float energia = 0;
   public float energiaMaxAtual = 80;
   public float energiaMax = 100;
   public float energiaRecuperada = 0;

   public bool jaLigouUmaVez;

   public float countTentouLigar = 3.2f;
   public float countReligarGerador = 5f;
   public float countAtivarSomLoop = 5f;

   public PiscarLuzSala scPiscarLuzSala1;
   public PiscarLuzSala scPiscarLuzSala2;
   public PiscarLuzSala scPiscarLuzSala3;
   //public PiscarLuzSala scPiscarLuzSala4;


   void Start()
   {
      primeiraTentativa = true;
      scPlayer.scLuzes.luzEmergenciaAreaGerador.color = new Color(255, 0, 0);
   }

   void Update()
   {
      if (tentouLigar)
      {
         countTentouLigar -= Time.deltaTime;
         if (countTentouLigar < 0)
         {
            tentouLigar = false;
            countTentouLigar = 3.2f;
         }
      }
      statusEnergia();
      statusGerador();

      if (ativarSomLigando && countAtivarSomLoop > -5f)
      {
         countAtivarSomLoop -= Time.deltaTime;

         if (countAtivarSomLoop < 0)
         {
            if (!scPlayer.scSons.somGeradorAtivo.isPlaying)
            {
               scPlayer.scSons.somGeradorAtivo.Play();
            }
         }
      }
   }

   public void statusGerador()
   {
      if (scPlayer.scPuzzles.finalizouPuzzle1)
      {
         if (podeLigar)
         {     
            scPlayer.scGerador.primeiraTentativa = false;
            funcionando = true;
            jaLigouUmaVez = true;
         }
         else
         {
            funcionando = false;
         }

      }
      if (((!scPlayer.scPuzzles.finalizouPuzzle1 || energia <= 0) && !primeiraTentativa) && funcionando)
      {
         sons(0);

         scPlayer.scSons.somGeradorAtivo.Stop();

         countAtivarSomLoop = 5f;

         ativarSomLigando = false;
         podeLigar = false;
         funcionando = false;
         tentouLigar = false;

         

         timer = 3;
      }


      if (!funcionando)
      {
         scPiscarLuzSala1.interruptor = false;
         scPiscarLuzSala2.interruptor = false;
         scPiscarLuzSala3.interruptor = false;
      }

      if (funcionando)
      {
         scPlayer.scLuzes.luzEmergenciaAreaGerador.color = new Color(0, 255, 0);
      }
      else
      {
         scPlayer.scLuzes.luzEmergenciaAreaGerador.color = new Color(255, 0, 0);

         energia = 0;
      }

      if (scPlayer.scPuzzles.finalizouPuzzle1)
      {
         if (primeiraTentativa)
         {
            if (tentouLigar)
            {
               if (!funcionando)
               {
                  reativarGerador();
               }
            }
         }
         else
         {
            if (!funcionando && jaLigouUmaVez)
            {
               if (countReligarGerador < 0)
               {
                  reativarGerador();
                  
               }
               countReligarGerador -= Time.deltaTime;
            }            
         }
         
      }

      if (!primeiraTentativa && funcionando)
      {
         scPlayer.scHUD.imgFundoEnergiaHUD.enabled = true;
         scPlayer.scHUD.imgGeradorHUD.enabled = true;
         scPlayer.scHUD.imgFundoGeradorHUD.enabled = true;
         scPlayer.scHUD.imgBordaFundoGeradorHUD.enabled = true;
         scPlayer.scHUD.imgEnergiaGeradorHUD.enabled = true;
      }
   }

   public void statusEnergia()
   {
      if (!atribuiuEnergia)
      {
         if (podeLigar && scPlayer.scPuzzles.finalizouPuzzle1)
         {
            energia = energiaMaxAtual;
            atribuiuEnergia = true;
         }
         else
         {
            energia = 0;

         }
      }
   }

   public void sons(int op)
   {
      if (op == 0)
      {

         scPlayer.scSons.somGeradorDesativando.Play();
         ativarSomDesligando = true;

      }
      if (op == 1)
      {

         scPlayer.scSons.somGeradorAtivando.Play();
         ativarSomLigando = true;

      }

   }

   public void reativarGerador()
   {
      if (!ativarSomLigando)
      {
         sons(1);
      }

      timer -= Time.deltaTime;

      if (timer < 0)
      {
         if (scPlayer.scPuzzles.finalizouPuzzle1)
         {
            podeLigar = true;

            if (funcionando)
            {
               countReligarGerador = 5f;
               timer = 3;
            }
         }
         else
         {
            tentouLigar = false;
         }

      }
      else
      {
         podeLigar = false;
         scPlayer.scLuzes.qntAcesa = 0;
         atribuiuEnergia = false;
      }
   }

   public IEnumerator recuperarEnergiaPorta()
   {
      if (funcionando)
      {
         while (energiaRecuperada < 10)
         {
            energiaRecuperada += 2;

            yield return new WaitForSeconds(1f);

         }

         energia += energiaRecuperada;
         energiaRecuperada = 0;
         StopCoroutine(recuperarEnergiaPorta());
      }
     
   }
}
