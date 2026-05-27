using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]private Animator playerAnimation;
    private PlayerMovimento playerMovimentoAnimation;
    
    void Start()
    {
        playerMovimentoAnimation = GetComponent<PlayerMovimento>();
    }

    void Update()
    {
        
        if (playerMovimentoAnimation.PodePular)
        {
            
            playerAnimation.SetBool("jump", false);
        }
        else
        {
            playerAnimation.SetBool("jump", true);
        }

        if (playerMovimentoAnimation.PlayerMovendo)
        {
            
            playerAnimation.SetBool("walk", true);
        }
        else
        {
            playerAnimation.SetBool("walk", false);
        }

    }


}
