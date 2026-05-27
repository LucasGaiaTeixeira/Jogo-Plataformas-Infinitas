using System.Collections.Generic;
using UnityEngine;


public class PlataformController : MonoBehaviour
{
    public GameObject initialPlatform;
    public List<GameObject> plataforms = new List<GameObject>();//lista de prefabs das plataformas
    private List<Transform> platformsClone = new List<Transform>();//clone das palaformas
    
    private float offsetPlatform;

    private Transform player;
    private Transform currentPlatform;//aqui e salvo o ponto final da plataforma atual para o player passar por ela e fazer movimentar a platafoma passada pra frente
    private int platformIndex;

    public float posicaoPlataformY;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//ele vai procurar na cena um gameobject com a tag Player

        Instantiate(initialPlatform, new Vector2(0,0), transform.rotation);
        offsetPlatform += 30f;

        for(int i = 0; i < plataforms.Count; i++)
        {
            Transform transformClone = Instantiate(plataforms[i], new Vector2(i * 30 + 30,posicaoPlataformY), transform.rotation).transform;
            platformsClone.Add(transformClone);
            offsetPlatform += 30f;
        }

        currentPlatform = platformsClone[platformIndex].GetComponent<Platform>().finalPointPlatform;

    }

    public void Update()
    {
        Move();
    }

    public void Move()
    {
        float pointFinalDistance = player.position.x - currentPlatform.position.x;
        if(pointFinalDistance >= 1.5)
        {
            recicle(platformsClone[platformIndex].gameObject);
            platformIndex++;
            //Debug.Log(platformIndex);

            if(platformIndex == platformsClone.Count)
            {
                platformIndex = 0;
            }
            
            currentPlatform = platformsClone[platformIndex].GetComponent<Platform>().finalPointPlatform;
            


        }
    }


    public void recicle(GameObject plataform)
    {
        plataform.transform.position = new Vector2(offsetPlatform, posicaoPlataformY);
        offsetPlatform += 30f;
    }

}
