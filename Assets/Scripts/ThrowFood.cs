using UnityEngine;

public class ThrowFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject player;
    public float vitesseDeLancement = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject aLancer =  Instantiate(foodPrefab, new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z) , Quaternion.identity);
            Rigidbody rb = aLancer.GetComponent<Rigidbody>();

            //rb.useGravity = false;
            //transform.Translate(Vector3.forward * vitesseDeLancement * Time.deltaTime, Space.World);
        }

    }

    void Lancer()
    {
       

        
    }
}
