using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
   public Personagem scPlayer;

   public float puzzleAreaID;

   public bool puzzle;
   public float puzzleID;
   public string buttonName;

   public bool finalizouPuzzle1;
   public bool finalizouPuzzle2;
   public bool finalizouPuzzle3;
   public bool finalizouPuzzle4;
   public bool finalizouPuzzleFinal;

   public bool retirouChave;

   public Material corSinalPz1;
   public Material corSinalPz2;
   public Material corSinalPz3;
   public Material corSinalPz4;

   public Material materialSinalPz1;
   public Material materialSinalPz2;
   public Material materialSinalPz3;
   public Material materialSinalPz4;

   public Light[] luzSinalPz1;
   public Light[] luzSinalPz2;
   public Light[] luzSinalPz3;
   public Light[] luzSinalPz4;

   public GameObject[] objSinalPz1;
   public GameObject[] objSinalPz2;
   public GameObject[] objSinalPz3;
   public GameObject[] objSinalPz4;

   public CaixaEnergia1 scCaixaEnergia1;
   public CaixaEnergia2 scCaixaEnergia2;
   public CaixaEnergia3 scCaixaEnergia3;
   public Cadeado scCadeado;
   public Temperatura scTemperatura;
   public Valvula scValvula;

   public GameObject spawnObjPuzzle1_1;
   public GameObject spawnObjPuzzle1_2;
   public GameObject spawnObjPuzzle1_3;

   public GameObject spawnObjPuzzle2_1;
   public GameObject spawnObjPuzzle2_2;

   public GameObject spawnObjPuzzle3_1;
   public GameObject spawnObjPuzzle3_2;
   public GameObject spawnObjPuzzle3_3;
   public GameObject spawnObjPuzzle3_4;

   public GameObject spawnObjPuzzle4;

   public GameObject spawnObjPuzzle5;

   public GameObject itensSlotsPz1_s1;
   public GameObject itensSlotsPz1_s2;
   public GameObject itensSlotsPz1_cadeado;
   public GameObject itensSlotsPz2_s1;
   public GameObject itensSlotsPz2_s2;
   public GameObject itensSlotsPz3_s1;
   public GameObject itensSlotsPz3_s2;
   public GameObject itensSlotsPz3_s3;
   public GameObject itensSlotsPz3_s4;
   public GameObject itensSlotsPz4;
   public GameObject itensSlotsPz5;

   public GameObject cadeadoS1;
   public GameObject cadeadoS4;
   public GameObject valvula;

   public GameObject puzzleArea1_3;
   public GameObject puzzleArea4;

   public GameObject telaPz2;
   public Material acessoNegado;
   public Material acessoPermitido;
   public GameObject botaoElevador;

   public bool startEvent;

   private void Start()
   {
      botaoElevador.SetActive(false);
   }
   private void Update()
   {
      verificarPuzzlesFinalizados();
      verificarSinalPuzzles();
   }

   void verificarPuzzlesFinalizados()
   {
      if (spawnObjPuzzle1_1.GetComponent<Slots>().itemCerto && spawnObjPuzzle1_2.GetComponent<Slots>().itemCerto)
      {
         finalizouPuzzle1 = true;
      }
      else
      {
         finalizouPuzzle1 = false;
      }

      
      if (spawnObjPuzzle2_2.GetComponent<Slots>().itemCerto)
      {
         finalizouPuzzle2 = true;
         telaPz2.GetComponent<MeshRenderer>().material = acessoPermitido;
      }
      else
      {
         finalizouPuzzle2 = false;
         telaPz2.GetComponent<MeshRenderer>().material = acessoNegado;
      }
      

      if (spawnObjPuzzle3_1.GetComponent<Slots>().itemCerto)
      {
         finalizouPuzzle3 = true;
         scPlayer.scPuzzles.startEvent = false;
         scPlayer.scPuzzles.scTemperatura.desativarArCondicionado();
      }
      else if (retirouChave && !spawnObjPuzzle3_1.GetComponent<Slots>().itemCerto)
      {
         finalizouPuzzle3 = false;
         scPlayer.scPuzzles.startEvent = true;

      }

      if (scPlayer.scPuzzles.scValvula.checkAbriu)
      {
         finalizouPuzzle4 = true;
      }
      else
      {
         finalizouPuzzle4 = false;
      }
   }

   void verificarSinalPuzzles()
   {
      if (finalizouPuzzle1 && scPlayer.scGerador.funcionando)
      {
         objSinalPz1[0].GetComponent<MeshRenderer>().material = materialSinalPz1;
         objSinalPz1[1].GetComponent<MeshRenderer>().material = materialSinalPz1;
         luzSinalPz1[0].enabled = true;
         luzSinalPz1[1].enabled = true;
      }
      else
      {
         objSinalPz1[0].GetComponent<MeshRenderer>().material = corSinalPz1;
         objSinalPz1[1].GetComponent<MeshRenderer>().material = corSinalPz1;
         luzSinalPz1[0].enabled = false;
         luzSinalPz1[1].enabled = false;
      }

      if (finalizouPuzzle2 && scPlayer.scGerador.funcionando)
      {
         objSinalPz2[0].GetComponent<MeshRenderer>().material = materialSinalPz2;
         objSinalPz2[1].GetComponent<MeshRenderer>().material = materialSinalPz2;
         luzSinalPz2[0].enabled = true;
         luzSinalPz2[1].enabled = true;
      }
      else
      {
         objSinalPz2[0].GetComponent<MeshRenderer>().material = corSinalPz2;
         objSinalPz2[1].GetComponent<MeshRenderer>().material = corSinalPz2;
         luzSinalPz2[0].enabled = false;
         luzSinalPz2[1].enabled = false;
      }

      if (finalizouPuzzle3 && scPlayer.scGerador.funcionando)
      {
         objSinalPz3[0].GetComponent<MeshRenderer>().material = materialSinalPz3;
         objSinalPz3[1].GetComponent<MeshRenderer>().material = materialSinalPz3;
         luzSinalPz3[0].enabled = true;
         luzSinalPz3[1].enabled = true;
      }
      else
      {
         objSinalPz3[0].GetComponent<MeshRenderer>().material = corSinalPz3;
         objSinalPz3[1].GetComponent<MeshRenderer>().material = corSinalPz3;
         luzSinalPz3[0].enabled = false;
         luzSinalPz3[1].enabled = false;
      }

      if (finalizouPuzzle4 && scPlayer.scGerador.funcionando)
      {
         objSinalPz4[0].GetComponent<MeshRenderer>().material = materialSinalPz4;
         objSinalPz4[1].GetComponent<MeshRenderer>().material = materialSinalPz4;
         luzSinalPz4[0].enabled = true;
         luzSinalPz4[1].enabled = true;
      }
      else
      {
         objSinalPz4[0].GetComponent<MeshRenderer>().material = corSinalPz4;
         objSinalPz4[1].GetComponent<MeshRenderer>().material = corSinalPz4;
         luzSinalPz4[0].enabled = false;
         luzSinalPz4[1].enabled = false;
      }

   }


   private void OnTriggerEnter(Collider col)
   {

   }

   private void OnTriggerStay(Collider col)
   {

      if (col.transform.tag == "PuzzleArea")
      {
         IDPuzzleAreas idPuzzleArea = col.gameObject.GetComponent<IDPuzzleAreas>();
         puzzleID = idPuzzleArea.ID;
         puzzleAreaID = idPuzzleArea.ID;
         puzzle = true;

         //scPlayer.scInventario.viewInfoHUD.SetActive(false);
         //scPlayer.scInventario.bgInfoHUD.SetActive(false);
      }

      if ((col.transform.tag == "StartEvent" && !finalizouPuzzle3) && retirouChave)
      {
         scPlayer.scPortas.porta3_1.SetBool("Abrir", false);
         scPlayer.scPortas.porta3_2.SetBool("Abrir", false);

         startEvent = true;
         Destroy(col.gameObject);
      }
   }


   private void OnTriggerExit(Collider col)
   {

      if (col.transform.tag == "PuzzleArea")
      {
         puzzleID = 0;
         puzzle = false;
         // scPlayer.scInventario.viewInfoHUD.SetActive(true);
         //scPlayer.scInventario.bgInfoHUD.SetActive(true);


      }

   }
}
