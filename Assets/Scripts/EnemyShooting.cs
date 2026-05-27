using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bomb;
    public Transform shootPoint;

    private float TimeForShooting;
    public float forShooting;

    

    // Update is called once per frame
    void Update()
    {
        TimeForShooting += Time.deltaTime;
        
        if(TimeForShooting >= forShooting)
        {
            TimeForShooting = 0;
            Instantiate(bomb, shootPoint.position, transform.rotation);
        }
    }
}
