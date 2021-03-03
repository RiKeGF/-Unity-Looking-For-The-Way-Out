using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
   public Personagem scPlayer;
   public GameObject CenItens;

   public GameObject invUI;
   public bool invOpen;
   public List<GameObject> itens;

   public RectTransform contentItens;
   public RectTransform contentMao;
   public RectTransform contentBateria;
   public RectTransform contentInfo;
   public RectTransform contentLanterna;
   public RectTransform contentDicas;
   public RectTransform contentChaveMestra;

   public GameObject viewInfoHUD;
   public GameObject viewActionsHUD;
   public GameObject bgInfoHUD;

   public Text descricao;
   public Text titulo;

   public Image imgLanterna;
   public Image imgIndutor;
   public Image imgResistor;
   public Image imgChaveMestra;
   public Image imgDicas;
   public Image imgFuzivel;
   public Image imgBateria;
   public Image imgBotaoElevador;

   public bool equipouMochila;

   public Image imgBateriaHUD;

   public GameObject buttonUsar;
   public GameObject buttonDropar;

   public bool pegouResistor = false;
   public bool pegouIndutor = false;
   public bool pegouChaveMestra = false;
   public bool pegouFuzivel = false;
   public bool pegouDicas = false;
   public bool pegouLanterna = false;

   public bool slotBateria = false;

   public int count = 0;

   // Start is called before the first frame update
   void Start()
   {
      scPlayer.scInventario.viewInfoHUD.SetActive(true);
      scPlayer.scInventario.bgInfoHUD.SetActive(true);
   }

   // Update is called once per frame
   void Update()
   {
      if (scPlayer.scAcao.nomeSlot == "Slot1" || scPlayer.scAcao.nomeSlot == "Slot2" || scPlayer.scAcao.nomeSlot == "Slot3" || scPlayer.scAcao.nomeSlot == "Slot4" ||
         scPlayer.scAcao.nomeSlot == "CadeadoS1" || scPlayer.scAcao.nomeSlot == "CadeadoS4")
      {
         scPlayer.scInventario.viewInfoHUD.SetActive(false);
         scPlayer.scInventario.bgInfoHUD.SetActive(false);
      }
      else
      {
         scPlayer.scInventario.viewInfoHUD.SetActive(true);
         scPlayer.scInventario.bgInfoHUD.SetActive(true);
      }
   }

   public void InventarioOpen()
   {
      invOpen = !invOpen;
      
      if (invOpen)
      {
        scPlayer.scSons.somInventarioOpen.Play();
         Cursor.lockState = CursorLockMode.None;
         invUI.SetActive(true);
         Cursor.visible = true;
      }
      else
      {
         scPlayer.scSons.somInventarioClose.Play();
         zerarConfigInventario();
         Cursor.lockState = CursorLockMode.Confined;
         invUI.SetActive(false);
         Cursor.visible = false;
      }

   }


   public void zerarConfigInventario()
   {
      viewActionsHUD.SetActive(false);

      titulo.text = "";
      descricao.text = "";

      imgLanterna.enabled = false;
      imgChaveMestra.enabled = false;
      imgResistor.enabled = false;
      imgDicas.enabled = false;
      imgFuzivel.enabled = false;
      imgIndutor.enabled = false;
      imgBateria.enabled = false;
      imgBotaoElevador.enabled = false;

   }
   public void actionItemPerson(int action, GameObject item, string nome)
   {
      switch (action)
      {
         case 0:
         {
            item.SetActive(false);
            switch (nome)
            {
               case "Lanterna":
               {
                  scPlayer.scInventario.pegouLanterna = false;
                  scPlayer.scLanterna.lanternaAcesa = false;
                  break;
               }
            }
            break;
         }
         case 1:
         {
            item.SetActive(true);
            switch (nome)
            {
               case "Lanterna":
               {

                  scPlayer.scInventario.pegouLanterna = true;
                  scPlayer.scLanterna.lanternaAcesa = false;
                  break;
               }
            }
            break;
         }
      }
   }

   public void InventarioAddItem(string nomeItem, int local) //0 - Inventario / 1 - Mao direita
   {
      if (count < 4 )
      {
         if (nomeItem != "Lanterna" && nomeItem != "Dicas" && nomeItem != "BateriaHUD" && local != 6)
         {
            count++;
         }
         if (local == 6)
         {
            itens[5].GetComponent<ButtonChaveMestra>().hud = true;
         }
         else
         {
            itens[5].GetComponent<ButtonChaveMestra>().hud = false;
         }

         RectTransform content;

         switch (local)
         {
            case 0:
            {
               content = contentItens;
               break;
            }
            case 1:
            {
               content = contentMao;
               break;
            }
            case 2:
            {
               content = contentBateria;
               break;
            }
            case 3:
            {
               content = contentInfo;
               break;
            }
            case 4:
            {
               content = contentLanterna;
               break;
            }
            case 5:
            {
               content = contentDicas;
               break;
            }
            case 6:
            {
               content = contentChaveMestra;
               break;
            }
            default:
            {
               content = null;
               break;
            }
         }
         

         switch (nomeItem)
         {
            case "Lanterna":
            {
               GameObject item = Instantiate(itens[0], content.position, Quaternion.identity) as GameObject;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector3(1, 1.3f, 1);
               scPlayer.scHUD.imgFundoLanternaHUD.enabled = true;
               scPlayer.scHUD.imgBordaFundoLanternaHUD.enabled = true;
               pegouLanterna = true;
               break;
            }
            case "Fuzivel":
            {
               GameObject item = Instantiate(itens[1], content.position, Quaternion.identity) as GameObject;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector3(0.65f, 1, 1);
               pegouFuzivel = true;
               break;
            }
            case "Indutor":
            {
               GameObject item = Instantiate(itens[2], content.position, Quaternion.identity) as GameObject;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector3(0.8f, 0.82f, 1);
               pegouIndutor = true;
               break;
            }
            case "Resistor":
            {
               GameObject item = Instantiate(itens[3], content.position, Quaternion.identity) as GameObject;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector3(0.7f, 1, 1);
               pegouResistor = true;
               break;
            }
            case "Dicas":
            {
               GameObject item = Instantiate(itens[4], content.position, Quaternion.identity) as GameObject;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector3(0.5f, 0.95f, 1);
               pegouDicas = true;
               break;
            }
            case "ChaveMestra":
            {
               GameObject item = Instantiate(itens[5], content.position, Quaternion.identity) as GameObject;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector3(0.85f, 1, 1);
               pegouChaveMestra = true;
               scPlayer.scHUD.imgBordaFundoChaveMestraHUD.enabled = true;
               scPlayer.scHUD.imgFundoChaveMestraHUD.enabled = true;
              
               break;
            }
            case "Bateria":
            {
               GameObject item = Instantiate(itens[6], content.position, Quaternion.identity) as GameObject;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector3(1, 1.3f, 1);
               
               break;
            }
            case "BateriaHUD":
            {
               if (scPlayer.scLanterna.carga <= 0 && scPlayer.scLanterna.bateria != null)
               {
                  Destroy(scPlayer.scLanterna.bateria.gameObject);
                  
               }

               Image item = Instantiate(imgBateriaHUD, content.position, Quaternion.identity) as Image;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector2(1.2f, 0.7f);

            
               scPlayer.scLanterna.bateria = item;
               

               break;
            }
            case "BotaoElevador":
            {
               GameObject item = Instantiate(itens[7], content.position, Quaternion.identity) as GameObject;
               item.transform.SetParent(content.transform);
               item.transform.localScale = new Vector3(0.8f, 1, 1);

               break;
            }
         }
      }
      
   }

   public void InventarioDelItem(string nomeItem) //0 - Inventario / 1- Mao direita
   {
      if (count > 0)
      {
         count--;

         switch (nomeItem)
         {
            case "Lanterna":
            {
               Destroy(GameObject.FindGameObjectWithTag("ButtonLanterna"));
               pegouLanterna = false;
               break;
            }
            case "Fuzivel":
            {
               Destroy(GameObject.FindGameObjectWithTag("ButtonFuzivel"));
               pegouFuzivel = false;
               break;
            }
            case "Indutor":
            {
               Destroy(GameObject.FindGameObjectWithTag("ButtonIndutor"));
               pegouIndutor = false;
               break;
            }
            case "Resistor":
            {
               Destroy(GameObject.FindGameObjectWithTag("ButtonResistor"));
               pegouResistor = false;
               break;
            }
            case "Dicas":
            {
               Destroy(GameObject.FindGameObjectWithTag("ButtonDicas"));
               pegouDicas = false;
               break;
            }
            case "ChaveMestra":
            {
               GameObject[] objects = GameObject.FindGameObjectsWithTag("ButtonChaveMestra");

               for (int i = 0; i < objects.Length; i++)
               {
                  Destroy(objects[i]);
               }

               pegouChaveMestra = false;
               scPlayer.scHUD.imgBordaFundoChaveMestraHUD.enabled = false;
               scPlayer.scHUD.imgFundoChaveMestraHUD.enabled = false;
               break;
            }
            case "Bateria":
            {
               Destroy(GameObject.FindGameObjectWithTag("ButtonBateria"));
               break;
            }
            case "BotaoElevador":
            {
               Destroy(GameObject.FindGameObjectWithTag("ButtonElevador"));
               break;
            }
         }
      }
      
   }

   public void InventarioDropItem(string nomeItem)
   {
      switch (nomeItem)
      {
         case "Fuzivel":
         {
            GameObject DropFuzivel = Instantiate(scPlayer.scItens.fuzivel, scPlayer.mao.transform.position, Quaternion.identity) as GameObject;
            Rigidbody gravity = DropFuzivel.GetComponent<Rigidbody>();
            gravity.useGravity = true;
           
            Vector3 force = scPlayer.gameObject.transform.forward * 20;
            gravity.AddForce(force);
            gravity.AddForce(0, 150, 0);
            
            DropFuzivel.transform.parent = CenItens.transform;
            
            break;
         }
         case "Resistor":
         {
            GameObject DropResistor = Instantiate(scPlayer.scItens.resistor, scPlayer.mao.transform.position, Quaternion.identity) as GameObject;
            Rigidbody gravity = DropResistor.GetComponent<Rigidbody>();
            gravity.useGravity = true;

            Vector3 force = scPlayer.gameObject.transform.forward * 20;
            gravity.AddForce(force);
            gravity.AddForce(0, 150, 0);

            DropResistor.transform.parent = CenItens.transform;

            break;
         }
         case "Indutor":
         {
            GameObject DropIndutor = Instantiate(scPlayer.scItens.indutor, scPlayer.mao.transform.position, Quaternion.identity) as GameObject;
            Rigidbody gravity = DropIndutor.GetComponent<Rigidbody>();
            gravity.useGravity = true;

            Vector3 force = scPlayer.gameObject.transform.forward * 20;
            gravity.AddForce(force);
            gravity.AddForce(0, 150, 0);

            DropIndutor.transform.parent = CenItens.transform;

            break;
         }
         case "ChaveMestra":
         {
            GameObject DropChaveMestra = Instantiate(scPlayer.scItens.chaveMestra, scPlayer.mao.transform.position, Quaternion.identity) as GameObject;
            Rigidbody gravity = DropChaveMestra.GetComponent<Rigidbody>();
            gravity.useGravity = true;

            Vector3 force = scPlayer.gameObject.transform.forward * 20;
            gravity.AddForce(force);
            gravity.AddForce(0, 150, 0);

            DropChaveMestra.transform.parent = CenItens.transform;

            break;
         }
         case "Bateria":
         {
            GameObject DropBateria = Instantiate(scPlayer.scItens.bateria, scPlayer.mao.transform.position, Quaternion.identity) as GameObject;
            Rigidbody gravity = DropBateria.GetComponent<Rigidbody>();
            gravity.useGravity = true;

            Vector3 force = scPlayer.gameObject.transform.forward * 20;
            gravity.AddForce(force);
            gravity.AddForce(0, 150, 0);

            DropBateria.transform.parent = CenItens.transform;

            break;
         }
         case "BotaoElevador":
         {
            GameObject DropBotaoElevador = Instantiate(scPlayer.scItens.botaoElevador, scPlayer.mao.transform.position, Quaternion.identity) as GameObject;
            Rigidbody gravity = DropBotaoElevador.GetComponent<Rigidbody>();
            gravity.useGravity = true;

            Vector3 force = scPlayer.gameObject.transform.forward * 20;
            gravity.AddForce(force);
            gravity.AddForce(0, 150, 0);

            DropBotaoElevador.transform.parent = CenItens.transform;

            break;
         }


      }
      InventarioDelItem(nomeItem);
      InventarioOpen();
   }




}
