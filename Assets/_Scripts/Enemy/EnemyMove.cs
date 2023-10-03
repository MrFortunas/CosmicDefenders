using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int index = 0;
    private Transform[] enemy;

    private void Start()
    {
        target = Waypoints.points[0];
        enemy = new Transform[CountEnemy_1.enemy.Length];
        for (int i = 0; i < CountEnemy_1.enemy.Length; i++)
        {
            enemy[i] = CountEnemy_1.enemy[i];
        }
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].LookAt(target);
        }
    }

    private void Update()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] != null)
            {
                enemy[i].Translate(Vector3.forward * speed * Time.deltaTime);
                if (Vector3.Distance(enemy[i].localPosition, target.localPosition) <= 0.1f)
                {
                    if (index + 1 < Waypoints.points.Length)
                    {
                        GetNextWaypoint();
                    }
                    else
                    {
                        Destroy(enemy[i].gameObject);
                        return;
                    }
                    for (int y = 0; y < enemy.Length; y++)
                    {
                        RotateUnit(enemy[y]);
                        print($"Объект {y} повернулся");
                    }
                }
            }
        }
    }
    void GetNextWaypoint()
    {
        index++;
        target = Waypoints.points[index];
        print($"Номер точки {index}");
    }
    void RotateUnit(Transform enemy)
    {
        enemy.LookAt(target);
    }
}
