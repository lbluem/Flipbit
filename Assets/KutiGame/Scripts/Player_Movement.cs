using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D myRB;

    public float speed = 8;
    private float moveDirection;
    // flippt das Sprite 
    public bool turned = false;
    public float jumpStrength = 9;
    private int jumpDirection = 1;
    private bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        // Für den Fall das wir anfangen mit dem Spieler 2
        if(turned)
        {
            GravityTurn();
            turned = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(speed*moveDirection, myRB.velocity.y);

        if (!isJumping)
        {
            if(!turned)
            {
                if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID))
                {
                    myRB.velocity = Vector2.up * jumpStrength * jumpDirection;
                    isJumping = !isJumping;
                }
            }else{
                if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID))
                {
                    myRB.velocity = Vector2.up * jumpStrength * jumpDirection;
                    isJumping = !isJumping;
                }
            }
        }

        if(!turned)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT))
            {
                moveDirection = -1;
            }else if (KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT))
            {
                moveDirection = 1;
            }else if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT)||KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT))
            {
                moveDirection = 0;
            } 
        }else
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT))
            {
                moveDirection = -1;
            }else if (KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT))
            {
                moveDirection = 1;
            }else if(KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT)||KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT))
            {
                moveDirection = 0;
            }  
        }


        /* if(!turned)
        {
            if(myRB.position.y > 1)
            {
                GravityTurn();
            }
        }else
        {
            if (myRB.position.y < -1)
            {
                GravityTurn();
            }
        } */

    }


    public void GravityTurn()
    {
        moveDirection = 0;
        myRB.gravityScale *= -1;
        gameObject.transform.Rotate(180,0,0);
        turned = !turned;
        jumpDirection *= -1;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))   
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))    
        {
            isJumping = true;
        }
    }
}
