using UnityEngine;

public class AnimalsSpawnScript : MonoBehaviour
{

    public GameObject animalPrefab;
    PlayerController playerControllerSript;

    public float tempsApparition = 2f;
    public float delaiInitial = 1f;
    

    public Vector3 spawnPos = new Vector3(13, 0, -10);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerSript = GameObject.Find("Player").GetComponent<PlayerController>();
        //InvokeRepeating("apparaitreAnimaux", delaiInitial, tempsApparition);
    }

    void apparaitreAnimaux()
    {
        if (!playerControllerSript.gameOver)
        Instantiate(animalPrefab, spawnPos, animalPrefab.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
