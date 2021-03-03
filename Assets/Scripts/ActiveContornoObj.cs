using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveContornoObj : MonoBehaviour
{
   private Personagem scPlayer;

   public string tipoObj;

   public float distance;
   public GameObject player;
   public Outline outline;
   private GameObject[] desativarOutlinePuzzles;
   private GameObject desativarOutlineCadeadosS1;
   private GameObject desativarOutlineCadeadosS4;
   private GameObject desativarOutlineValvula;

   public bool estaNoPuzzle;

   // Start is called before the first frame update
   void Start()
   {
      distance = 0;
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
      player = GameObject.FindGameObjectWithTag("Player");
      outline = this.GetComponent<Outline>();

      desativarOutlinePuzzles = GameObject.FindGameObjectsWithTag("Puzzles");
      desativarOutlineCadeadosS1 = GameObject.FindGameObjectWithTag("CadeadoS1");
      desativarOutlineCadeadosS4 = GameObject.FindGameObjectWithTag("CadeadoS4");
      desativarOutlineValvula = GameObject.FindGameObjectWithTag("Valvula");

      for (int i = 0; i < desativarOutlinePuzzles.Length; i++)
      {
         if (desativarOutlinePuzzles[i].GetComponent<Outline>() != null)
         {
            desativarOutlinePuzzles[i].GetComponent<Outline>().enabled = false;
         }
         
      }
      desativarOutlineCadeadosS1.GetComponent<Outline>().enabled = false;
      desativarOutlineCadeadosS4.GetComponent<Outline>().enabled = false;
      desativarOutlineValvula.GetComponent<Outline>().enabled = false;
   }

   // Update is called once per frame
   void Update()
   {

      if (tipoObj.Equals("Itens"))
      {
         contornoItens();
      }

   }


   public void contornoItens()
   {
      distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);

      if (distance < 3)
      {
         outline.enabled = true;

      }
      else
      {
         outline.enabled = false;

      }
   }
   /*
   public void contornoCadeadoS1()
   {
      distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);

      if (distance < 3 && (!scPlayer.scPuzzles.cadeadoS1.GetComponent<Cadeado>().checkAbriu))
      {

         outline.enabled = true;

      }
      else
      {
         outline.enabled = false;

      }
   }
   public void contornoCadeadoS4()
   {
      distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);

      if (distance < 3 && (!scPlayer.scPuzzles.cadeadoS4.GetComponent<Cadeado>().checkAbriu))
      {

         outline.enabled = true;

      }
      else
      {
         outline.enabled = false;

      }
   }
   */
   public void OnTriggerStay(Collider col)
   {
      if (col.transform.tag == "Puzzles" || col.transform.tag == "Gaveta")
      {
         estaNoPuzzle = true;
      }

   }
   public void OnTriggerExit(Collider col)
   {
      if (col.transform.tag == "Puzzles")
      {
         estaNoPuzzle = false;
      }
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Chao" && this.GetComponent<Rigidbody>().constraints != RigidbodyConstraints.FreezeAll)
      {
         if (!this.GetComponent<AudioSource>().isPlaying)
         {
            this.GetComponent<AudioSource>().Play();
         }
       
      }
   }
}
