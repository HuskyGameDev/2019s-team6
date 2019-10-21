using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using MaziesMansion;

public class EnemyPathfinding : MonoBehaviour
{

    public AIPath _AIPath;
    public float velocityThreshold;

    public EnemyPathfinding()

    {
        velocityThreshold = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(LevelState.IsPaused)
            return;

        if (_AIPath.desiredVelocity.x >= velocityThreshold)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (_AIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}

