using UnityEngine;

public class Enemy : Fighter
{
    public void CheckIfDead()
    {
        if (currentHp <= 0)
            Destroy(gameObject);
    }
}
