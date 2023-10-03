using UnityEngine;

public class CountEnemy_1 : MonoBehaviour
{
    public static Transform[] enemy;
    void Awake()
    {
        enemy = new Transform[transform.childCount];
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = transform.GetChild(i);
        }

    }
}
