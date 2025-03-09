using UnityEngine;

public class EnemyYellow : Enemy
{
    void Awake()
    {
        GetTMP();
        level = 5;
        strength = 7;
        speed = 7;
        swagger = 8;
        intelligence = 9;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
