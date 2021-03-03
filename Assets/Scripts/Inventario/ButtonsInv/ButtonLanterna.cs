using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonLanterna : MonoBehaviour, IPointerClickHandler
{
   private Personagem scPlayer;


   private void Start()
   {
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();

   }


   public void botaoLanterna()
   {
      scPlayer.scPuzzles.buttonName = "Lanterna";


      scPlayer.scInventario.viewActionsHUD.SetActive(false);


      scPlayer.scInventario.imgChaveMestra.enabled = false;
      scPlayer.scInventario.imgDicas.enabled = false;
      scPlayer.scInventario.imgFuzivel.enabled = false;
      scPlayer.scInventario.imgIndutor.enabled = false;
      scPlayer.scInventario.imgResistor.enabled = false;
      scPlayer.scInventario.imgBateria.enabled = false;
      scPlayer.scInventario.imgBotaoElevador.enabled = false;

      scPlayer.scInventario.titulo.text = "Lanterna";
      scPlayer.scInventario.descricao.text = "Precisa de bateria para ser utilizada.";


      scPlayer.scInventario.imgLanterna.enabled = true;
   }
   public void OnPointerClick(PointerEventData eventData)
   {
      if (eventData.button == PointerEventData.InputButton.Left)
      {
         botaoLanterna();
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
