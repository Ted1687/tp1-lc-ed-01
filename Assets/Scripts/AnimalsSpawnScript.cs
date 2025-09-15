using UnityEngine;

public class AnimalsSpawnScript : MonoBehaviour
{

    public GameObject animalPrefab;
    public float tempsApparition = 2f;
    public float delaiInitial = 1f;
    public float posBase = 2.34f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("apparaitreAnimaux", delaiInitial, tempsApparition);
    }

    void apparaitreAnimaux()
    {
        Instantiate(animalPrefab, new Vector3(posBase, 0, -0.39f), animalPrefab.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
