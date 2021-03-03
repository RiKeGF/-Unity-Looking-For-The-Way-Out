using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanterna : MonoBehaviour
{ 
   public Personagem scPlayer;

   public GameObject luzLanterna;
   public bool lanternaAcesa = false;

   public float countEquiparBateria = 2;
   public float timerLanterna = 2;
   public float carga = 0;
   public float cargaMax = 30;
   public int countLuzLanterna = 0;
   public float timerLuzLanterna = 1;

   public Image bateria;

   public bool equipou;

   // Start is called before the first frame update
   void Start()
   {
   }

   // Update is called once per frame
   void Update()
   {
      if (equipou)
      {
         countEquiparBateria -= Time.deltaTime;
         if (countEquiparBateria < 0)
         {
            scPlayer.scInventario.InventarioAddItem("BateriaHUD", 2);
            
            scPlayer.scLanterna.carga = cargaMax;
   

            equipou = false;
            countEquiparBateria = 2;
         }
         
      }
      if (scPlayer.scInventario.pegouLanterna)
      {

         if (carga >= 4 && carga <= 8)
         {
            piscarLuzLanterna();
         }

         if (lanternaAcesa && carga > 0)
         {
            luzLanterna.SetActive(true);

            timerLanterna -= Time.deltaTime;
            if (timerLanterna < 0)
            {
               carga--;
               timerLanterna = 2;
            }
         }
         else
         {
            luzLanterna.SetActive(false);
         }

      }
   }

   public void FixedUpdate()
   {
      if (carga <= 0)
      {
         scPlayer.scInventario.slotBateria = false;
      }
      else
      {
         scPlayer.scInventario.slotBateria = true;
      }
   }
   public void piscarLuzLanterna()
   {
      timerLuzLanterna -= Time.deltaTime;

      if (countLuzLanterna < 5)
      {
         if (timerLuzLanterna < 0)
         {
            lanternaAcesa = false;
            timerLuzLanterna = Random.Range(0.2f, 0.5f);
            countLuzLanterna++;
            if (countLuzLanterna >= 5)
            {
               lanternaAcesa = true;
            }
         }
         else
         {
            lanternaAcesa = true;

         }
      }


   }


}
