using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int index = 0;
    private Transform enemy;

    private void Start()
    {
        enemy = transform;
        target = Waypoints.points[0];
        enemy.LookAt(target);
    }

    private void Update()
    {
        enemy.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(enemy.localPosition, target.localPosition) <= 0.5f)
        {
            if (index + 1 < Waypoints.points.Length)
            {
                GetNextWaypoint();
            }
            else
            {
                Destroy(enemy.gameObject);
                return;
            }
            RotateUnit(enemy);
            print($"Объект повернулся");
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
