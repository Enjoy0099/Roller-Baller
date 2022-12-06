using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void Start()
    {
        GamePlay_Manager.instance.SetCoinCount(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagManager.PLAYER_TAG))
        {

            GamePlay_Manager.instance.SetCoinCount(-1);
            Audio_Manager.instance.PlayCoinSound();
            gameObject.SetActive(false);   
        }
    }
}
