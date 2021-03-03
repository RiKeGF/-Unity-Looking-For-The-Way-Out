using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
   public Image imgFundoEnergiaHUD;
   public Image imgFundoGeradorHUD;
   public Image imgBordaFundoGeradorHUD;
   public Image imgGeradorHUD;
   public Image imgEnergiaGeradorHUD;

   public Image imgFundoBateriaHUD;
   public Image imgFundoLanternaHUD;
   public Image imgBordaFundoLanternaHUD;

   public Image imgFundoChaveMestraHUD;
   public Image imgBordaFundoChaveMestraHUD;

   public Image fundoTimer;
   public Text textTimer;

   public Text textTemperatura;

   public Image imgTecladoHUD;

   public Animator fade;

   public Image gelo;
   public Color[] alfa;

   public Image bgTutorial;
   public Animator bgAnimTutorial;

   public Text textTutorial;

   public Image infoMouse;
   public Animator infoAnimMouse;

   public Image infoP;
   public Image infoEsc;
   public Image infoF;
   public Image infoE;
   public Image infoCtrl;
   public Image infoTab;
   public Image infoGeral;


   void Start()
   {
      bgTutorial.enabled = false;
      StartCoroutine(ativarBGTutorial());
      imgEnergiaGeradorHUD.enabled = false;
      imgFundoGeradorHUD.enabled = false;
      imgBordaFundoGeradorHUD.enabled = false;
      imgGeradorHUD.enabled = false;
      imgFundoLanternaHUD.enabled = false;
      imgBordaFundoLanternaHUD.enabled = false;
      imgFundoChaveMestraHUD.enabled = false;
      imgBordaFundoChaveMestraHUD.enabled = false;
      imgFundoBateriaHUD.enabled = false;
      imgFundoEnergiaHUD.enabled = false;
      imgTecladoHUD.enabled = false;

      fundoTimer.enabled = false;
      textTimer.enabled = false;

      gelo.color = alfa[0];

      desativarImagesTutorial();
   }

  public void desativarImagesTutorial(){
      infoMouse.enabled = false;
      infoP.enabled = false;
      infoEsc.enabled = false;
      infoF.enabled = false;
      infoE.enabled = false;
      infoCtrl.enabled = false;
      infoTab.enabled = false;
      infoGeral.enabled = false;
   }

   public void trocarImagemTutorial(string nome)
   {
      desativarImagesTutorial();
      switch (nome)
      {
         case "Pegar":
         {
            infoMouse.enabled = true;
            infoAnimMouse.SetTrigger("Pegar");
            break;
         }
         case "F":
         {
            infoF.enabled = true;
            break;
         }
         case "E":
         {
            infoE.enabled = true;
            break;
         }
         case "Pause":
         {
            infoP.enabled = true;
            infoEsc.enabled = true;
            break;
         }
         case "Ctrl":
         {
            infoCtrl.enabled = true;
            break;
         }
         case "TAB":
         {
            infoTab.enabled = true;
            break;
         }
         case "Geral":
         {
            infoGeral.enabled = true;
            break;
         }
      }
   }

   IEnumerator ativarBGTutorial()
   {
      while (true)
      {
         yield return new WaitForSeconds(1);
         bgTutorial.enabled = true;
         break;
      }
      
   }
}
