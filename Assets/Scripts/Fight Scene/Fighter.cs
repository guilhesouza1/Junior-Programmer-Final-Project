using System.Collections;
using TMPro;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int level { get; set; }
    public int strength { get; set; }
    public int speed { get; set; }
    public int swagger { get; set; }
    public int intelligence { get; set; }
    public int maxHp { get; set; }
    public int currentHp { get; set; }
    public int maxMp { get; set; }
    public int currentMp { get; set; }
    public int damageGiven { get; set; }
    public bool criticalHit; //{get;set;}
    public bool criticalFailure; //{get;set;}
    public bool isDead { get; set; }
    public bool isFighting {get; set;}

    void Start()
    {
        maxHp = (strength + speed) * 2;
        maxMp = intelligence + swagger;
        currentHp = maxHp;
        currentMp = maxMp;
    }
    public virtual IEnumerator Fight()
    {
        if (!isDead)
        {
            isFighting = true;
            damageGiven = strength + Random.Range(1, 7);
            StartFightAnimation();
            //yield return new WaitForSeconds(2.0f);
            yield return new WaitForSeconds(3.0f);
            StartFightAction();
            isFighting = false;
        }
    }
    public void TakeDamage(int damageTaken)
    {
        currentHp -= damageTaken;
    }
    public virtual void StartFightAnimation()
    {

    }
    public virtual void StartFightAction()
    {

    }
}
