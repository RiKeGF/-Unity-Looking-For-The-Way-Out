using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
   public GameObject textCheatHUD;
   public Personagem scPlayer;
   public Text cheat;
   public bool chatAberto;
   public string comando;

   public GameObject locSala1;
   public GameObject locSala2;
   public GameObject locSala3;
   public GameObject locSala4;

   private void Start()
   {
      textCheatHUD.SetActive(false);
   }


   private void Update()
   {

      if (scPlayer.scInventario.invOpen)
      {
         if (Input.GetKeyDown(KeyCode.T))
         {
            
            if (!chatAberto)
            {                       
               textCheatHUD.SetActive(true);
               cheat.text = "";
               comando = "";
               chatAberto = true;
            }

         }
         if (Input.GetKeyDown(KeyCode.Return))
         {
            if (chatAberto)
            {
               comando = cheat.text;

               if (scPlayer.scInventario.count < 4)
               {
                  if (comando == "/Lanterna")
                  {
                     scPlayer.scInventario.InventarioAddItem("Lanterna", 1);
                     scPlayer.scInventario.InventarioAddItem("Lanterna", 4);
                     scPlayer.scInventario.actionItemPerson(1, scPlayer.goLanterna, "Lanterna");
                  }
                  else if (comando == "/Bateria")
                  {
                     scPlayer.scInventario.InventarioAddItem("Bateria", 0);
                  }
                  else if (comando == "/Fuzivel")
                  {
                     scPlayer.scInventario.InventarioAddItem("Fuzivel", 0);
                  }
                  else if (comando == "/ChaveMestra")
                  {
                     scPlayer.scInventario.InventarioAddItem("ChaveMestra", 0);
                  }
                  else if (comando == "/Resistor")
                  {
                     scPlayer.scInventario.InventarioAddItem("Resistor", 0);
                  }
                  else if (comando == "/Dicas")
                  {
                     scPlayer.scInventario.InventarioAddItem("Dicas", 0);
                  }
                  else if (comando == "/Botao")
                  {
                     scPlayer.scInventario.InventarioAddItem("BotaoElevador", 0);
                  }
               }

               if (comando == "/tp Sala1")
               {
                  scPlayer.gameObject.transform.position = locSala1.transform.position;
               }
               else if (comando == "/tp Sala2")
               {
                  scPlayer.gameObject.transform.position = locSala2.transform.position;
               }
               else if (comando == "/tp Sala3")
               {
                  scPlayer.gameObject.transform.position = locSala3.transform.position;
               }
               else if (comando == "/tp Sala4")
               {
                  scPlayer.gameObject.transform.position = locSala4.transform.position;
               }
               else if (comando == "/Creditos")
               {
                  StartCoroutine(scPlayer.scElevador.iniciarElevador());
               }



               cheat.text = "";
               comando = "";

               textCheatHUD.SetActive(false);

               chatAberto = false;
            }
         }
      }
   }

}
