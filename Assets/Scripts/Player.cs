using UnityEngine;

public class Player : Fighter
{
    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        Destroy(gameObject);

    }
}
