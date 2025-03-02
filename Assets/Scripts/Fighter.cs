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

    void Awake()
    {
     maxHp = strength + speed;
     maxMp = intelligence + swagger;   
    }
}
