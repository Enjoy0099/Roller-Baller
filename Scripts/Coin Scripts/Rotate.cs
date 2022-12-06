using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 100f;

    [SerializeField]
    private bool rotateX, rotateY, rotateZ;

    private void Start()
    {
        rotateSpeed = Random.Range(100f, 150f);
    }

    private void Update()
    {
        if(rotateX)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
        }

        if (rotateY)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }

        if (rotateZ)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        }
    }
}
