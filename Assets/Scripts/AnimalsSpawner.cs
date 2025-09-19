using UnityEngine;

public class AnimalsSpawnScript : MonoBehaviour
{

    public GameObject[] animalsPrefab;
    PlayerController playerControllerSript;
    GameOverTrigger trigger;

    
    public float initialDelay = 30f;
    public float nextDelay;
    public float progress;
    public float progressDifficulty;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GameObject.Find("Player").GetComponent<GameOverTrigger>();
        nextDelay = initialDelay;
    }

    void SpawnAnimal()
    {
        if (!trigger.gameOver)
        {
            GameObject a = animalsPrefab[Random.Range(0, animalsPrefab.Length)];
            Vector3 spawnPos = new Vector3(Random.Range(-6f, 6f), 0, 5);
            //Rotation Aléatoire
            Instantiate(a, spawnPos, a.transform.rotation);
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        

        progressDifficulty += Time.deltaTime;

        if ( progressDifficulty > 15f )
        {
            progressDifficulty = 0f;
            initialDelay = initialDelay * 0.95f;
            Debug.Log("Delai initial : " + initialDelay);
        }

        progress += Time.deltaTime;

        if (progress > nextDelay)
        {
            progress = 0f;
            SpawnAnimal();

            nextDelay = Random.Range(0.50f * initialDelay, 1.50f * initialDelay);
        }
    }
}
