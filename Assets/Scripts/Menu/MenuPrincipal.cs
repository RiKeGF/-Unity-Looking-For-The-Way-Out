using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
   public static bool zerou;

   public AudioSource[] audio = new AudioSource[2];
   public StreamVideoMenu stream;

   public Animator fade;

   // Use this for initialization
   void Start()
   {
      if (zerou)
      {
         Cursor.lockState = CursorLockMode.Confined;
         Cursor.visible = false;
      }
      else
      {
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
      }
      
   }



   private void Update()
   {
      if (zerou)
      {
         creditos();
         zerou = false;
      }

      
   }

   private void FixedUpdate()
   {
      

   }


   public void iniciarJogo()
   {
      StartCoroutine(startGame());
   }

   public void fecharJogo()
   {
      Application.Quit();
   }

   public void creditos()
   {
      fade.SetTrigger("Escurece");     
      StartCoroutine(stream.PlayVideo3());
      stream.creditos = true;
   }

   IEnumerator startGame()
   {
      fade.SetTrigger("Escurece");
      yield return new WaitForSeconds (2f);
      SceneManager.LoadScene("Jogo");
   }

}
