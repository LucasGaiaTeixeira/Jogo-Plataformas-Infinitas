using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //nao tem uma variavel de Camera porque a camera segue o transform do gameObject então, nao precisa referenciar a camera, a não ser que queria mecher algo a mais nela sem ser o transform
    private Transform player;
    public float cameraSpeed;//e bom ser um valor muito alto para a camera focar bem o personagem e com time.deltaTime ainda fica frame por frema parou de tremer quando coloquei 500
    
    public float offSetCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()//LateUpdate é melhor para movimentação de camera porque ele é chamado depois de todos os Update, ou seja, ele vai seguir o player depois que o player se movimentar, evitando assim um efeito de lag na camera
    {
        Vector3 positionPlayer = new Vector3(player.position.x + offSetCamera, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, positionPlayer, cameraSpeed * Time.deltaTime);
    }
}
