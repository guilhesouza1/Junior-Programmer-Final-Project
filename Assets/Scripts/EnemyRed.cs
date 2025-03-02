using UnityEngine;

public class EnemyRed : Enemy
{
    void Awake()
    {
        level = 1;
        strength = 1;
        speed = 0;
        swagger = 0;
        intelligence = 0;
    }
    void Update()
    {
        CheckIfDead();
    }
}
