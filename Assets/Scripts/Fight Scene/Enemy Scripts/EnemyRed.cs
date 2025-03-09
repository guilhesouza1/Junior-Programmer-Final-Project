using UnityEngine;
using TMPro;

[DefaultExecutionOrder (3)]
public class EnemyRed : Enemy
{
    void Awake()
    {
        GetTMP();
        level = 1;
        strength = 0;
        speed = 1;
        swagger = 0;
        intelligence = 0;

    }
    void Update()
    {
        CheckIfDead();
    }
}
