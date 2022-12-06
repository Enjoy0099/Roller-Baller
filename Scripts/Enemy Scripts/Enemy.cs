using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float minMoveSpeed = 1f, maxMoveSpeed = 4f;

    private float moveSpeed;

    [SerializeField]
    private float minDistance = 1f;

    private float distance;

    private Transform playerTarget;

    private void Awake()
    {
        playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void Start()
    {
        SetMoveSpeed();
    }

    private void Update()
    {
        if (!playerTarget)
            return;

        transform.LookAt(playerTarget);

        distance = Vector3.Distance(transform.position, playerTarget.position);

        if(distance > minDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    void SetMoveSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    public void SetTarget(Transform target)
    {
        playerTarget = target;
    }
}
