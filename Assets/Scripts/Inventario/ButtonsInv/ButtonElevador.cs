using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonElevador : MonoBehaviour, IPointerClickHandler
{
   private Personagem scPlayer;


   private void Start()
   {
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();

   }

   public void buttonInfos()
   {
      scPlayer.scPuzzles.buttonName = "BotaoElevador";

      scPlayer.scInventario.imgLanterna.enabled = false;
      scPlayer.scInventario.imgChaveMestra.enabled = false;
      scPlayer.scInventario.imgDicas.enabled = false;
      scPlayer.scInventario.imgFuzivel.enabled = false;
      scPlayer.scInventario.imgIndutor.enabled = false;
      scPlayer.scInventario.imgBateria.enabled = false;
      scPlayer.scInventario.imgResistor.enabled = false;
      scPlayer.scInventario.imgBotaoElevador.enabled = false;


      scPlayer.scInventario.titulo.text = "Botao do Elevador";
      scPlayer.scInventario.descricao.text = "Serve para ativar a porta do elevador.";

      scPlayer.scInventario.imgBotaoElevador.enabled = true;


   }

   void buttonActions()
   {
      if (scPlayer.scAcao.nomeSlot.Equals("Slot1") && scPlayer.scPuzzles.puzzleAreaID == 2)
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
