using System.Collections;
using TMPro;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int level;
    public int strength;
    public int speed;
    public int swagger;
    public int intelligence;
    public int maxHp;
    public int currentHp;
    public int maxMp;
    public int currentMp;
    public int damageGiven;
    public bool criticalHit;
    public bool criticalFailure;
    public Animator animator;
    //public TextMeshProUGUI damageUI;

    void Start()
    {
        maxHp = (strength + speed) * 2;
        maxMp = intelligence + swagger;
        currentHp = maxHp;
        currentMp = maxMp;

        /*GameObject tmpGO = GameObject.Find("/UICanvas/DamageUI/DamageText");
        damageUI = tmpGO.GetComponent<TextMeshProUGUI>();
        damageUI.text = " ";*/
    }
    public virtual IEnumerator Fight()
    {
        //StartAnimation();
        yield return new WaitForSeconds(2.0f);
        //StartFightAction();
        damageGiven = strength + Random.Range(1, 7);
    }
    public void TakeDamage(int damageTaken)
    {
        currentHp -= damageTaken;
    }
    public void StartFightAnimation()
    {
        animator.SetTrigger("Fight");
    }
    public void StartFightAction()
    {

    }
}
