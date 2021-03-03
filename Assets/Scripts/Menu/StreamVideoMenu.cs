using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class StreamVideoMenu : MonoBehaviour
{
   public RawImage rawImage;
   public VideoPlayer[] videoPlayer;

   public Animator btnIniciar;
   public Animator btnCreditos;
   public Animator btnSair;

   public MenuPrincipal menu;

   public AudioSource audioSource;

   public GameObject buttons;
   public bool creditos;
   public bool change;

   void Start()
   {

      rawImage.color = new Color(0, 0, 0);
      StartCoroutine(PlayVideo1());

   }

   private void Update()
   {

      if (videoPlayer[0].isPaused && !change)
      {
         StartCoroutine(PlayVideo2());
         change = true;
      }

      if (Input.GetKeyDown(KeyCode.Space) && videoPlayer[0].isPlaying)
      {
         StartCoroutine(skipVideo1());

      }
      else if (Input.GetKeyDown(KeyCode.Space) && videoPlayer[2].isPlaying)
      {
         StopCoroutine(PlayVideo3());
         videoPlayer[2].Stop();
         SceneManager.LoadScene("Menu");
      }

      if (videoPlayer[2].isPaused && creditos)
      {
         SceneManager.LoadScene("Menu");
      }
   }

   //entrada
   public IEnumerator PlayVideo1()
   {
      videoPlayer[0].Prepare();

      while (!videoPlayer[0].isPrepared)
      {
         yield return new WaitForSeconds(1);
         break;
      }
      rawImage.color = new Color(255, 255, 255);
      rawImage.texture = videoPlayer[0].texture;
      videoPlayer[0].Play();
      audioSource.Play();

   }


   //loop
   public IEnumerator PlayVideo2()
   {
      videoPlayer[1].Prepare();

      while (!videoPlayer[1].isPrepared)
      {
         yield return new WaitForSeconds(1);
         break;
      }

      rawImage.color = new Color(255, 255, 255);
      rawImage.texture = videoPlayer[1].texture;
      videoPlayer[1].Play();
      //audioSource.Play();
      yield return new WaitForSeconds(1);
      StopCoroutine(PlayVideo1());

   }

   //creditos

   public IEnumerator PlayVideo3()
   {
      videoPlayer[2].Prepare();

      while (!videoPlayer[2].isPrepared)
      {
         yield return new WaitForSeconds(1);
         break;
      }
      

      menu.fade.SetTrigger("Clareia");

      rawImage.color = new Color(255, 255, 255);
      rawImage.texture = videoPlayer[2].texture;

      videoPlayer[2].Play();

      btnIniciar.gameObject.SetActive(false);
      btnCreditos.gameObject.SetActive(false);
      btnSair.gameObject.SetActive(false);   

      yield return new WaitForSeconds(1);

      videoPlayer[0].Stop();
      videoPlayer[1].Stop();
      audioSource.Stop();

      StopCoroutine(PlayVideo1());
      StopCoroutine(PlayVideo2());
      StopCoroutine(PlayVideo3());
   }

   public IEnumerator skipVideo1()
   {
      StartCoroutine(PlayVideo2());
      btnIniciar.speed = 10;
      btnCreditos.speed = 10;
      btnSair.speed = 10;
      yield return new WaitForSeconds(2);
      StopCoroutine(PlayVideo1());     
      videoPlayer[0].Stop();

   }

}
