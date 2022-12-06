using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;

    [SerializeField]
    private float distance = 10f;

    [SerializeField]
    private float cameraHeight = 5f;

    [SerializeField]
    private float heightDamping = 2f;

    private float wantedHeight, currentHeight;

    private Quaternion currentRotation;

    private void Awake()
    {
        playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate()
    {
        if (!playerTarget) return;

        wantedHeight = playerTarget.position.y + cameraHeight;

        currentHeight = transform.position.y;

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, 
            heightDamping * Time.deltaTime);

        currentRotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);

        transform.position = playerTarget.position;
       
        //transform.position -= Vector3.forward * distance;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x,
            currentHeight, transform.position.z);

        transform.LookAt(playerTarget);
    }
}
