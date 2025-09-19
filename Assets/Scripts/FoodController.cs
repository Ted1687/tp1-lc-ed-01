using UnityEngine;

public class FoodController : MonoBehaviour
{
  
    public float vitesseDeLancement = 5f;
    public BoxCollider collider;
   private AnimalController animalController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        animalController = GameObject.FindWithTag("Animal").GetComponent<AnimalController>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * vitesseDeLancement * Time.deltaTime, Space.World);

        // on recupere la vue pour detruire la pizza
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
            {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal")) {

            //Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), animalController.GetComponent<BoxCollider>());

            Debug.Log("en collision");
            Destroy(gameObject);
            animalController.Manger();

            

            
        }

    }


    

}
