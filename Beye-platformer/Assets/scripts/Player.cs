using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 5.0f;
    [SerializeField] float climbSpeed = 5.0f;
    [SerializeField] Vector2 deathSeq = new Vector2(25f, 25f);

    CapsuleCollider2D playerBodyCollider;
    Rigidbody2D playerCharacter;
    Animator playerAnimator;
    BoxCollider2D playerFeetCollider;

    float gravityScaleAtStart;

    bool isAlive = true;

    int keysgot = 0;



    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();

        gravityScaleAtStart = playerCharacter.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }


        Die();
        Run();
        FlipSprite();
        Jump();
        Climb();
        Checkkey();
        Checklock(keysgot);

    }

    private void Run()
    {
        // Value between -1 to +1
        float hMovement = Input.GetAxis("Horizontal");
        Vector2 runVelocity = new Vector2(hMovement * runSpeed, playerCharacter.velocity.y);
        playerCharacter.velocity = runVelocity;

        playerAnimator.SetBool("run", true);
        
        bool hSpeed = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;

        playerAnimator.SetBool("run", hSpeed);

        print(runVelocity);
    }

    private void FlipSprite()
    {
        // If the player is moving horizontally
        bool hMovement = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;

        if(hMovement)
        {
            //Reverse the current scaling of the x-axis
            transform.localScale = new Vector2(Mathf.Sign(playerCharacter.velocity.x), 1f);
        }
    }

    private void Jump()
    {
        if (!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //Will stop this method unless true
            return;
        }

        if(Input.GetButtonDown("Jump")) 
        {
            //Get new y velocity based on controllable variable
            Vector2 jumpVelocity = new Vector2(0.0f, jumpSpeed);
            playerCharacter.velocity += jumpVelocity;
        }
    }

    private void Climb()
    {
        if (!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            playerAnimator.SetBool("climb", false);
            playerCharacter.gravityScale = gravityScaleAtStart;
            //Will stop this method unless true
            return;
        }


        // "Vertical" from input axes
        float vMovement = Input.GetAxis("Vertical");
        // X needs to remainthe same and we need to change Y
        Vector2 climbVelocity = new Vector2(playerCharacter.velocity.x, vMovement * climbSpeed);
        playerCharacter.velocity = climbVelocity;

        playerCharacter.gravityScale = 0.0f;
        bool vSpeed = Mathf.Abs(playerCharacter.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("climb", vSpeed);
    }

    private void Die()
    {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            playerAnimator.SetTrigger("die");
            GetComponent<Rigidbody2D>().velocity = deathSeq;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

    private void Checkkey()
    {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("key")))
        {
            keysgot = keysgot + 1;
        }
    }

    private void Checklock(int key)
    {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("lock")))
        {
            if (key == 3)
            {

            }
            if (!(key == 3))
            {

            }
        }
    }

}
