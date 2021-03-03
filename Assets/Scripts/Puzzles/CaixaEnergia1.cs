using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaEnergia1 : MonoBehaviour
{
   public Animator caixaEnergiaPz1;

   public bool checkAbriu;

   private Personagem scPlayer;
   private GameObject player;

   public ParticleSystem faiscas;
   private float count = 0.8f;
   private bool status;
   public bool startFaiscas;

   // Start is called before the first frame update
   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player");

      scPlayer = player.GetComponent<Personagem>();

      faiscas.Clear();
      faiscas.Stop();

      for (int i = 0; i < scPlayer.scLuzes.lampadas.Length; i++)
      {
         scPlayer.scLuzes.lampadas[i].GetComponent<MeshRenderer>().material = scPlayer.scLuzes.corLampadaApagada;
      }
   }

   private void Update()
   {
      if (scPlayer.scAcao.tentou && !scPlayer.scPuzzles.finalizouPuzzle1)
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
            if (checkAbriu)
            {
               faiscas.Play();
            }
            
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

   private void OnTriggerEnter(Collider col)
   {
      if (col.tag == "Fuzivel")
      {
         scPlayer.scGerador.energia = 100;
      }
   }


   private void OnTriggerStay(Collider col)
   {
      

   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Fuzivel")
      {
         scPlayer.scPuzzles.finalizouPuzzle1 = false;
      }
   }
}





