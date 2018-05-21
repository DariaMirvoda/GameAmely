using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmeliWalk : MonoBehaviour
{

    private Animator anim;

    private bool isWalking;
    private float walkSpeed, walkTime, distance;
    private Vector3 pointA, pointB;
    private Action onWalkEnd;

    private bool isTurning;
    private float turnSpeed, turnProgress;
    private Quaternion rotationA, rotationB;
    private Action onTurnEnd;


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (isWalking)
        {
            float totalTime = distance / walkSpeed;
            float progress = walkTime / totalTime;
            transform.position = Vector3.Lerp(pointA, pointB, progress);
            walkTime += Time.deltaTime;
            if (progress >= 1)
            {
                isWalking = false;
                anim.SetBool("IsWalking", false);
                if (onWalkEnd != null)
                {
                    onWalkEnd();
                }
            }
        }


        if (isTurning)
        {
            transform.localRotation = Quaternion.Lerp(rotationA, rotationB, turnProgress);
            turnProgress += Time.deltaTime * turnSpeed;
            if (turnProgress >= 1)
            {
                isTurning = false;
                if (onTurnEnd != null)
                {
                    onTurnEnd();
                }
            }
        }
    }


    public void StartWalking(Vector3 pointA, Vector3 pointB, float speed, Action onWalkEnd)
    {
        isWalking = true;
        walkTime = 0;
        walkSpeed = speed;
        this.pointA = pointA;
        this.pointB = pointB;
        this.onWalkEnd = onWalkEnd;
        distance = Vector3.Distance(pointA, pointB);
        anim.SetBool("IsWalking", true);
    }


    public void StartRotating(Quaternion rotationA, Quaternion rotationB, float speed, Action onTurnEnd)
    {
        isTurning = true;
        turnProgress = 0;
        turnSpeed = speed;
        this.rotationA = rotationA;
        this.rotationB = rotationB;
        this.onTurnEnd = onTurnEnd;
    }
}
