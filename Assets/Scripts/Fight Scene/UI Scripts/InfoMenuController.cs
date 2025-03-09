using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenuController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI intelligenceText;
    [SerializeField] TextMeshProUGUI strengthText;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI swaggerText;
    [SerializeField] TextMeshProUGUI xpToNextText;
    [SerializeField] TextMeshProUGUI currentXpText;
    [SerializeField] Button getIntelligenceButton;
    [SerializeField] Button getStrengthButton;
    [SerializeField] Button getSpeedButton;
    [SerializeField] Button getSwaggerButton;
    [SerializeField] TextMeshProUGUI getIntelligenceButtonText;
    [SerializeField] TextMeshProUGUI getStrengthButtonText;
    [SerializeField] TextMeshProUGUI getSpeedButtonText;
    [SerializeField] TextMeshProUGUI getSwaggerButtonText;
    public Player player;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }
    void Update()
    {        
        int levelUpCost = 5 * (1 + player.level) * player.level;
        int toNextLevelInt = levelUpCost - player.maxXp;

        levelText.text = "Level: " + player.level.ToString();
        intelligenceText.text = "Intelligence: " + player.intelligence.ToString();
        strengthText.text = "Strength: " + player.strength.ToString();
        speedText.text = "Speed: " + player.speed.ToString();
        swaggerText.text = "Swagger: " + player.swagger.ToString();
        xpToNextText.text = "To Next Level: " + toNextLevelInt.ToString() + "XP";
        currentXpText.text = "Available: " + player.currentXp.ToString() + "XP";

        getIntelligenceButtonText.text = "Get: " + player.intelligenceCost.ToString() + "XP";
        getStrengthButtonText.text = "Get: " + player.strengthCost.ToString() + "XP";
        getSpeedButtonText.text = "Get: " + player.speedCost.ToString() + "XP";
        getSwaggerButtonText.text = "Get: " + player.swaggerCost.ToString() + "XP";
    }
    public void OnIntelligenceUp()
    {
        if (player.currentXp > player.intelligenceCost)
        {
            player.intelligence++;
            player.currentXp -= player.intelligenceCost;
            player.intelligenceCost+= player.level - 1;
            player.currentHp = player.maxHp;
            player.currentMp = player.maxMp;
        }
        else
            Debug.Log("You don't have enough Xp!");
        return;
    }
    public void OnSpeedUp()
    {
        if (player.currentXp > player.speedCost)
        {
            player.speed++;
            player.currentXp -= player.speedCost;
            player.speedCost+= player.level - 1;
            player.maxHp = (player.strength + player.speed) * 2;
            player.currentHp = player.maxHp;
            
        }
        else
            Debug.Log("You don't have enough Xp!");
        return;
    }
    public void OnStrengthUp()
    {
        if (player.currentXp > player.strengthCost)
        {
            player.strength++;
            player.currentXp -= player.strengthCost;
            player.strengthCost+= player.level -1;
            player.maxHp = (player.strength + player.speed) * 2;
            player.currentHp = player.maxHp;
        }
        else
            Debug.Log("You don't have enough Xp!");
        return;
    }
    public void OnSwaggerUp()
    {
        if (player.currentXp > player.swaggerCost)
        {
            player.swagger++;
            player.currentXp -= player.swaggerCost;
            player.swaggerCost+= player.level -1;
            player.currentHp = player.maxHp;
            player.currentMp = player.maxMp;
        }
        else
            Debug.Log("You don't have enough Xp!");
        return;
    }
}
