using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBateria : MonoBehaviour, IPointerClickHandler
{
   private Personagem scPlayer;
   public GameObject posCheckBateria;

   private void Start()
   {
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
      posCheckBateria = GameObject.FindGameObjectWithTag("PosCheckBateria");

   }
   private void Update()
   {
      
      if (this.transform.position.x > posCheckBateria.transform.position.x && this.transform.position.y <= posCheckBateria.transform.position.y)
      {
         scPlayer.scInventario.slotBateria = true;
      }
      

   }

   public void buttonInfos()
   {
      scPlayer.scPuzzles.buttonName = "Bateria";

      scPlayer.scInventario.imgLanterna.enabled = false;
      scPlayer.scInventario.imgChaveMestra.enabled = false;
      scPlayer.scInventario.imgDicas.enabled = false;
      scPlayer.scInventario.imgFuzivel.enabled = false;
      scPlayer.scInventario.imgIndutor.enabled = false;
      scPlayer.scInventario.imgResistor.enabled = false;
      scPlayer.scInventario.imgBateria.enabled = false;
      scPlayer.scInventario.imgBotaoElevador.enabled = false;

      scPlayer.scInventario.titulo.text = "Bateria";
      scPlayer.scInventario.descricao.text = "A bateria serve para recarregar a lanterna.";

      scPlayer.scInventario.imgBateria.enabled = true;


   }

   public void buttonActions()
   {
      if (scPlayer.scInventario.pegouLanterna)
      {
         if (!scPlayer.scInventario.slotBateria)
         {
            scPlayer.scInventario.buttonUsar.SetActive(true);
         }
         else
         {
            scPlayer.scInventario.buttonUsar.SetActive(false);
         }

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
