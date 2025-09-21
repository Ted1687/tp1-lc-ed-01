using System;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public bool gameOver = false; //Indique le gameOver 
    public AudioSource cameraAudioSource; //Composant Audio de la camera
    public AudioClip gameOverClip;//Bande son de fon du jeu
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //À la collision du joueur avec un animal
        if (collision.gameObject.CompareTag("Animal"))
        {
            gameOver = true;//Le gameOver est enclenché

            //La bande son de game over est activé
            jouerSoundGameOver();

        }
    }

    public void jouerSoundGameOver()
    {
        if (cameraAudioSource != null && gameOverClip != null && gameOver)
        {
            cameraAudioSource.clip = gameOverClip;
            cameraAudioSource.Play();
        }
    }
}
