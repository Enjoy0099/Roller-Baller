using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;

    [SerializeField]
    private AudioSource coinSound;

    private void Awake()
    {
        /*if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }*/

        instance = this;
    }

    public void PlayCoinSound()
    {
        coinSound.Play();
    }
}
