using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(4)]
public class PlayerHUD : MonoBehaviour
{
   public TextMeshProUGUI maxHpText;
   public TextMeshProUGUI currentHpText;
   public TextMeshProUGUI maxMpText;
   public TextMeshProUGUI currentMpText;
   public Slider hpSlider;
   public Slider mpSlider;
   [SerializeField] Player player;
   public GameObject intermediateCommandUI;
   public GameObject advancedCommandUI;

   void Start()
   {
      player = FindFirstObjectByType<Player>();
   }
   public void SetHUD(Player player)
   {
      maxHpText.text = "/ " + player.maxHp.ToString();
      currentHpText.text = "HP: " + player.currentHp.ToString();
      maxMpText.text = "/ " + player.maxMp.ToString();
      currentMpText.text = "MP: " + player.currentMp.ToString();

      hpSlider.maxValue = player.maxHp;
      hpSlider.value = player.currentHp;
      mpSlider.maxValue = player.maxMp;
      mpSlider.value = player.currentMp;
   }
   public void SetSliders(int hp, int mp)
   {
      hpSlider.value = hp;
      mpSlider.value = mp;
   }
   void Update()
   {
      SetHUD(player);
      ActivateIntermediateUI();
      ActivateAdvancedUI();
   }
   public void ActivateIntermediateUI()
   {
      if (player.level >= 4)
      {
         if (Time.deltaTime != 0)
         {
            intermediateCommandUI.SetActive(true);
         }
         else if (Time.deltaTime == 0)
         {
            intermediateCommandUI.SetActive(false);
         }
      }
      else if (player.level < 4)
      {
         intermediateCommandUI.SetActive(false);
      }
   }
   public void ActivateAdvancedUI()
   {
      if (player.level >= 10)
      {
         if (Time.deltaTime != 0)
         {
            advancedCommandUI.SetActive(true);
         }
         else if (Time.deltaTime == 0)
         {
            advancedCommandUI.SetActive(false);
         }
      }
      else if (player.level < 10)
      {
         advancedCommandUI.SetActive(false);
      }
   }
}
