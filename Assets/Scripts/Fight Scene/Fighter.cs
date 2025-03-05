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

    void Start()
    {
        maxHp = (strength + speed) * 2;
        maxMp = intelligence + swagger;
        currentHp = maxHp;
        currentMp = maxMp;
    }
    public virtual IEnumerator Fight()
    {
        yield return new WaitForSeconds(2.0f);
        damageGiven = strength + Random.Range(1,7);
    }
    public void TakeDamage (int damageTaken)
    {
        currentHp -= damageTaken;
    }
}
