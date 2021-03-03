using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonIndutor : MonoBehaviour, IPointerClickHandler
{
   private Personagem scPlayer;

   private void Start()
   {
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();

   }


   public void buttonInfos()
   {
      scPlayer.scPuzzles.buttonName = "Indutor";

      scPlayer.scInventario.imgLanterna.enabled = false;
      scPlayer.scInventario.imgChaveMestra.enabled = false;
      scPlayer.scInventario.imgDicas.enabled = false;
      scPlayer.scInventario.imgFuzivel.enabled = false;
      scPlayer.scInventario.imgResistor.enabled = false;
      scPlayer.scInventario.imgBateria.enabled = false;
      scPlayer.scInventario.imgBotaoElevador.enabled = false;

      scPlayer.scInventario.titulo.text = "Indutor";
      scPlayer.scInventario.descricao.text = "É usado para fornecer maior tensão ao circuito.";

      scPlayer.scInventario.imgIndutor.enabled = true;


   }

   void buttonActions()
   {
      if (scPlayer.scAcao.nomeSlot.Equals("Slot1"))
      {
         if(scPlayer.scLocalizacao.localizacaoID == 3 && scPlayer.scPuzzles.scCaixaEnergia3.checkAbriu)
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
      }

      scPlayer.scInventario.viewActionsHUD.transform.position = new Vector3(this.transform.position.x + 70, this.transform.position.y - 40, this.transform.position.z);

      scPlayer.scInventario.viewActionsHUD.SetActive(true);
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
