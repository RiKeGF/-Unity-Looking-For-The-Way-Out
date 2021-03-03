using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadeado : MonoBehaviour
{
   public Personagem scPlayer;
   public int ID;

   public Animator cadeado;
   public Animator animCorrenteP1;
   public Animator animCorrenteP2;
   public GameObject correnteP1;
   public GameObject correnteP2;

   public BoxCollider triggerCollider;
   public BoxCollider collider;

   public bool checkAbriu;

   void Start()
    {
      collider.enabled = false;
    }


    void Update()
    {
      if (scPlayer.scInventario.pegouChaveMestra && !checkAbriu)
      {
         scPlayer.scPuzzles.finalizouPuzzle4 = false;
      }
   }


   private void OnTriggerStay(Collider col)
   {
      if (col.tag == "ChaveMestra" && ID == 1)
      {
         if (!scPlayer.scSons.somCadeado1Abrindo.isPlaying)
         {
            scPlayer.scSons.somCadeado1Abrindo.Play();
         }
        
         scPlayer.scGaveta.animGaveta.SetBool("Abrir", true);

         checkAbriu = true;
         scPlayer.scGaveta.podeAbrir = true;
         this.GetComponent<Rigidbody>().useGravity = true;
         this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
         triggerCollider.enabled = false;
         collider.enabled = true;
         col.GetComponent<Rigidbody>().useGravity = true;
         col.GetComponent<BoxCollider>().isTrigger = false;
         col.transform.SetParent(scPlayer.scInventario.CenItens.transform);
         scPlayer.scGaveta.aberta = true;

      }
      else if (col.tag == "ChaveMestra" && ID == 4)
      {
         animCorrenteP1.SetTrigger("Abrir");
         animCorrenteP2.SetTrigger("Abrir");

         if (!scPlayer.scSons.somCadeado4Abrindo.isPlaying)
         {
            scPlayer.scSons.somCadeado4Abrindo.Play();
         }
         if (!scPlayer.scSons.somPortaFerroAbrindoP1.isPlaying)
         {
            scPlayer.scSons.somPortaFerroAbrindoP1.Play();
         }
         

         checkAbriu = true;
         scPlayer.scPuzzles.finalizouPuzzle4 = true;       

         correnteP1.transform.SetParent(scPlayer.scPortas.porta1_1.transform);
         correnteP2.transform.SetParent(scPlayer.scPortas.porta1_2.transform);

         this.GetComponent<Rigidbody>().useGravity = true;
         this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
         triggerCollider.enabled = false;
         collider.enabled = true;
         col.GetComponent<Rigidbody>().useGravity = true;
         col.GetComponent<BoxCollider>().isTrigger = false;
         col.transform.SetParent(scPlayer.scInventario.CenItens.transform);
         
         scPlayer.scPortas.porta1_1.SetBool("Abrir", true);
         scPlayer.scPortas.porta1_2.SetBool("Abrir", true);

      }

   }
}
