using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 20f;

    [SerializeField]
    private bool useTorque;

    [SerializeField]
    private float maxAngularVelocity = 0.25f;

    [SerializeField]
    private float jumpForce = 20f;

    [SerializeField]
    private float groundCheckRayLenght = 1f;

    private Rigidbody mybody;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody>();
        mybody.maxAngularVelocity = maxAngularVelocity;
    }

    public void Move(Vector3 moveDirection)
    {
        if (useTorque)
        {
            mybody.AddTorque(new Vector3(moveDirection.z, 0f, -moveDirection.x)*moveForce);
        }
        else
        {
            mybody.AddForce(moveDirection * moveForce);
        }
    }

    public void Jump(bool jump)
    {
        if(Physics.Raycast(transform.position, Vector3.down, groundCheckRayLenght) && jump)
        {
            mybody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
