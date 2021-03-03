using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Elevador : MonoBehaviour
{
   public Personagem scPlayer;

   public IEnumerator iniciarElevador()
   {
      while (true)
      {
         yield return new WaitForSeconds(4f);

         if (!scPlayer.scSons.somElevador.isPlaying)
         {
            scPlayer.scSons.somElevador.Play();
         }
         break;
      }

      yield return new WaitForSeconds(2f);

      scPlayer.scHUD.fade.gameObject.SetActive(true);
      scPlayer.scHUD.fade.SetTrigger("Escurece");

      yield return new WaitForSeconds(4f);

      MenuPrincipal.zerou = true;

      SceneManager.LoadScene("Menu");

      StopCoroutine(iniciarElevador());
   }
}
