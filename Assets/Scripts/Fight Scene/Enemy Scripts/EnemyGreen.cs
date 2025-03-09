using UnityEngine;

public class EnemyGreen : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Awake()
    {
        GetTMP();
        level = 2;
        strength = 3;
        speed = 3;
        swagger = 2;
        intelligence = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
