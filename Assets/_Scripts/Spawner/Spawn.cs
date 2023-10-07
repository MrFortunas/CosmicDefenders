using Unity.Mathematics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int count_1 = 0;
    public int count_2 = 0;
    public int count_3 = 0;
    public Transform enemy1= null;
    public Transform enemy2= null;
    public Transform enemy3 = null;
    public float timer = 0f;
    private float timerDef = 0f;
    public Vector3 pos;
    public quaternion rot;

    private void Start()
    {
        timerDef = timer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = timerDef;
            if(count_1 > 0)
            {
                count_1--;
                Instantiate(enemy1, pos, rot);
            }
            if (count_2 > 0)
            {
                Instantiate(enemy2, pos, rot);
                count_2--;
            }
            if (count_2 > 0)
            {
                Instantiate(enemy3, pos, rot);
                count_3--;
            }
        }
    }
}
