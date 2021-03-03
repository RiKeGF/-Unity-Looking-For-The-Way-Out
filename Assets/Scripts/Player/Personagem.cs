using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
   public GameObject mao;

   public GameObject mira;

   public Pause scPause;
   public Portas scPortas;
   public Lanterna scLanterna;
   public Puzzles scPuzzles;
   public Luzes scLuzes;
   public Inventario scInventario;
   public Itens scItens;
   public Localização scLocalizacao;
   public Gerador scGerador;
   public FirstPersonController scFPSPlayer;
   public Acao scAcao;
   public HUD scHUD;
   public Gaveta scGaveta;
   public Sons scSons;
   public Cheats scCheats;
   public Ventilador scVentilador;
   public Elevador scElevador;
   public Shake scShake;
   public Tutorial scTutorial;

   public int HP = 100;
   private float countHP = 1;

   public bool agaixado;
   private bool block;

   public int estaminaMAX = 3;
   public int estamina = 3;

   public bool morreu;

   public float velociadeVentilador;

   //Itens equipaveis
   public GameObject goLanterna;

   public TextMesh info;

   // Start is called before the first frame update
   void Start()
   {
      scInventario.zerarConfigInventario();
      info.gameObject.SetActive(false);

      //Desativando itens
      scInventario.actionItemPerson(0, goLanterna, "Lanterna");
      //scInventario.InventarioAddItem("ChaveMestra", 0);

      scInventario.invUI.SetActive(false);
      //InventarioAddItem("Resistor", 0);

   }


   void Update()
   {
      if (!morreu)
      {
         if (!scPause.pause)
         {
            Controles();
         }

         if (scLocalizacao.localizacaoID != 3 && HP < 100)
         {
            recuperarHP();

         }
         if (scLocalizacao.localizacaoID == 3)
         {
            HPxTemperatura();
         }

         verificarEstamina();
      }
   }

   public void recuperarHP()
   {
      countHP -= Time.deltaTime;

      if (countHP < 0)
      {
         HP += 10;
      }
   }

   public void verificarEstamina()
   {
      if (agaixado)
      {
         estaminaMAX = 1;
      }
      else
      {
         if (HP == 100)
         {
            estaminaMAX = 3;
         }
         else if (HP == 50)
         {
            estaminaMAX = 2;
         }
         else if (HP == 20)
         {
            estaminaMAX = 1;
         }
      }

      estamina = estaminaMAX;
   }

   public void HPxTemperatura()
   {
      if (scPuzzles.scTemperatura.temperaturaSala > 20)
      {
         HP = 100;

         if (scSons.somGelando.isPlaying)
         {
            scSons.somGelando.Stop();
         }
      }
      else if (scPuzzles.scTemperatura.temperaturaSala <= 10 && scPuzzles.scTemperatura.temperaturaSala > 0)
      {
         if (!scSons.somGelando.isPlaying)
         {
            scSons.somGelando.Play();
         }
         HP = 50;
      }
      else if (scPuzzles.scTemperatura.temperaturaSala < 0)
      {
         HP = 20;
      }

      if (scPuzzles.scTemperatura.temperaturaSala <= -15)
      {
         if (!scSons.somMorrendo.isPlaying)
         {
            scSons.somMorrendo.Play();
         }

         StartCoroutine(morrendo());

      }
   }

   void Controles()
   {
      if (Input.GetKeyDown(KeyCode.Tab) && scInventario.equipouMochila)
      {
         scInventario.InventarioOpen();
      }
      if (scInventario.pegouLanterna && scLanterna.bateria != null)
      {
         if (Input.GetKeyDown(KeyCode.F))
         {
            if (scLanterna.lanternaAcesa)
            {
               if (!scSons.somLanternaLigando.isPlaying)
               {
                  scSons.somLanternaLigando.Play();
               }
            }
            else
            {
               if (!scSons.somLanternaDesligando.isPlaying)
               {
                  scSons.somLanternaDesligando.Play();
               }
            }
            scLanterna.lanternaAcesa = !scLanterna.lanternaAcesa;
         }
      }

      if (Input.GetKey(KeyCode.LeftControl))
      {
         StopCoroutine(levantando());
         StartCoroutine(agaixando());
      }
      if (Input.GetKeyUp(KeyCode.LeftControl))
      {

         StopCoroutine(agaixando());
         StartCoroutine(levantando());
      }
   }

   private void OnTriggerEnter(Collider col)
   {
      if (col.transform.tag == "Ventilador")
      {
         if (velociadeVentilador > 8)
         {
            if (!scSons.somMorrendo.isPlaying)
            {
               scSons.somMorrendo.Play();
            }
            if (!scSons.somBatida.isPlaying)
            {
               scSons.somBatida.Play();
            }
            if (!scSons.somSangue.isPlaying)
            {
               scSons.somSangue.Play();
            }
            StartCoroutine(morrendo());
         }
         block = true;

      }
      else if (col.transform.tag == "Teto")
      {
         block = true;

      }
      else if ((col.tag == "SensorMovP3" && !scPuzzles.startEvent) && scGerador.funcionando)
      {
         if (scGerador.energia > 10 && scGerador.funcionando)
         {


            scPortas.porta3_1.SetBool("Abrir", true);
            scPortas.porta3_2.SetBool("Abrir", true);

            if (!scSons.somPortaVidroAbrindo.isPlaying && scPortas.porta3_1.GetBool("Abrir"))
            {
               scSons.somPortaVidroAbrindo.Play();
            }
            scGerador.energia -= 10;
            StartCoroutine(scGerador.recuperarEnergiaPorta());
         }
      }
   }
   private void OnTriggerStay(Collider col)
   {


   }

   private void OnTriggerExit(Collider col)
   {


      if ((col.tag == "SensorMovP3" && scGerador.funcionando) && scGerador.energia > 10)
      {
         if (!scSons.somPortaVidroAbrindo.isPlaying)
         {
            scSons.somPortaVidroAbrindo.Play();
         }
         scPortas.porta3_1.SetBool("Abrir", false);
         scPortas.porta3_2.SetBool("Abrir", false);
      }

      if (col.transform.tag == "Ventilador" || col.tag == "Teto")
      {
         block = false;

      }
   }


   IEnumerator agaixando()
   {
      while (scFPSPlayer.m_CharacterController.height > 0.1f)
      {
         scFPSPlayer.m_CharacterController.height -= 0.1f;
         yield return new WaitForSeconds(0.005f);
      }
      agaixado = true;
      StopCoroutine(agaixando());

   }
   IEnumerator levantando()
   {
      if (!block)
      {
         while (scFPSPlayer.m_CharacterController.height < 1.8f)
         {
            scFPSPlayer.m_CharacterController.height += 0.1f;
            yield return new WaitForSeconds(0.005f);
         }
         agaixado = false;
         StopCoroutine(levantando());
      }


   }

   IEnumerator morrendo()
   {
      morreu = true;
      scFPSPlayer.enabled = false;
      
      this.GetComponent<Animator>().enabled = true;
      this.GetComponent<Animator>().SetTrigger("Morreu");

      yield return new WaitForSeconds(3);

      scHUD.fade.gameObject.SetActive(true);
      scHUD.fade.SetTrigger("Escurece");

      yield return new WaitForSeconds(3);

      SceneManager.LoadScene("Menu");
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Chao")
      {
         scShake.GetComponent<Shake>().Tremer();
      }
   }
}
