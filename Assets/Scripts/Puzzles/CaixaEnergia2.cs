using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaEnergia2 : MonoBehaviour
{
   public Animator caixaEnergiaPz2_p1;

   public bool checkAbriu;
   public bool ocupada;

   private Personagem scPlayer;
   private GameObject player;

   public ParticleSystem faiscas;
   public ParticleSystem faiscas2;

   private float count = 0.3f;
   private bool status;
   public bool startFaiscas;

   // Start is called before the first frame update
   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player");

      scPlayer = player.GetComponent<Personagem>();

      faiscas.Clear();
      faiscas.Stop();
      faiscas2.Clear();
      faiscas2.Stop();

   }

   private void Update()
   {
      if (scPlayer.scAcao.tentou && !scPlayer.scPuzzles.finalizouPuzzle2)
      {
         startFaiscas = true;
      }

      if (startFaiscas && !scPlayer.scPuzzles.finalizouPuzzle2)
      {
         executarFaiscas();
      }
   }

   public void executarFaiscas()
   {
      count -= Time.deltaTime;

      if (count <= 0)
      {
         status = !status;
         if (status)
         {
            faiscas.Play();
            faiscas2.Play();
         }
         else
         {
            faiscas.Stop();
            faiscas2.Stop();
            count = 0.3f;
            startFaiscas = false;
         }

         count = 0.3f;
      }

   }

   private void OnTriggerStay(Collider col)
   {


      if (col.tag == "Fuzivel")
      {
         scPlayer.scPuzzles.finalizouPuzzle2 = true;
      }
      if (col.transform.tag == "Fuzivel" || col.transform.tag == "Resistor" || col.transform.tag == "Dicas" || col.transform.tag == "ChaveMestra" || col.transform.tag == "Indutor")
      {
         ocupada = true;
      }
      else
      {
        ocupada = false;
      }


   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Fuzivel")
      {
         scPlayer.scPuzzles.finalizouPuzzle2 = false;
      }
   }
}





