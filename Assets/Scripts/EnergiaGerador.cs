using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaGerador : MonoBehaviour
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
   }

   // Update is called once per frame
   void Update()
   {
      verificarEnergiaGerador();

      if (scPlayer.scGerador.energia <= 0)
      {
         scPlayer.scGerador.energia = 0;
      }
      else if (scPlayer.scGerador.energia >= 100)
      {
         scPlayer.scGerador.energia = 100;
      }

      this.transform.localScale = new Vector2(scPlayer.scGerador.energia / scPlayer.scGerador.energiaMax, 0.4f);
   }


   void verificarEnergiaGerador()
   {
      if (scPlayer.scGerador.energia > 80)
      {
         GetComponent<Image>().color = verde;
      }
      else if (scPlayer.scGerador.energia >= 40 && scPlayer.scGerador.energia <= 80)
      {
         GetComponent<Image>().color = amarelo;
      }
      else if (scPlayer.scGerador.energia >= 20 && scPlayer.scGerador.energia < 40)
      {
         GetComponent<Image>().color = laranja;
      }
      else if (scPlayer.scGerador.energia >= 0 && scPlayer.scGerador.energia < 20)
      {
         GetComponent<Image>().color = vermelho;
      }
   }

}
