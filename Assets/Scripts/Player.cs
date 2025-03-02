using UnityEngine;

[DefaultExecutionOrder (2)]
public class Player : Fighter
{
    public int maxXp;
    public int currentXp;
    void Awake()
    {
        level = 1;
        strength = 1;
        speed = 2;
        swagger = 1;
        intelligence = 1;
        maxXp = 0;

        currentXp = maxXp;

    }
    void Update()
    {
        LevelUp();

        if (currentHp <= 0)
            Destroy(gameObject);

    }
    void LevelUp()
    {
        if (maxXp == (level + 1) * 11)
            level++;
    }
}
