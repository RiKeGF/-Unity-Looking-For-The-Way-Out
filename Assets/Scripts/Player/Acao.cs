using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acao : MonoBehaviour
{
   public Personagem scPlayer;
   public TextMesh info;

   public string nomeSlot;
   public Slots scSlots;

   public string nomeItem;

   public bool tentou;
   private float countTentou = 1.5f;

   private void Update()
   {

      countTentou -= Time.deltaTime;

      if (countTentou <= 0)
      {
         scPlayer.scAcao.tentou = false;
         countTentou = 1.5f;
      }
   }

   private void OnTriggerStay(Collider col)
   {
      acaoMsgInfo(col, "Stay");

      if (Input.GetKeyDown(KeyCode.E))
      {
         acaoAnimacoes(col, "Stay");

         acaoInterruptores(col, "Stay");

         acaoPortas(col, "Stay");

         if (scPlayer.scPuzzles.puzzle)
         {
            acaoPuzzles(col, "Stay");
         }
      }
      if (Input.GetKey(KeyCode.E))
      {
         acaoGerador(col);
      }

      if (Input.GetMouseButtonDown(0))
      {

         if (col.transform.tag == "Lanterna")
         {
            nomeItem = "";
            scPlayer.scTutorial.desativarTutorial();
            StartCoroutine(scPlayer.scTutorial.infoBateria());

            pegarItens(col, "Stay");

            info.gameObject.SetActive(false);
         }
         else if (col.transform.tag == "Mochila")
         {

            pegarItens(col, "Stay");
         }

      }

      if (scPlayer.scInventario.equipouMochila)
      {
         if (Input.GetMouseButtonDown(0) && !scPlayer.scInventario.invOpen)
         {

            if (col.tag == "Fuzivel" || col.tag == "Indutor" || col.tag == "ChaveMestra" || col.tag == "Bateria" || col.tag == "Resistor" || col.tag == "Dicas" || col.tag == "BotaoElevador")
            {
               if (scPlayer.scInventario.count < 4)
               {
                  if (col.GetComponent<ActiveContornoObj>().estaNoPuzzle)
                  {
                     if (scPlayer.scPuzzles.scCaixaEnergia1.checkAbriu && scPlayer.scPuzzles.puzzleAreaID == 1)
                     {
                        pegarItens(col, "Stay");

                     }
                     else if (scPlayer.scGaveta.aberta && scPlayer.scPuzzles.puzzleAreaID == 1.2f)
                     {
                        pegarItens(col, "Stay");
                     }
                     else if (scPlayer.scPuzzles.scCaixaEnergia2.checkAbriu && scPlayer.scPuzzles.puzzleAreaID == 2)
                     {
                        pegarItens(col, "Stay");
                     }
                     else if (scPlayer.scPuzzles.scCaixaEnergia3.checkAbriu && scPlayer.scPuzzles.puzzleAreaID == 3f)
                     {
                        pegarItens(col, "Stay");

                     }
                  }
                  else
                  {
                     pegarItens(col, "Stay");
                  }
               }
            }

         }
      }


   }

   public void pegarItens(Collider col, string tipo)
   {
      switch (tipo)
      {
         case "Enter":
         {
            break;
         }
         case "Stay":
         {
            if (col.transform.tag == "Lanterna" && !scPlayer.scInventario.pegouLanterna)
            {
               StartCoroutine(scPlayer.scTutorial.infoBateria());

               scPlayer.scSons.somPegarItem.Play();

               scPlayer.scInventario.InventarioAddItem("Lanterna", 1);
               scPlayer.scInventario.InventarioAddItem("Lanterna", 4);

               Destroy(col.gameObject);
               scPlayer.scInventario.actionItemPerson(1, scPlayer.goLanterna, "Lanterna");

               info.gameObject.SetActive(false);
            }
            else if (col.transform.tag == "Indutor")
            {


               if (col.GetComponent<ActiveContornoObj>().estaNoPuzzle)
               {
                  scPlayer.scSons.somPegarItem.Play();

                  scPlayer.scInventario.InventarioAddItem("Indutor", 0);

                  Destroy(col.gameObject);
                  info.gameObject.SetActive(false);
               }
               else
               {
                  scPlayer.scSons.somPegarItem.Play();

                  scPlayer.scInventario.InventarioAddItem("Indutor", 0);

                  Destroy(col.gameObject);
                  info.gameObject.SetActive(false);
               }

            }
            else if (col.transform.tag == "Resistor")
            {
               scPlayer.scSons.somPegarItem.Play();

               scPlayer.scInventario.InventarioAddItem("Resistor", 0);

               Destroy(col.gameObject);
               info.gameObject.SetActive(false);

            }
            else if (col.transform.tag == "Fuzivel")
            {
               if (scPlayer.scLocalizacao.localizacaoID == 1 && !scPlayer.scTutorial.concluiu)
               {
                  if (scPlayer.scHUD.bgAnimTutorial.GetBool("Open"))
                  {
                     scPlayer.scHUD.bgAnimTutorial.SetBool("Open", false);
                  }
               }

               scPlayer.scSons.somPegarItem.Play();

               scPlayer.scInventario.InventarioAddItem("Fuzivel", 0);

               Destroy(col.gameObject);
               info.gameObject.SetActive(false);

            }
            else if (col.transform.tag == "Dicas" && !scPlayer.scInventario.pegouDicas)
            {
               

               scPlayer.scSons.somPegarDicas.Play();

               scPlayer.scInventario.InventarioAddItem("Dicas", 5);

               Destroy(col.gameObject);
               info.gameObject.SetActive(false);
            }
            else if (col.transform.tag == "ChaveMestra")
            {
               scPlayer.scSons.somPegarChave.Play();

               scPlayer.scPuzzles.retirouChave = true;
               //scPlayer.scPortas.porta3b_1.SetBool("Abrir", true);

               scPlayer.scSons.somPegarItem.Play();

               scPlayer.scInventario.InventarioAddItem("ChaveMestra", 0);
               scPlayer.scInventario.InventarioAddItem("ChaveMestra", 6);

               Destroy(col.gameObject);
               info.gameObject.SetActive(false);

               if (scPlayer.scPuzzles.startEvent)
               {
                  scPlayer.scPortas.porta3b_1.SetBool("Abrir", true);
               }
            }
            else if (col.transform.tag == "Bateria")
            {
               

               scPlayer.scSons.somPegarItem.Play();

               scPlayer.scInventario.InventarioAddItem("Bateria", 0);

               Destroy(col.gameObject);
               info.gameObject.SetActive(false);
            }
            else if (col.transform.tag == "BotaoElevador")
            {

               scPlayer.scSons.somPegarItem.Play();

               scPlayer.scInventario.InventarioAddItem("BotaoElevador", 0);

               Destroy(col.gameObject);
               info.gameObject.SetActive(false);

            }
            else if (col.transform.tag == "Mochila")
            {
               if (!scPlayer.scSons.somPegandoMochila.isPlaying)
               {
                  scPlayer.scSons.somPegandoMochila.Play();
               }

               scPlayer.scInventario.equipouMochila = true;
               Destroy(col.gameObject);
               info.gameObject.SetActive(false);

            }

            break;
         }
         case "Exit":
         {
            break;
         }
      }
   }

   public void acaoMsgInfo(Collider col, string tipo)
   {

      switch (tipo)
      {
         case "Enter":
         {
            break;
         }
         case "Stay":
         {
            if (col.transform.tag == "Fuzivel" ||
          col.transform.tag == "Dicas" || col.transform.tag == "ChaveMestra" ||
          col.transform.tag == "Indutor" || col.transform.tag == "Bateria")
            {
               if (scPlayer.scInventario.count >= 4 && scPlayer.scInventario.equipouMochila)
               {
                  info.text = "Inventario Cheio";
                  info.gameObject.SetActive(true);
               }
            }
            else if (col.transform.tag == "Resistor")
            {
               if (scPlayer.scGaveta.aberta)
               {
                  if (scPlayer.scInventario.count >= 4 && scPlayer.scInventario.equipouMochila)
                  {
                     info.text = "Inventario Cheio";
                     info.gameObject.SetActive(true);
                  }
               }
            }



            if (col.transform.tag == "Interruptor1" && scPlayer.scLocalizacao.localizacaoID == 1)
            {
               if (tentou && !scPlayer.scGerador.funcionando)
               {
                  info.text = "Sem energia";
                  info.gameObject.SetActive(true);

               }
            }
            else if (col.transform.tag == "Interruptor2" && scPlayer.scLocalizacao.localizacaoID == 2)
            {
               if (tentou && !scPlayer.scGerador.funcionando)
               {
                  info.text = "Sem energia";
                  info.gameObject.SetActive(true);

               }
            }
            else if (col.transform.tag == "Interruptor3" && scPlayer.scLocalizacao.localizacaoID == 3)
            {
               if (tentou && !scPlayer.scGerador.funcionando)
               {
                  info.text = "Sem energia";
                  info.gameObject.SetActive(true);

               }
            }
            else if (col.transform.tag == "Interruptor4" && scPlayer.scLocalizacao.localizacaoID == 4)
            {
               if (tentou && !scPlayer.scGerador.funcionando)
               {
                  info.text = "Sem energia";
                  info.gameObject.SetActive(true);

               }
            }                    
            else if (col.transform.tag == "Painel" && !scPlayer.scGerador.funcionando)
            {
               if (tentou)
               {
                  if (!scPlayer.scPuzzles.finalizouPuzzle1)
                  {
                     info.text = "Sem energia";
                     info.gameObject.SetActive(true);
                  }
               }
            }
            /*
            else if (col.transform.tag == "Gaveta")
            {
               if (scPlayer.scGaveta.cadeadoGaveta.checkAbriu)
               {
                  info.text = "Pressione E para abrir !";
                  info.gameObject.SetActive(true);
               }
               else
               {
                  info.text = "Abra o cadeado !";
                  info.gameObject.SetActive(true);
               }


            }
            */
            break;
         }
         case "Exit":
         {
            if (
            col.transform.tag == "Lanterna" || col.transform.tag == "Fuzivel" || col.transform.tag == "Resistor" || col.transform.tag == "Mochila" || col.transform.tag == "Valvula"
              || col.transform.tag == "Dicas" || col.transform.tag == "ChaveMestra" || col.transform.tag == "Indutor" || col.transform.tag == "Bateria" || col.transform.tag == "StaticBotaoElevador"
              || col.transform.tag == "Interruptor1" || col.transform.tag == "Interruptor2" || col.transform.tag == "Interruptor3" || col.transform.tag == "Interruptor4"
              || col.transform.tag == "AlavancaPorta1" || col.transform.tag == "AlavancaPorta2" || col.transform.tag == "AlavancaPorta3" || col.transform.tag == "AlavancaPorta4"
              || col.transform.tag == "CaixaEnergiaS1" || col.transform.tag == "CaixaEnergiaS2" || col.transform.tag == "CaixaEnergiaS3" || col.transform.tag == "Painel"
              || col.transform.tag == "Gaveta" || col.transform.tag == "Dicas")
            {
               info.text = "";
               info.gameObject.SetActive(false);

            }
            break;
         }
      }


   }

   public void acaoPortas(Collider col, string tipo)
   {
      switch (tipo)
      {
         case "Enter":
         {
            break;
         }
         case "Stay":
         {
            if (col.transform.tag == "AlavancaPorta2")
            {
               scPlayer.scSons.somAlavanca2.Play();

               if ((scPlayer.scPuzzles.finalizouPuzzle1 && scPlayer.scGerador.funcionando) && scPlayer.scGerador.energia > 10)
               {

                  if (!scPlayer.scPortas.porta2_1.GetBool("Abrir"))
                  {
                     scPlayer.scSons.somPortaFerroAbrindoP2.Play();
                     scPlayer.scPortas.porta2_1.SetBool("Abrir", true);
                     scPlayer.scPortas.porta2_2.SetBool("Abrir", true);

                  }
                  else
                  {
                     scPlayer.scSons.somPortaFerroAbrindoP2.Play();
                     scPlayer.scPortas.porta2_1.SetBool("Abrir", false);
                     scPlayer.scPortas.porta2_2.SetBool("Abrir", false);
                  }
                  scPlayer.scGerador.energia -= 10;
                  StartCoroutine(scPlayer.scGerador.recuperarEnergiaPorta());
               }


            }
            else if (col.transform.tag == "BotaoS3")
            {
               scPlayer.scSons.somAlavanca3.Play();

               Animator alavanca = col.GetComponent<Animator>();

               alavanca.SetTrigger("Active");


               if (scPlayer.scPuzzles.scCaixaEnergia3.scSlot2.itemCerto && scPlayer.scPuzzles.scCaixaEnergia3.scSlot4.itemCerto)
               {

                  if (!scPlayer.scSons.somPortaFerroAbrindoP3b.isPlaying && !scPlayer.scPortas.porta3b_1.GetBool("Abrir"))
                  {
                     scPlayer.scSons.somPortaFerroAbrindoP3b.Play();
                  }

                  scPlayer.scPortas.porta3b_1.SetBool("Abrir", true);

               }

            }

            break;
         }
         case "Exit":
         {
            break;
         }
      }
   }

   public void acaoPuzzles(Collider col, string tipo)
   {
      switch (tipo)
      {
         case "Enter":
         {
            break;
         }
         case "Stay":
         {
            if (col.transform.tag == "CaixaEnergiaS1")
            {
               scPlayer.scPuzzles.puzzleID = 1;

               if (Input.GetKeyDown(KeyCode.E) && !scPlayer.scPuzzles.scCaixaEnergia1.checkAbriu)
               {
                  
                  if (!scPlayer.scSons.somCaixaEnergiaPz1Abrindo.isPlaying)
                  {
                     scPlayer.scSons.somCaixaEnergiaPz1Abrindo.Play();
                  }

                  scPlayer.scPuzzles.scCaixaEnergia1.caixaEnergiaPz1.SetTrigger("Abrir");
                  scPlayer.scPuzzles.scCaixaEnergia1.checkAbriu = true;

                  scPlayer.info.text = "";
                  scPlayer.info.gameObject.SetActive(false);

                  scPlayer.scLuzes.luzInfoCaixaEnergia.enabled = true;

               }
            }
            else if (col.transform.tag == "CaixaEnergiaS2")
            {
               scPlayer.scPuzzles.puzzleID = 2;

               if (Input.GetKeyDown(KeyCode.E))
               {
                  if (!scPlayer.scPuzzles.scCaixaEnergia2.caixaEnergiaPz2_p1.GetBool("Abrir"))
                  {
                     if (!scPlayer.scSons.somCaixaEnergiaPz2Abrindo.isPlaying)
                     {
                        scPlayer.scSons.somCaixaEnergiaPz2Abrindo.Play();
                     }
                     scPlayer.scPuzzles.scCaixaEnergia2.caixaEnergiaPz2_p1.SetBool("Abrir", true);
                     scPlayer.scPuzzles.scCaixaEnergia2.checkAbriu = true;
                  }
                  else
                  {
                     if (!scPlayer.scSons.somCaixaEnergiaPz2Fechando.isPlaying)
                     {
                        scPlayer.scSons.somCaixaEnergiaPz2Fechando.Play();
                     }
                     scPlayer.scPuzzles.scCaixaEnergia2.caixaEnergiaPz2_p1.SetBool("Abrir", false);
                     scPlayer.scPuzzles.scCaixaEnergia2.checkAbriu = false;
                  }


                  scPlayer.info.text = "";
                  scPlayer.info.gameObject.SetActive(false);

                  scPlayer.scLuzes.luzInfoCaixaEnergia.enabled = true;

               }
            }
            else if (col.transform.tag == "CaixaEnergiaS3")
            {
               scPlayer.scPuzzles.puzzleID = 3;


               if (Input.GetKeyDown(KeyCode.E))
               {
                  if (!scPlayer.scPuzzles.scCaixaEnergia3.caixaEnergiaPz3_p1.GetBool("Abrir"))
                  {
                     if (!scPlayer.scSons.somCaixaEnergiaPz2Abrindo.isPlaying)
                     {
                        scPlayer.scSons.somCaixaEnergiaPz2Abrindo.Play();
                     }
                     scPlayer.scPuzzles.scCaixaEnergia3.caixaEnergiaPz3_p1.SetBool("Abrir", true);
                     scPlayer.scPuzzles.scCaixaEnergia3.checkAbriu = true;
                  }
                  else
                  {
                     if (!scPlayer.scSons.somCaixaEnergiaPz2Fechando.isPlaying)
                     {
                        scPlayer.scSons.somCaixaEnergiaPz2Fechando.Play();
                     }
                     scPlayer.scPuzzles.scCaixaEnergia3.caixaEnergiaPz3_p1.SetBool("Abrir", false);
                     scPlayer.scPuzzles.scCaixaEnergia3.checkAbriu = false;
                  }
                  if (!scPlayer.scPuzzles.scCaixaEnergia3.caixaEnergiaPz3_p2.GetBool("Abrir"))
                  {
                     if (!scPlayer.scSons.somCaixaEnergiaPz2Abrindo.isPlaying)
                     {
                        scPlayer.scSons.somCaixaEnergiaPz2Abrindo.Play();
                     }
                     scPlayer.scPuzzles.scCaixaEnergia3.caixaEnergiaPz3_p2.SetBool("Abrir", true);
                  }
                  else
                  {
                     if (!scPlayer.scSons.somCaixaEnergiaPz2Fechando.isPlaying)
                     {
                        scPlayer.scSons.somCaixaEnergiaPz2Fechando.Play();
                     }
                     scPlayer.scPuzzles.scCaixaEnergia3.caixaEnergiaPz3_p2.SetBool("Abrir", false);
                  }

                  scPlayer.info.text = "";
                  scPlayer.info.gameObject.SetActive(false);

                  scPlayer.scLuzes.luzInfoCaixaEnergia.enabled = true;
               }
            }
            else if (col.transform.tag == "CadeadoS1")
            {
               scPlayer.scPuzzles.puzzleID = 1;

               if (Input.GetKeyDown(KeyCode.E) && !scPlayer.scPuzzles.scCadeado.checkAbriu && scPlayer.scPuzzles.finalizouPuzzle4)
               {
                  scPlayer.scPuzzles.scCadeado.cadeado.SetTrigger("Abrir");
                  scPlayer.scPuzzles.scCadeado.checkAbriu = true;

                  scPlayer.info.text = "";
                  scPlayer.info.gameObject.SetActive(false);

               }
            }
            else if (col.transform.tag == "CadeadoS4")
            {
               scPlayer.scPuzzles.puzzleID = 4;

               if (Input.GetKeyDown(KeyCode.E) && !scPlayer.scPuzzles.scCadeado.checkAbriu && scPlayer.scPuzzles.finalizouPuzzle4)
               {
                  scPlayer.scPuzzles.scCadeado.cadeado.SetTrigger("Abrir");
                  scPlayer.scPuzzles.scCadeado.checkAbriu = true;

                  scPlayer.info.text = "";
                  scPlayer.info.gameObject.SetActive(false);

               }
            }
            else if (col.transform.tag == "Valvula")
            {
               scPlayer.scPuzzles.puzzleID = 4.2f;

               if (Input.GetKeyDown(KeyCode.E) && !scPlayer.scPuzzles.scValvula.checkAbriu)
               {
                  if (!scPlayer.scSons.somValvulaGirando.isPlaying)
                  {
                     scPlayer.scSons.somValvulaGirando.Play();
                  }
                  scPlayer.scPuzzles.scValvula.rodando.SetTrigger("Active");
                  scPlayer.scPuzzles.scValvula.checkAbriu = true;

                  scPlayer.info.text = "";
                  scPlayer.info.gameObject.SetActive(false);

               }
            }
            else if (col.transform.tag == "StaticBotaoElevador" && scPlayer.scPuzzles.botaoElevador.active)
            {
               scPlayer.scPuzzles.puzzleID = 2.1f;

               if (Input.GetKeyDown(KeyCode.E) && (scPlayer.scPuzzles.finalizouPuzzle1 && scPlayer.scPuzzles.finalizouPuzzle2 && scPlayer.scPuzzles.finalizouPuzzle3 && scPlayer.scPuzzles.finalizouPuzzle4))
               {
                  if (!scPlayer.scSons.somElevadorPortaAbrindo.isPlaying)
                  {
                     scPlayer.scSons.somElevadorPortaAbrindo.Play();
                  }

                  col.GetComponent<Animator>().SetTrigger("Active");

                  scPlayer.scPortas.portaElevador_1.SetBool("Abrir", true);
                  scPlayer.scPortas.portaElevador_2.SetBool("Abrir", true);

                  scPlayer.info.text = "";
                  scPlayer.info.gameObject.SetActive(false);

               }
               else
               {
                  scPlayer.info.text = "Sem energia";
                  scPlayer.info.gameObject.SetActive(true);
               }
            }




            break;
         }
         case "Exit":
         {
            break;
         }
      }
   }

   public void acaoAnimacoes(Collider col, string tipo)
   {
      switch (tipo)
      {
         case "Enter":
         {
            break;
         }
         case "Stay":
         {
            if (col.transform.tag == "AlavancaPorta2")
            {

               Animator botao = col.GetComponent<Animator>();

               botao.SetTrigger("Active");
            }
            else if (col.transform.tag == "Painel" && (!tentou && !scPlayer.scGerador.funcionando))
            {
               scPlayer.scSons.somBotaoGerador.Play();

               Animator botao = col.GetComponent<Animator>();

               botao.SetTrigger("Active");
            }
            else if (col.transform.tag == "Interruptor1" || col.transform.tag == "Interruptor2" || col.transform.tag == "Interruptor3" || col.transform.tag == "BotaoS3")
            {
               Animator botao = col.GetComponent<Animator>();

               if (scPlayer.scGerador.funcionando)
               {
                  botao.SetTrigger("Active");
               }
            }
            else if (col.transform.tag == "StaticBotaoFinish")
            {

               if (((Input.GetKeyDown(KeyCode.E) && scPlayer.scPuzzles.finalizouPuzzle2) && scPlayer.scLocalizacao.localizacaoID == 5) && scPlayer.scPortas.portaElevador_1.GetBool("Abrir"))
               {
                  col.GetComponent<Animator>().SetTrigger("Action");

                  if (!scPlayer.scSons.somElevadorPortaFechando.isPlaying)
                  {
                     scPlayer.scSons.somElevadorPortaFechando.Play();
                  }

                  StartCoroutine(scPlayer.scElevador.iniciarElevador());
                  scPlayer.scPortas.portaElevador_1.SetBool("Abrir", false);
                  scPlayer.scPortas.portaElevador_2.SetBool("Abrir", false);

                  scPlayer.info.text = "";
                  scPlayer.info.gameObject.SetActive(false);

               }
            }
            /*
            if (col.transform.tag == "Gaveta")
            {
               if (scPlayer.scGaveta.podeAbrir)
               {
                  bool boolean;
                  boolean = scPlayer.scGaveta.animGaveta.GetBool("Abrir");
                  Animator gaveta = scPlayer.scGaveta.GetComponent<Animator>();
                  gaveta.SetBool("Abrir", boolean);
                  
                  if (!scPlayer.scGaveta.animGaveta.GetBool("Abrir"))
                  {
                     scPlayer.scGaveta.aberta = true;
                     scPlayer.scGaveta.animGaveta.SetBool("Abrir", true);

                     scPlayer.scSons.somGavetaAbrindo.Play();

                  }
                  else
                  {
                     scPlayer.scGaveta.aberta = false;
                     scPlayer.scGaveta.animGaveta.SetBool("Abrir", false);

                     scPlayer.scSons.somGavetaFechando.Play();

                  }
                  
               }
             
            }
            */
            break;
         }
         case "Exit":
         {
            break;
         }
      }
   }

   public void acaoInterruptores(Collider col, string tipo)
   {
      switch (tipo)
      {
         case "Enter":
         {
            break;
         }
         case "Stay":
         {
            if (col.transform.tag == "Interruptor1")
            {
               scPlayer.scSons.somInterruptor1.Play();
            }
            else if (col.transform.tag == "Interruptor2")
            {
               scPlayer.scSons.somInterruptor2.Play();
            }
            else if (col.transform.tag == "Interruptor3")
            {
               scPlayer.scSons.somInterruptor3.Play();
            }

            if (col.transform.tag == "Interruptor1" || col.transform.tag == "AlavancaPorta2" || col.transform.tag == "Painel")
            {
               if (!scPlayer.scGerador.funcionando && !scPlayer.scPuzzles.finalizouPuzzle1)
               {
                  tentou = true;
               }
            }
            else if (col.transform.tag == "AlavancaPorta3")
            {
               if (!scPlayer.scGerador.funcionando && !scPlayer.scPuzzles.finalizouPuzzle1)
               {
                  tentou = true;
               }
            }
            else if (col.transform.tag == "BotaoS3")
            {
               if (!scPlayer.scPuzzles.finalizouPuzzle3)
               {
                  tentou = true;
               }
            }

            if (col.transform.tag == "Interruptor1" || col.transform.tag == "Interruptor2" || col.transform.tag == "Interruptor3")
            {

               if (scPlayer.scGerador.funcionando)
               {
                  switch (scPlayer.scLocalizacao.localizacaoID)
                  {
                     case 1:
                     {
                        if (!scPlayer.scGerador.scPiscarLuzSala1.interruptor)
                        {
                           scPlayer.scGerador.scPiscarLuzSala1.interruptor = true;
                           scPlayer.scLuzes.qntAcesa++;


                           scPlayer.scGerador.energia -= 20;

                        }
                        else
                        {
                           scPlayer.scGerador.scPiscarLuzSala1.interruptor = false;
                           scPlayer.scLuzes.qntAcesa--;


                           scPlayer.scGerador.energia += 20;

                        }

                        break;
                     }
                     case 2:
                     {
                        if (!scPlayer.scGerador.scPiscarLuzSala2.interruptor)
                        {
                           scPlayer.scGerador.scPiscarLuzSala2.interruptor = true;
                           scPlayer.scLuzes.qntAcesa++;


                           scPlayer.scGerador.energia -= 30;

                        }
                        else
                        {
                           scPlayer.scGerador.scPiscarLuzSala2.interruptor = false;
                           scPlayer.scLuzes.qntAcesa--;


                           scPlayer.scGerador.energia += 30;

                        }
                        break;
                     }
                     case 3:
                     {
                        if (!scPlayer.scGerador.scPiscarLuzSala3.interruptor)
                        {
                           scPlayer.scGerador.scPiscarLuzSala3.interruptor = true;
                           scPlayer.scLuzes.qntAcesa++;


                           scPlayer.scGerador.energia -= 40;

                        }
                        else
                        {
                           scPlayer.scGerador.scPiscarLuzSala3.interruptor = false;
                           scPlayer.scLuzes.qntAcesa--;

                           scPlayer.scGerador.energia += 40;

                        }
                        break;
                     }


                  }
               }

               break;

            }
            break;
         }
         case "Exit":
         {
            break;
         }
      }
   }

   public void acaoGerador(Collider col)
   {
      if (col.transform.tag == "Painel")
      {
         if (!scPlayer.scGerador.funcionando)
         {
            scPlayer.scGerador.tentouLigar = true;
            tentou = true;


         }

      }
   }


   private void OnTriggerEnter(Collider col)
   {
      if (col.transform.tag == "Puzzles" ||
         (col.transform.tag == "CadeadoS1" && !scPlayer.scPuzzles.cadeadoS1.GetComponent<Cadeado>().checkAbriu) ||
         (col.transform.tag == "CadeadoS4" && !scPlayer.scPuzzles.cadeadoS4.GetComponent<Cadeado>().checkAbriu) ||
         (col.transform.tag == "Valvula" && !scPlayer.scPuzzles.scValvula.checkAbriu)
         )
      {
         col.gameObject.GetComponent<Outline>().enabled = true;
         nomeSlot = col.name;

      }
      if (col.transform.tag == "Puzzles")
      {
         scSlots = col.GetComponent<Slots>();
      }

      if (col.tag.Equals("Fuzivel") || col.tag.Equals("Mochila") || col.tag.Equals("Bateria") || col.tag.Equals("Dicas") || col.tag.Equals("CaixaEnergiaS1") || col.tag.Equals("Lanterna") || col.tag.Equals("Painel") || col.tag.Equals("AlavancaPorta2") || col.tag.Equals("CadeadoS1"))
      {
         nomeItem = col.tag + "";

         if (scPlayer.scLocalizacao.localizacaoID == 1 && !scPlayer.scTutorial.concluiu)
         {
            scPlayer.scTutorial.ativarTutorial();
         }
      }

      if (col.tag.Equals("CaixaEnergiaS1") || col.tag.Equals("Painel") || col.tag.Equals("AlavancaPorta2") || col.tag.Equals("CadeadoS1"))
      {
         if (!scPlayer.scTutorial.concluiu)
         {
            scPlayer.scTutorial.ativarTutorial();
         }
        
      }
   }





   private void OnTriggerExit(Collider col)
   {
      if (col.transform.tag == "Puzzles" || col.transform.tag == "CadeadoS1" || col.transform.tag == "CadeadoS4" || col.transform.tag == "Valvula")
      {
         col.gameObject.GetComponent<Outline>().enabled = false;
         nomeSlot = "";
      }

      acaoMsgInfo(col, "Exit");

      if (col.tag.Equals("Fuzivel") || col.tag.Equals("Mochila") || col.tag.Equals("Bateria") || col.tag.Equals("Dicas") || col.tag.Equals("CaixaEnergiaS1") || col.tag.Equals("Lanterna"))
      {
         nomeItem = "";

         if (scPlayer.scLocalizacao.localizacaoID == 1 && !scPlayer.scTutorial.concluiu)
         {
            scPlayer.scTutorial.desativarTutorial();
         }
      }

      if (col.tag.Equals("Mesa") || col.tag.Equals("CaixaEnergiaS1") || col.tag.Equals("Fuzivel") || col.tag.Equals("Painel") || col.tag.Equals("AlavancaPorta2") || col.tag.Equals("CadeadoS1"))
      {
         scPlayer.scTutorial.desativarTutorial();
      }
   }
}
