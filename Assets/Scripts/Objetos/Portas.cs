using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{
   private Personagem scPlayer;

   public GameObject porta1;
   public Animator porta1_1;
   public Animator porta1_2;

   public GameObject porta2;
   public Animator porta2_1;
   public Animator porta2_2;

   public GameObject porta3;
   public Animator porta3_1;
   public Animator porta3_2;

   public GameObject porta3b;
   public Animator porta3b_1;

   public GameObject locSalinha3;

   public Animator portaElevador_1;
   public Animator portaElevador_2;

   void Start()
   {
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();

      porta3_1.SetBool("Abrir", false);
      porta3_2.SetBool("Abrir", false);

      porta3b_1.SetBool("Abrir", false);

   }
   private void Update()
   {

      /*
      if ((scPlayer.scPuzzles.puzzleID == 3 && scPlayer.scPuzzles.startEvent) && (scPlayer.scLocalizacao.transform.position.x > locSalinha3.transform.position.x && scPlayer.scLocalizacao.transform.position.z > locSalinha3.transform.position.z))
      {
         porta3b_1.SetBool("Abrir", false);
      }
      */
   }

}
