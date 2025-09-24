using UnityEngine;

public class AnimalsSpawnScript : MonoBehaviour
{

    public GameObject[] animalsPrefab; //Les animaux à faire spawn
  
    private static GameOverTrigger trigger;//trigger qui enclenche le gameOver

    public float initialDelay = 2f; //Delai de base. Delai avant la première apparition d'un animal

    public float nextDelay; //Délai avant la prochaine apparition

    private float progress; //Progression du temps, rénitialisé après chaque apparition.

    private float progressDifficulty;//Progression du temps, rénitialisé après 15s. Sert à augmenter la difficulté

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GameObject.Find("Player").GetComponent<GameOverTrigger>();
        nextDelay = initialDelay;
    }

    void SpawnAnimal()
    {
        //Les animaux n'apparaissent que pendant le jeu
        if (!trigger.gameOver)
        {
            GameObject a = animalsPrefab[Random.Range(0, animalsPrefab.Length)];//2 types d'animaux peuvent apparaitrent
            Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), 0, 10);//Ils apparaissent horizontalement à une position aléatoire

            //Rotation Aléatoire À voir
            Instantiate(a, spawnPos, a.transform.rotation);
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //Le temps progresse, après chaque 15 secondes le délai de base baisse ce qui augmente le taux d'apparition (Difficulté)
        progressDifficulty += Time.deltaTime;

        if ( progressDifficulty > 15f )
        {
            progressDifficulty = 0f;
            initialDelay = initialDelay * 0.95f;
            Debug.Log("Delai initial : " + initialDelay);
        }

        //Le temps progresse, au délai l'animal apparaît. Le prochain délai est calculé entre +/- 50% du délai de base
        progress += Time.deltaTime;

        if (progress > nextDelay)
        {
            progress = 0f;
            SpawnAnimal();

            nextDelay = Random.Range(0.50f * initialDelay, 1.50f * initialDelay);
        }
    }
}
