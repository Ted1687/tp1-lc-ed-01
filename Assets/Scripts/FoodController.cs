using UnityEngine;

public class FoodController : MonoBehaviour
{
  
    public float vitesseDeLancement = 5f; //Vitesse de déplacement de la nourriture après lancer

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
    }
    // Update is called once per frame
    void Update()
    {
        //Il se déplace en haut de l'écran
        transform.Translate(Vector3.back * vitesseDeLancement * Time.deltaTime, Space.World);

        //Destruction de la nourriture lorsqu'il sort de la vue de la caméra
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1){
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //La nourriture entre en contact avec un animal
        if (other.CompareTag("Animal"))
        {
            //Il est détruit
            Destroy(gameObject);

            //L'animal est nourrit
            GameObject animal = other.gameObject;
            AnimalController animalController = animal.GetComponent<AnimalController>();
            animalController.Manger();

        }
    }
}
