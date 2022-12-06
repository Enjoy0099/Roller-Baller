using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            GamePlay_Manager.instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagManager.PLAYER_TAG))
        {
            GamePlay_Manager.instance.GameOver();
        }
    }
}
