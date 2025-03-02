using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder (3)]
public class PlayerHUD : MonoBehaviour
{
   public TextMeshProUGUI maxHpText;
   public TextMeshProUGUI currentHpText;
   public TextMeshProUGUI maxMpText;
   public TextMeshProUGUI currentMpText;
   public Slider hpSlider;
   public Slider mpSlider;

   public void SetHUD (Player player)
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
}
