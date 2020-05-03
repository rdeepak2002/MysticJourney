using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KyubueMovement : MonoBehaviour
{
    public float distanceRadius;
    public float minSpeed;
    public float maxSpeed;
    //public GameObject target;

    private Vector3 change;
    private Animator animator;

    private float currentSpeed;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();

        currentSpeed = minSpeed;
    }

    // Update is called once per frame
    void Update() {
        //change = Vector3.zero;

        //UpdateAnimationAndMove();
    }

    //void UpdateAnimationAndMove()
    //{
    //    if (change != Vector3.zero)
    //    {
    //        animator.SetFloat("moveX", change.x);
    //        animator.SetFloat("moveY", change.y);
    //        animator.SetBool("moving", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("moving", false);
    //    }
    //}
}
