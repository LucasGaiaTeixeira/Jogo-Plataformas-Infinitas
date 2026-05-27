using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float xAxis;
    public float yAxis;

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }
}
