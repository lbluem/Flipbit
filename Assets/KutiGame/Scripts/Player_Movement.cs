using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Animator _animator;

    private float horizontal = 0f;

    public float speed = 12f;
    private float moveDirection;
    // flippt das Sprite 
    public bool turned = false;
    public float jumpStrength = 19;
    private int jumpDirection = 1;
    private bool inAir = false;
    private bool isFacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        // Für den Fall das wir mit dem Spieler 2 anfangen
        if(turned)
        {
            GravityTurn();
            turned = true;
        }

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Flip();

        if(!turned)
        {
            CalculateHorizontal(1);

            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID) && IsGrounded())
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, jumpStrength);
                inAir = true;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_MID) && myRB.velocity.y > 0f)
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
                inAir = true;
            }

        }else
        {
            CalculateHorizontal(2);

            if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID) && IsGrounded())
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, -jumpStrength);
                inAir = true;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P2_MID) && myRB.velocity.y < 0f)
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
                inAir = true;
            }
        }

        _animator.SetBool("isJumping", !IsGrounded());


        if(IsGrounded() && inAir)
        {
            _animator.SetBool("isLanding", true);
            inAir = false;
            //Debug.Log("is jelandet");
        }else
        {
            _animator.SetBool("isLanding", false);
        }

    }

    private void FixedUpdate() 
    {
        myRB.velocity = new Vector2(horizontal * speed, myRB.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void CalculateHorizontal(int player)
    {

        // Eleganter wäre eine "activePlayer" Variable die zwischen
        // EKutiButton.P1.. und EKutiButton.P2.. swapped
        // die if Abfragen anpassen und damit sollte Code gespart werden

        if(player == 1)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT))
            {
                horizontal -= 1;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT))
            {
                horizontal += 1;
            }
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT))
            {
                horizontal += 1;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT))
            {
                horizontal -= 1;
            }
        }else if(player == 2)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT))
            {
                horizontal += 1;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT))
            {
                horizontal -= 1;
            }
            if (KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT))
            {
                horizontal -= 1;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT))
            {
                horizontal += 1;
            }
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

    }

    public void GravityTurn()
    {
        GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<Platform_Movement>().moveDirection = 0;
        // moveDirection = 0;
        //horizontal = 0;
        myRB.gravityScale *= -1;
        gameObject.transform.Rotate(180,0,0);
        turned = !turned;
        //jumpDirection *= -1;
    }

}
