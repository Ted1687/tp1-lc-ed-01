using UnityEngine;

public class AnimalsSpawnScript : MonoBehaviour
{

    public GameObject animalPrefab;
    public float tempsApparition = 2f;
    public float delaiInitial = 1f;
    public float posBase = 13.71f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("apparaitreAnimaux", delaiInitial, tempsApparition);
    }

    void apparaitreAnimaux()
    {
        Instantiate(animalPrefab, new Vector3(posBase, 1.9073f, 1.79f), Quaternion.identity);
        posBase += 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
