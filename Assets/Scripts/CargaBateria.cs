using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CargaBateria : MonoBehaviour
{
   public Personagem scPlayer;

   public Color32 verde = new Color32(0, 255, 0, 255);
   public Color32 amarelo = new Color32(255, 230, 0, 255);
   public Color32 laranja = new Color32(255, 150, 0, 255);
   public Color32 vermelho = new Color32(255, 0, 0, 255);

   // Start is called before the first frame update
   void Start()
   {
      scPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();

      scPlayer.scHUD.imgFundoBateriaHUD.enabled = true;

      verificarCargaLanterna();
   }

   // Update is called once per frame
   void Update()
   {
      verificarCargaLanterna();

      this.transform.localScale = new Vector2(scPlayer.scLanterna.carga / scPlayer.scLanterna.cargaMax, 0.7f);
   }


   void verificarCargaLanterna()
   {
      if (scPlayer.scLanterna.carga > 21)
      {
         GetComponent<Image>().color = verde;
      }
      else if (scPlayer.scLanterna.carga > 15 && scPlayer.scLanterna.carga <= 21)
      {
         GetComponent<Image>().color = amarelo;
      }
      else if (scPlayer.scLanterna.carga > 5 && scPlayer.scLanterna.carga <= 15)
      {
         GetComponent<Image>().color = laranja;
      }
      else if (scPlayer.scLanterna.carga <= 5)
      {
         GetComponent<Image>().color = vermelho;
      }


   }

}
