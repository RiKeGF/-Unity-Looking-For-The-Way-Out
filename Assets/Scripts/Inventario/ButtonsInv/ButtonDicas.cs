using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonDicas : MonoBehaviour, IPointerClickHandler
{
   private Personagem scPlayer;


   private void Start()
   {
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();

   }

   public void botaoDicas()
   {
      scPlayer.scPuzzles.buttonName = "Dicas";

      scPlayer.scInventario.viewActionsHUD.SetActive(false);

      scPlayer.scInventario.imgLanterna.enabled = false;
      scPlayer.scInventario.imgChaveMestra.enabled = false;
      scPlayer.scInventario.imgFuzivel.enabled = false;
      scPlayer.scInventario.imgIndutor.enabled = false;
      scPlayer.scInventario.imgResistor.enabled = false;
      scPlayer.scInventario.imgBateria.enabled = false;
      scPlayer.scInventario.imgBotaoElevador.enabled = false;

      scPlayer.scInventario.titulo.text = "Dicas";
      scPlayer.scInventario.descricao.text = "Contem instruções sobre componentes.";

      scPlayer.scInventario.imgDicas.enabled = true;


   }

   public void OnPointerClick(PointerEventData eventData)
   {
      if (eventData.button == PointerEventData.InputButton.Left)
      {
         botaoDicas();
         scPlayer.scInventario.viewActionsHUD.SetActive(false);
      }


      else if (eventData.button == PointerEventData.InputButton.Middle)
      {

      }

      else if (eventData.button == PointerEventData.InputButton.Right)
      {

      }

   }

}
