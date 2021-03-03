using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
   public Personagem scPlayer;
   public float velocidade = 1;
   public bool ligado;
   public bool desligou;
   public bool parar;
   public bool posicao;

   public BoxCollider tranca;

   public Slots slot3;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      
      if (scPlayer.scPuzzles.retirouChave)
      {
         if (!slot3.itemCerto && tranca.enabled)
         {
            tranca.enabled = false;
         }
         scPlayer.velociadeVentilador = velocidade;

         if (velocidade <= 0)
         {
            parar = true;
         }

         if (desligou && velocidade <= 0)
         {
            ligado = false;
            parar = false;
            desligou = false;
            scPlayer.scSons.somVentiladorAtivando.Stop();
            scPlayer.scSons.somVentiladorAtivo.Stop();
            scPlayer.scSons.somVentiladorDesativando.Stop();

         }

         if (!parar)
         {
            if (!slot3.itemCerto && !ligado)
            {
               StartCoroutine("inicializandoVentilador");
               ligado = true;
            }

            if (velocidade <= 0)
            {
               ligado = false;
            }

            if (ligado)
            {
               this.transform.Rotate(0, 0, velocidade, Space.Self);
            }          
         }

      }
      else
      {
         if (!slot3.itemCerto)
         {
            this.transform.Rotate(0, 0, 3, Space.Self);
         }
         else 
         {
            if (posicao)
            {
               velocidade = 0;

               if (tranca.enabled)
               {
                  tranca.enabled = false;
               }
            }
            else
            {
               this.transform.Rotate(0, 0, 3, Space.Self);
            }
               
         }

      }

      if (slot3.itemCerto && !desligou)
      {
         StartCoroutine("desligandoVentilador");
         desligou = true;
      }
   }

   IEnumerator inicializandoVentilador()
   {
      if (!scPlayer.scSons.somVentiladorAtivando.isPlaying)
      {
         scPlayer.scSons.somVentiladorAtivando.Play();
      }
      while (velocidade < 20)
      {
         velocidade += 2;
         yield return new WaitForSeconds(0.7f);
      }
      velocidade = 20;

      yield return new WaitForSeconds(3f);

      if (!scPlayer.scSons.somVentiladorAtivo.isPlaying)
      {
         scPlayer.scSons.somVentiladorAtivo.Play();
      }

      StopCoroutine("inicializandoVentilador");
   }
   IEnumerator desligandoVentilador()
   {

      scPlayer.scSons.somVentiladorAtivo.Stop();


      if (!scPlayer.scSons.somVentiladorDesativando.isPlaying && ligado)
      {
         scPlayer.scSons.somVentiladorDesativando.Play();
      }
      while (velocidade > 2)
      {
         velocidade -= 2;
         yield return new WaitForSeconds(0.7f);
      }

      if (scPlayer.scPuzzles.finalizouPuzzle3)
      {
         while (velocidade > 0)
         {
            if (velocidade <= 2 && posicao)
            {
               velocidade = 0;
            }
            else
            {
               velocidade = 2;
            }
            yield return new WaitForSeconds(0.7f);
         }
      }



      StopCoroutine("desligandoVentilador");
   }
}
