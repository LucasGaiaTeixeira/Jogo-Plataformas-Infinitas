using UnityEngine;

public class EnemiesFly : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocityX = -1 * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    

}
