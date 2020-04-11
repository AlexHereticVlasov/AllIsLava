using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampEnemy : BaseEnemy
{
    void Start()
    {
        WaitCounter = TimeToWait;
    }

    void Update()
    {
        if (IsMooving)
            Move();
        else
            Wait();
    }

    protected override void Move()
    {
        float delta = Speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, WayPoints[PointIndex].position, delta);
        if (Vector3.Distance(transform.position, WayPoints[PointIndex].position) < delta)
        {
            transform.position = WayPoints[PointIndex].position;
            IsMooving = false;

            PointIndex++;
            if (PointIndex > WayPoints.Length - 1)
            {
                PointIndex = 0;
            }
        }
    }

    protected override void Wait()
    {
        WaitCounter -= Time.deltaTime;
        if (WaitCounter <= 0)
        {
            IsMooving = true;
            WaitCounter = TimeToWait;
        }
    }
}
