using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
   public Personagem scPlayer;

   public GameObject[] fios;

   public void applyBotao()
   {
      if (scPlayer.scPuzzles.puzzleID == 1)
      {
         switch (scPlayer.scPuzzles.buttonName)
         {
            case "Fuzivel":
            {
               scPlayer.scSons.somColocarItem.Play();
               if (scPlayer.scPuzzles.puzzle)
               {
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot1"))
                  {
                     GameObject tempFuzivel = Instantiate(scPlayer.scItens.fuzivel, scPlayer.scPuzzles.spawnObjPuzzle1_1.transform.position, Quaternion.identity);
                     tempFuzivel.gameObject.transform.position = new Vector3(tempFuzivel.transform.position.x, tempFuzivel.transform.position.y - 0.2f, tempFuzivel.transform.position.z);

                     tempFuzivel.transform.Rotate(-90, 0, 0, Space.Self);
                     tempFuzivel.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz1_s1.transform);
                     tempFuzivel.transform.localScale = new Vector3(0.2f, 0.2f, 0.22f);
                  }
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot2"))
                  {
                     GameObject tempFuzivel = Instantiate(scPlayer.scItens.fuzivel, scPlayer.scPuzzles.spawnObjPuzzle1_2.transform.position, Quaternion.identity);
                     tempFuzivel.gameObject.transform.position = new Vector3(tempFuzivel.transform.position.x, tempFuzivel.transform.position.y - 0.2f, tempFuzivel.transform.position.z);

                     tempFuzivel.transform.Rotate(-90, 0, 0, Space.Self);
                     tempFuzivel.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz1_s2.transform);
                     tempFuzivel.transform.localScale = new Vector3(0.2f, 0.2f, 0.22f);
                  }
                  scPlayer.scInventario.InventarioDelItem("Fuzivel");
                  scPlayer.scInventario.InventarioOpen();
               }
               break;
            }
            case "Resistor":
            {
               scPlayer.scSons.somColocarItem.Play();
               if (scPlayer.scPuzzles.puzzle)
               {
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot1"))
                  {
                     GameObject tempResistor = Instantiate(scPlayer.scItens.resistor, scPlayer.scPuzzles.itensSlotsPz1_s1.transform.position, Quaternion.identity);
                     tempResistor.transform.Rotate(-90, 0, 0, Space.Self);
                     tempResistor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz1_s1.transform);
                     tempResistor.transform.localScale = new Vector3(0.071f, 0.071f, 0.071f);
                  }
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot2"))
                  {
                     GameObject tempResistor = Instantiate(scPlayer.scItens.resistor, scPlayer.scPuzzles.itensSlotsPz1_s2.transform.position, Quaternion.identity);
                     tempResistor.transform.Rotate(-90, 0, 0, Space.Self);
                     tempResistor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz1_s2.transform);
                     tempResistor.transform.localScale = new Vector3(0.071f, 0.071f, 0.071f);
                  }

                  scPlayer.scInventario.InventarioDelItem("Resistor");
                  scPlayer.scInventario.InventarioOpen();
               }
               break;
            }
            /*
            case "Indutor":
            {
               if (scPlayer.scPuzzles.puzzle)
               {
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot1"))
                  {
                     GameObject tempIndutor = Instantiate(scPlayer.scItens.indutor, scPlayer.scPuzzles.spawnObjPuzzle1_1.transform.position, Quaternion.identity);
                     tempIndutor.transform.Rotate(-90, 0, 0, Space.Self);
                     tempIndutor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz1_s1.transform);

                     scPlayer.scInventario.InventarioDelItem("Indutor");
                     scPlayer.scInventario.InventarioOpen();
                  }
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot2"))
                  {
                     GameObject tempIndutor = Instantiate(scPlayer.scItens.indutor, scPlayer.scPuzzles.spawnObjPuzzle1_2.transform.position, Quaternion.identity);
                     tempIndutor.transform.Rotate(-90, 0, 0, Space.Self);
                     tempIndutor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz1_s2.transform);

                     scPlayer.scInventario.InventarioDelItem("Indutor");
                     scPlayer.scInventario.InventarioOpen();
                  }
               }
               break;
            }
            */

         }

      }
      else if (scPlayer.scPuzzles.puzzleID == 1.2f)
      {
         switch (scPlayer.scPuzzles.buttonName)
         {
            case "ChaveMestra":
            {
               scPlayer.scSons.somColocarItem.Play();
               if (scPlayer.scPuzzles.puzzle && scPlayer.scAcao.nomeSlot.Equals("CadeadoS1"))
               {
                  GameObject tempChaveMestra = Instantiate(scPlayer.scItens.chaveMestra, scPlayer.scPuzzles.spawnObjPuzzle1_3.transform.position, Quaternion.identity);
                  tempChaveMestra.transform.Rotate(-180, -90, 0, Space.Self);
                 // tempChaveMestra.transform.position = new Vector3(tempChaveMestra.transform.position.x, tempChaveMestra.transform.position.y, tempChaveMestra.transform.position.z);
                  tempChaveMestra.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz1_cadeado.transform);
                  tempChaveMestra.GetComponent<Rigidbody>().useGravity = false;
                  tempChaveMestra.GetComponent<BoxCollider>().isTrigger = true;


                  Destroy(scPlayer.scPuzzles.puzzleArea1_3);
                  scPlayer.scPuzzles.puzzle = false;
                  scPlayer.scInventario.viewInfoHUD.SetActive(true);
                  scPlayer.scInventario.bgInfoHUD.SetActive(true);
               }


               scPlayer.scInventario.InventarioDelItem("ChaveMestra");
               scPlayer.scInventario.InventarioOpen();
               break;
            }

         }

      }
      else if (scPlayer.scPuzzles.puzzleID == 2)
      {
         switch (scPlayer.scPuzzles.buttonName)
         {
            case "BotaoElevador":
            {
               scPlayer.scSons.somColocarItem.Play();

               if (scPlayer.scPuzzles.puzzle)
               {
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot1"))
                  {
                     fios[0].SetActive(false);
                     fios[1].SetActive(false);
                     fios[2].SetActive(false);
                    
                     scPlayer.scPuzzles.botaoElevador.SetActive(true);

                    // GameObject tempBotaoElevador = Instantiate(scPlayer.scItens.botaoElevador, scPlayer.scPuzzles.spawnObjPuzzle2_1.transform.position, Quaternion.identity);
                    scPlayer.scPuzzles.botaoElevador.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz2_s1.transform);
                    // tempBotaoElevador.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    //scPlayer.scPuzzles.botaoElevador.transform.position = new Vector3(-0.01300693f, -0.08524656f, 0.0001292825f);
                    // tempBotaoElevador.transform.Rotate(20, 160, 100, Space.Self);
                    // tempBotaoElevador.transform.localScale = new Vector3(3.9756f, 3.9756f, 3.9756f);
                  }

                  scPlayer.scInventario.InventarioDelItem("BotaoElevador");
                  scPlayer.scInventario.InventarioOpen();
               }
               break;
            }
            case "ChaveMestra":
            {
               scPlayer.scSons.somColocarItem.Play();
               if (scPlayer.scPuzzles.puzzle)
               {
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot2"))
                  {
                     GameObject tempChaveMestra = Instantiate(scPlayer.scItens.chaveMestra, scPlayer.scPuzzles.spawnObjPuzzle2_2.transform.position, Quaternion.identity);

                     tempChaveMestra.transform.position = new Vector3(tempChaveMestra.transform.position.x + 0.1f, tempChaveMestra.transform.position.y, tempChaveMestra.transform.position.z);
                     tempChaveMestra.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz2_s2.transform);
                     tempChaveMestra.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                     tempChaveMestra.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                     tempChaveMestra.transform.Rotate(0, 180, 0, Space.Self);


                  }

                  scPlayer.scInventario.InventarioDelItem("ChaveMestra");
                  scPlayer.scInventario.InventarioOpen();
               }
               break;
            }
         }

      }
      else if (scPlayer.scPuzzles.puzzleID == 3)
      {
         switch (scPlayer.scPuzzles.buttonName)
         {
            case "Fuzivel":
            {
               scPlayer.scSons.somColocarItem.Play();
               if (scPlayer.scPuzzles.puzzle)
               {
                  /*
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot1"))
                  {
                     GameObject tempFuzivel = Instantiate(scPlayer.scItens.fuzivel, scPlayer.scPuzzles.spawnObjPuzzle3_1.transform.position, Quaternion.identity);
                     tempFuzivel.transform.Rotate(-90, 0, 0, Space.Self);
                     tempFuzivel.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s1.transform);
                     tempFuzivel.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                  }
                  */
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot2"))
                  {
                     GameObject tempFuzivel = Instantiate(scPlayer.scItens.fuzivel, scPlayer.scPuzzles.spawnObjPuzzle3_2.transform.position, Quaternion.identity);
                     tempFuzivel.transform.Rotate(-90, 0, 0, Space.Self);
                     tempFuzivel.transform.position = new Vector3(scPlayer.scPuzzles.itensSlotsPz3_s2.transform.position.x, scPlayer.scPuzzles.itensSlotsPz3_s2.transform.position.y - 0.1f, scPlayer.scPuzzles.itensSlotsPz3_s2.transform.position.z);
                     tempFuzivel.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s2.transform);
                    
                     tempFuzivel.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                     tempFuzivel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                  }
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot3"))
                  {
                     GameObject tempFuzivel = Instantiate(scPlayer.scItens.fuzivel, scPlayer.scPuzzles.spawnObjPuzzle3_3.transform.position, Quaternion.identity);
                     tempFuzivel.transform.Rotate(0, 0, 0, Space.Self);
                     tempFuzivel.transform.position = new Vector3(scPlayer.scPuzzles.itensSlotsPz3_s3.transform.position.x, scPlayer.scPuzzles.itensSlotsPz3_s3.transform.position.y, scPlayer.scPuzzles.itensSlotsPz3_s3.transform.position.z -0.12f);
                     tempFuzivel.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s3.transform);

                     tempFuzivel.transform.localScale = new Vector3(0.2f, 0.2f, 0.23f);
                     tempFuzivel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                  }
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot4"))
                  {
                     GameObject tempFuzivel = Instantiate(scPlayer.scItens.fuzivel, scPlayer.scPuzzles.spawnObjPuzzle3_4.transform.position, Quaternion.identity);
                     tempFuzivel.transform.Rotate(0, 0, 0, Space.Self);          
                     tempFuzivel.transform.position = new Vector3(scPlayer.scPuzzles.itensSlotsPz3_s4.transform.position.x, scPlayer.scPuzzles.itensSlotsPz3_s4.transform.position.y, scPlayer.scPuzzles.itensSlotsPz3_s4.transform.position.z-0.12f);
                     tempFuzivel.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s4.transform);

                     tempFuzivel.transform.localScale = new Vector3(0.2f, 0.2f, 0.23f);
                     tempFuzivel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                  }
                  scPlayer.scInventario.InventarioDelItem("Fuzivel");
                  scPlayer.scInventario.InventarioOpen();
               }

               break;
            }
            case "Resistor":
            {
               scPlayer.scSons.somColocarItem.Play();
               if (scPlayer.scPuzzles.puzzle)
               {
                  /*
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot1"))
                  {
                     GameObject tempResistor = Instantiate(scPlayer.scItens.resistor, scPlayer.scPuzzles.spawnObjPuzzle3_1.transform.position, Quaternion.identity);
                     tempResistor.transform.Rotate(0, 0, -90, Space.Self);
                     tempResistor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s1.transform);
                     tempResistor.transform.localScale = new Vector3(0.068f, 0.068f, 0.068f);
                     tempResistor.transform.position = new Vector3(tempResistor.transform.position.x, tempResistor.transform.position.y, tempResistor.transform.position.z + 0.1f);
                  }
                  */
                  if (scPlayer.scAcao.nomeSlot.Equals("Slot2"))
                  {
                     GameObject tempResistor = Instantiate(scPlayer.scItens.resistor, scPlayer.scPuzzles.spawnObjPuzzle3_2.transform.position, Quaternion.identity);
                     tempResistor.transform.Rotate(-90, 0, -90, Space.Self);
                     tempResistor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s2.transform);
                     tempResistor.transform.localScale = new Vector3(0.068f, 0.068f, 0.068f);
                     tempResistor.transform.position = new Vector3(tempResistor.transform.position.x, tempResistor.transform.position.y + 0.07f, tempResistor.transform.position.z);
                  }
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot3"))
                  {
                     GameObject tempResistor = Instantiate(scPlayer.scItens.resistor, scPlayer.scPuzzles.spawnObjPuzzle3_3.transform.position, Quaternion.identity);
                     tempResistor.transform.Rotate(0, 0, -90, Space.Self);
                     tempResistor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s3.transform);
                     tempResistor.transform.localScale = new Vector3(0.068f, 0.068f, 0.068f);
                     tempResistor.transform.position = new Vector3(tempResistor.transform.position.x, tempResistor.transform.position.y, tempResistor.transform.position.z + 0.07f);
                  }
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot4"))
                  {
                     GameObject tempResistor = Instantiate(scPlayer.scItens.resistor, scPlayer.scPuzzles.spawnObjPuzzle3_4.transform.position, Quaternion.identity);
                     tempResistor.transform.Rotate(0, 0, -90, Space.Self);
                     tempResistor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s4.transform);
                     tempResistor.transform.localScale = new Vector3(0.068f, 0.068f, 0.068f);
                     tempResistor.transform.position = new Vector3(tempResistor.transform.position.x, tempResistor.transform.position.y, tempResistor.transform.position.z + 0.07f);
                  }

                  scPlayer.scInventario.InventarioDelItem("Resistor");
                  scPlayer.scInventario.InventarioOpen();
               }
               break;
            }
            case "Indutor":
            {
               scPlayer.scSons.somColocarItem.Play();
               if (scPlayer.scPuzzles.puzzle)
               {

                  if (scPlayer.scAcao.nomeSlot.Equals("Slot1"))
                  {
                     GameObject tempIndutor = Instantiate(scPlayer.scItens.indutor, scPlayer.scPuzzles.spawnObjPuzzle3_1.transform.position, Quaternion.identity);
                     tempIndutor.transform.Rotate(0, -90, 0, Space.Self);
                     tempIndutor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s1.transform);
                     tempIndutor.transform.localScale = new Vector3(0.1f, 0.3f, 0.15f);
                  }
                  /*
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot2"))
                  {
                     GameObject tempIndutor = Instantiate(scPlayer.scItens.indutor, scPlayer.scPuzzles.spawnObjPuzzle3_2.transform.position, Quaternion.identity);
                     tempIndutor.transform.Rotate(0, -90, 0, Space.Self);
                     tempIndutor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s2.transform);
                     tempIndutor.transform.localScale = new Vector3(0.057f, 0.057f, 0.057f);
                  }
                  else if (scPlayer.scAcao.nomeSlot.Equals("Slot3"))
                  {
                     GameObject tempIndutor = Instantiate(scPlayer.scItens.indutor, scPlayer.scPuzzles.spawnObjPuzzle3_3.transform.position, Quaternion.identity);
                     tempIndutor.transform.Rotate(0, -90, 0, Space.Self);
                     tempIndutor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s3.transform);
                     tempIndutor.transform.localScale = new Vector3(0.057f, 0.057f, 0.057f);
                  }

                  if (scPlayer.scAcao.nomeSlot.Equals("Slot4"))
                  {
                     GameObject tempIndutor = Instantiate(scPlayer.scItens.indutor, scPlayer.scPuzzles.spawnObjPuzzle3_4.transform.position, Quaternion.identity);
                     tempIndutor.transform.Rotate(0, -90, 0, Space.Self);
                     tempIndutor.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz3_s4.transform);
                     tempIndutor.transform.localScale = new Vector3(0.057f, 0.057f, 0.057f);
                  }
                  */

                  scPlayer.scInventario.InventarioDelItem("Indutor");
                  scPlayer.scInventario.InventarioOpen();
               }
               break;
            }

         }

      }
      else if (scPlayer.scPuzzles.puzzleID == 4)
      {
         switch (scPlayer.scPuzzles.buttonName)
         {
            case "ChaveMestra":
            {
               scPlayer.scSons.somColocarItem.Play();
               if (scPlayer.scPuzzles.puzzle && scPlayer.scAcao.nomeSlot.Equals("CadeadoS4"))
               {
                  GameObject tempChaveMestra = Instantiate(scPlayer.scItens.chaveMestra, scPlayer.scPuzzles.spawnObjPuzzle4.transform.position, Quaternion.identity);
                  tempChaveMestra.transform.Rotate(-180, -90, 0, Space.Self);
                  //tempChaveMestra.transform.position = new Vector3(tempChaveMestra.transform.position.x + 0.25f, tempChaveMestra.transform.position.y, tempChaveMestra.transform.position.z);
                  tempChaveMestra.transform.SetParent(scPlayer.scPuzzles.itensSlotsPz4.transform);
                  tempChaveMestra.GetComponent<Rigidbody>().useGravity = false;
                  tempChaveMestra.GetComponent<BoxCollider>().isTrigger = true;

                  Destroy(scPlayer.scPuzzles.puzzleArea4);
                  scPlayer.scPuzzles.puzzle = false;
                  scPlayer.scInventario.viewInfoHUD.SetActive(true);
                  scPlayer.scInventario.bgInfoHUD.SetActive(true);
               }


               scPlayer.scInventario.InventarioDelItem("ChaveMestra");
               scPlayer.scInventario.InventarioOpen();
               break;
            }

         }

      }


      switch (scPlayer.scPuzzles.buttonName)
      {
         case "Bateria":
         {
            if (scPlayer.scInventario.pegouLanterna)
            {
               scPlayer.scSons.somEquipandoBateria.Play();
               scPlayer.scInventario.InventarioDelItem("Bateria");
               scPlayer.scLanterna.equipou = true;

            }

            break;
         }
      }

      scPlayer.scInventario.viewActionsHUD.SetActive(false);
      scPlayer.scInventario.zerarConfigInventario();
   }


   public void dropItem()
   {
      scPlayer.scInventario.InventarioDropItem(scPlayer.scPuzzles.buttonName);
      scPlayer.scInventario.viewActionsHUD.SetActive(false);
   }

   public void fechaBotao()
   {
      scPlayer.scInventario.viewActionsHUD.SetActive(false);
   }

}
