using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
   public Personagem scPlayer;
   public bool pause;
   public GameObject pauseUI;


   private void Start()
   {
      Time.timeScale = 1;
      pause = false;
      pauseUI.SetActive(false);
   }

   public void PauseOn()
   {
      pauseUI.SetActive(true);

      Cursor.lockState = CursorLockMode.None;
      Time.timeScale = 0;
      pause = true;
   }

   public void PauseOff()
   {

      pauseUI.SetActive(false);

      Cursor.lockState = CursorLockMode.Confined;
      Time.timeScale = 1;
      pause = false;
      scPlayer.scHUD.imgTecladoHUD.enabled = false;


   }

   public void Comandos()
   {
      if (scPlayer.scHUD.imgTecladoHUD.enabled)
      {
         scPlayer.scHUD.imgTecladoHUD.enabled = false;
      }
      else
      {
         scPlayer.scHUD.imgTecladoHUD.enabled = true;
      }
      
   }

   void Update()
   {
      if (!scPlayer.scCheats.chatAberto)
      {
         if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
         {
            if (!pause)
            {
               Cursor.visible = true;
               PauseOn();
            }
            else
            {
               Cursor.visible = false;
               PauseOff();
            }
         }
      }

   }

   public void LoadMenu()
   {
      Time.timeScale = 1;
      SceneManager.LoadScene("Menu");
   }

   public void Sair()
   {
      Application.Quit();
   }

}
