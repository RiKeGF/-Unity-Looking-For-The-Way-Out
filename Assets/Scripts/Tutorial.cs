using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
   public Personagem scPlayer;

   public bool concluiu;

   public bool concluiuInventario;
   public bool concluiuLanterna;

   public bool tutorialAtivo;

   void Start()
   {
      desativarTutorial();
   }


   void Update()
   {
      if (!concluiu)
      {
         if (scPlayer.scLocalizacao.localizacaoID == 1)
         {
            concluiu = false;
         }
         else
         {
            concluiu = true;
         }

         if (scPlayer.scAcao.nomeItem.Equals("Mochila") || scPlayer.scAcao.nomeItem.Equals("Lanterna"))
         {
            scPlayer.scHUD.textTutorial.text = "Para pegar utilize o botão esquerdo do mouse.";
            scPlayer.scHUD.trocarImagemTutorial("Pegar");
         }
         else if (scPlayer.scAcao.nomeItem.Equals("Fuzivel") || scPlayer.scAcao.nomeItem.Equals("Bateria") || scPlayer.scAcao.nomeItem.Equals("Dicas"))
         {
            if (scPlayer.scInventario.equipouMochila)
            {
               scPlayer.scHUD.textTutorial.text = "Para pegar itens utilize o botão esquerdo do mouse.";
               scPlayer.scHUD.trocarImagemTutorial("Pegar");
            }
            else
            {
               scPlayer.scHUD.textTutorial.text = "Para pegar os itens você precisa de uma mochila.";
               scPlayer.scHUD.trocarImagemTutorial("Geral");
            }


         }
         else if (scPlayer.scAcao.nomeItem.Equals("CaixaEnergiaS1") || scPlayer.scAcao.nomeItem.Equals("AlavancaPorta2") || scPlayer.scAcao.nomeItem.Equals("Painel"))
         {
            scPlayer.scHUD.textTutorial.text = "Para ativar ou abrir coisas pressione a tecla 'E'.";
            scPlayer.scHUD.trocarImagemTutorial("E");
         }
         else if (scPlayer.scAcao.nomeItem.Equals("CadeadoS1"))
         {
            scPlayer.scHUD.textTutorial.text = "Você precisa de uma chave para abrir os cadeados.";
            scPlayer.scHUD.trocarImagemTutorial("Geral");
         }

         if (scPlayer.scInventario.equipouMochila && !concluiuInventario)
         {
            scPlayer.scHUD.textTutorial.text = "Para abrir o inventário pressione a tecla 'TAB'.";
            scPlayer.scHUD.trocarImagemTutorial("TAB");

            ativarTutorial();

            if (Input.GetKey(KeyCode.Tab))
            {
               desativarTutorial();
               concluiuInventario = true;
            }
         }
         else if (scPlayer.scInventario.pegouLanterna && !concluiuLanterna)
         {        

            if (Input.GetKey(KeyCode.F))
            {
               StartCoroutine(infoBateria());
            }


            if (scPlayer.scInventario.slotBateria)
            {
               scPlayer.scHUD.textTutorial.text = "Para ligar a lanterna pressione a tecla 'F'.";
               scPlayer.scHUD.trocarImagemTutorial("F");

               ativarTutorial();

               if (Input.GetKey(KeyCode.F))
               {
                  desativarTutorial();
                  concluiuLanterna = true;
               }
            }
   
         }

      }

   }


   public void ativarTutorial()
   {
      if (!tutorialAtivo)
      {

         scPlayer.scHUD.bgAnimTutorial.SetBool("Open", true);
         tutorialAtivo = true;
      }
      
   }

   public void desativarTutorial()
   {

      scPlayer.scHUD.bgAnimTutorial.SetBool("Open", false);
      tutorialAtivo = false;
   }

   public IEnumerator infoBateria()
   {
      
      scPlayer.scHUD.bgAnimTutorial.SetBool("Open", true);
      while (true)
      {
         scPlayer.scHUD.textTutorial.text = "Para usar a lanterna equipe a bateria.";
         scPlayer.scHUD.trocarImagemTutorial("Geral");
         yield return new WaitForSeconds(4);
         scPlayer.scHUD.bgAnimTutorial.SetBool("Open", false);
         break;
      }
   }
}
