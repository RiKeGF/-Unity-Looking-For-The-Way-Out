using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonChaveMestra : MonoBehaviour, IPointerClickHandler
{
   private Personagem scPlayer;
   public bool hud;


   private void Start()
   {
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();

   }

   public void buttonInfos()
   {
      scPlayer.scPuzzles.buttonName = "ChaveMestra";

      scPlayer.scInventario.imgLanterna.enabled = false;
      scPlayer.scInventario.imgDicas.enabled = false;
      scPlayer.scInventario.imgFuzivel.enabled = false;
      scPlayer.scInventario.imgIndutor.enabled = false;
      scPlayer.scInventario.imgResistor.enabled = false;
      scPlayer.scInventario.imgBateria.enabled = false;
      scPlayer.scInventario.imgBotaoElevador.enabled = false;

      scPlayer.scInventario.titulo.text = "Chave Mestra | Hardkey";
      scPlayer.scInventario.descricao.text = "Uma chave velha junto de uma chave de segurança digital.";

      scPlayer.scInventario.imgChaveMestra.enabled = true;


   }

   void buttonActions()
   {
      if (!hud)
      {
         if ((scPlayer.scAcao.nomeSlot.Equals("CadeadoS1") && scPlayer.scLocalizacao.localizacaoID == 1)
            || (scPlayer.scAcao.nomeSlot.Equals("CadeadoS4") && scPlayer.scLocalizacao.localizacaoID == 4)
            )
         {
            scPlayer.scInventario.buttonUsar.SetActive(true);
            scPlayer.scInventario.buttonDropar.SetActive(false);

         }
         else if (scPlayer.scAcao.nomeSlot.Equals("Slot2") && scPlayer.scLocalizacao.localizacaoID == 2)
         {
            if (scPlayer.scLocalizacao.localizacaoID == 2 && scPlayer.scPuzzles.scCaixaEnergia2.checkAbriu)
            {
               if (!scPlayer.scAcao.scSlots.ocupado)
               {
                  scPlayer.scInventario.buttonUsar.SetActive(true);
               }
               else
               {
                  scPlayer.scInventario.buttonUsar.SetActive(false);
               }
            }
            else
            {
               scPlayer.scInventario.buttonUsar.SetActive(false);
            }
         }
         else
         {
            scPlayer.scInventario.buttonUsar.SetActive(false);
            scPlayer.scInventario.buttonDropar.SetActive(true);
         }


         scPlayer.scInventario.viewActionsHUD.transform.position = new Vector3(this.transform.position.x + 70, this.transform.position.y - 40, this.transform.position.z);
         scPlayer.scInventario.viewActionsHUD.SetActive(true);
      }
      else
      {

         scPlayer.scInventario.viewActionsHUD.SetActive(false);
      }
   }

   public void OnPointerClick(PointerEventData eventData)
   {
      if (eventData.button == PointerEventData.InputButton.Left)
      {
         buttonInfos();
         scPlayer.scInventario.viewActionsHUD.SetActive(false);
      }


      else if (eventData.button == PointerEventData.InputButton.Middle)
      {

      }

      else if (eventData.button == PointerEventData.InputButton.Right)
      {
         buttonActions();
         buttonInfos();
      }

   }


}
