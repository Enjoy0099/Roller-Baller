using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MainMenu : MonoBehaviour
{
    [SerializeField]
    private float minMoveSpeed = 0.5f, maxMoveSpeed = 2f;

    private float moveSpeed;

    [SerializeField]
    private float minDistance = 0.5f;

    private float distance;

    [SerializeField]
    private Transform[] movingPoints;

    private Transform target;


    private void Start()
    {
        target = movingPoints[Random.Range(0, movingPoints.Length)];
        SetMoveSpeed();
    }

    private void Update()
    {
        transform.LookAt(target);

        distance = Vector3.Distance(transform.position, target.position);

        if(distance > minDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            target = movingPoints[Random.Range(0, movingPoints.Length)];
        }
    }

    void SetMoveSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }


}




