using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Transform enemyGFX;

    public float speed;
    public float nextPointDist;

    public Path path;
    public int currentPoint;
    public bool reachedEnd;

    public Seeker seek;
    Rigidbody2D rigidbody;

    public EnemyAI()
    {
        speed = 200f;
        nextPointDist = 3f;
        currentPoint = 0;
        reachedEnd = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        seek = GetComponent<Seeker>();
        rigidbody = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        seek.StartPath(rigidbody.position, target.position);
    }

    void UpdatePath()
    {
        if (seek.IsDone())
        {
            seek.StartPath(rigidbody.position, target.position, onPathCompletion);
        }
    }
    void onPathCompletion(Path p)
    {
        if (p.error)
        {
            path = p;
            currentPoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(path == null)
        {
            return;
        }

        if(currentPoint == path.vectorPath.Count)
        {
            reachedEnd = true;
            return;
        } else
        {
            reachedEnd = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentPoint] - rigidbody.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rigidbody.AddForce(force);
        float distance = Vector2.Distance(rigidbody.position, path.vectorPath[currentPoint]);

        if(distance < nextPointDist)
        {
            currentPoint++;
        }

        if (rigidbody.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rigidbody.velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
