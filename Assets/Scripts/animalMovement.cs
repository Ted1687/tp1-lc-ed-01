using UnityEngine;

public class cowMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
