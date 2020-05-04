using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class KyubueMovement : MonoBehaviour
{
    public GameObject target;
    public float distanceRadius;
    public float minSpeed = 200f;
    public float maxSpeed = 400f;
    public float nextWaypointDistance = 3f;
    public bool movieScenePlaying = true;

    private Animator animator;
    private Rigidbody2D rb;
    private Seeker seeker;
    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;
    private float speed;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();

        speed = minSpeed;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }

        if (!movieScenePlaying && Vector3.Distance(target.transform.position, transform.position) > distanceRadius)
        {
            if (Vector3.Distance(target.transform.position, transform.position) > distanceRadius*1.5) {
                speed = maxSpeed;
            }
            else {

                speed = minSpeed;
            }


            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
    }

    private void UpdateAnimation()
    {
        Vector2 velocity = rb.velocity.normalized;

        if (velocity.magnitude != 0)
        {
            animator.SetFloat("moveX", velocity.x);
            animator.SetFloat("moveY", velocity.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void UpdatePath() {
        if (seeker.IsDone()) {
            seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }
}
