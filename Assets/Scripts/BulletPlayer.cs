using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public GameObject explosionPrefabAnimation;

    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    private void FixedUpdate()
    {
        rig.linearVelocity = Vector2.right * speed;
    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("enemy") || collider.gameObject.layer == 3)
        {  
            onHit();
        }
        
    }


    public void onHit()
    {
        Instantiate(explosionPrefabAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
