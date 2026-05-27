using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovimento : MonoBehaviour
{
    private Vector2 movimento;
    private Rigidbody2D rig;
    public bool jump;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    public GameObject prefabBullet;
    public Transform shootPoint;
    private static PlayerMovimento playerMovimento;//somente para o playerAnimation
    public bool PlayerMovendo { get;  private set; } // somente em player moviment
    public bool PodePular { get; private set; }

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerMovimento = this;
    }


    public void FixedUpdate()
    {
        rig.linearVelocity = new Vector2(movimento.x * velocidade, rig.linearVelocity.y);
        // o rig.linearVelocity.y é para manter a velocidade do pulo, ou seja, o jogador não perde a força do pulo quando se movimenta para os lados, manter o valor padrao do rigdBody2d
        if (jump)
        {
            rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            jump = false;
            
        }
    }

    public void direitaEsquerda(InputAction.CallbackContext context)
    {
        movimento = context.ReadValue<Vector2>();
        if (context.performed)
        {    
            PlayerMovendo = true;
        }else if (context.canceled)
        {
            PlayerMovendo = false;
        }

    }

    public void pular(InputAction.CallbackContext context)
    {
        if (context.performed && PodePular)
        {
            jump = true;
        }
        
    }

    public void atirar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(prefabBullet, shootPoint.position,transform.rotation);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            PodePular = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            PodePular = false;
        }
    }
}
