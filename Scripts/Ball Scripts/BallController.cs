using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private BallPlayer ball;

    private Vector3 moveDirection;
    private bool jump;

    [SerializeField]
    private GameObject explosionParticale;

    private float moveHorizontal, moveVertical;

    private void Awake()
    {
        ball = GetComponent<BallPlayer>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxis(TagManager.HORIZONTAL_AXIS);
        moveVertical = Input.GetAxis(TagManager.VERTICAL_AXIS);

        jump = Input.GetKeyDown(KeyCode.Space);

        moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized; 
    }

    private void FixedUpdate()
    {
        ball.Move(moveDirection);
        ball.Jump(jump);
    }

    public void DestroyPlayer()
    {
        Instantiate(explosionParticale, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
