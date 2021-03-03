using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaEnergia3 : MonoBehaviour
{
   public Animator caixaEnergiaPz3_p1;
   public Animator caixaEnergiaPz3_p2;
   public bool checkAbriu;
   public bool ocupada;

   private Personagem scPlayer;
   private GameObject player;

   public ParticleSystem faiscas;
   private float count = 0.3f;
   private bool status;
   public bool startFaiscas;

   public Slots scSlot2;
   public Slots scSlot4;

   // Start is called before the first frame update
   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player");

      scPlayer = player.GetComponent<Personagem>();

      faiscas.Clear();
      faiscas.Stop();

   }

   private void Update()
   {

      if (scPlayer.scAcao.tentou && !scPlayer.scPuzzles.finalizouPuzzle3)
      {
         startFaiscas = true;
      }
      if (startFaiscas)
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
         }
         else
         {
            faiscas.Stop();
            count = 0.3f;
            startFaiscas = false;
         }

         count = 0.3f;
      }

   }





   private void OnTriggerStay(Collider col)
   {

      if (col.tag == "Indutor")
      {
         scPlayer.scPuzzles.finalizouPuzzle3 = true;

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
      if (other.tag == "Indutor")
      {
         scPlayer.scPuzzles.finalizouPuzzle3 = false;
      }
   }
}





