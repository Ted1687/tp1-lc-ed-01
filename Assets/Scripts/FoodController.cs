using UnityEngine;

public class FoodController : MonoBehaviour
{
  
    public float vitesseDeLancement = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          //rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * vitesseDeLancement * Time.deltaTime, Space.World);

        // on recupere la vue pour detruire la pizza
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1){
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {

            Debug.Log("en collision");
            Destroy(gameObject);

            GameObject animal = other.gameObject;
            //animal.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            AnimalController animalController = animal.GetComponent<AnimalController>();
            animalController.Manger();

        }
    }
}
