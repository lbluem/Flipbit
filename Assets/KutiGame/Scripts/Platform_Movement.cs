using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour
{

    public float speed = 8;
    public float moveDirection = 0;
    // Start Position um da zurückkehren zu können
    public Vector3 startPosition;
    public bool turned;

      // Button Tracker
    private bool p1ButtonLeftUp = true;
    private bool p1ButtonRightUp = true;
    private bool p2ButtonLeftUp = true;
    private bool p2ButtonRightUp = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        turned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;
    }

    // Update is called once per frame
    void Update()
    {
        // Kann mir vorstellen, dass das zu taxing ist jede gefühlte Millisekunde
        // das Player Game Object zu finden. Bedarf evtl einer anderen Lösung
        turned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;

        // Ist ein RigidBody überhaupt nötig?
        //thisRB.velocity = new Vector2(speed*moveDirection, thisRB.velocity.y);

        GetMovement();
    }

    private void FixedUpdate() {
        /* if(transform.position.x < 9.3 && transform.position.x > -9.3)
        {
        } */
            transform.Translate(Vector2.right * speed * Time.deltaTime * moveDirection);        
    }


    private void GetMovement()
    {
        if(turned)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT))
            {
                moveDirection -= 1;
                p1ButtonLeftUp = false;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT))
            {
                moveDirection -= 1;
                p1ButtonRightUp = true;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT))
            {
                moveDirection += 1;
                p1ButtonLeftUp = true;
            }
            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT))
            {
                moveDirection += 1;
                p1ButtonRightUp = false;
            }
            if(p1ButtonLeftUp && p1ButtonRightUp)
            {
                moveDirection = 0;
            }
        }else
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT))
            {
                moveDirection += 1;
                p2ButtonLeftUp = false;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT))
            {
                moveDirection += 1;
                p2ButtonRightUp = true;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT))
            {
                moveDirection -= 1;
                p2ButtonLeftUp = true;
            }
            if(KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT))
            {
                moveDirection -= 1;
                p2ButtonRightUp = false;
            }
            if(p2ButtonLeftUp && p2ButtonRightUp)
            {
                moveDirection = 0;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
        }
        /* }else if(other.gameObject.tag == "Ground")
        {
            moveDirection = 0;
        } */
        /* else if(other.gameObject.tag == "Ground")
        {
            if(other.transform.position.x > transform.position.x)
            {
                //rechte wand wurde getroffen
                Debug.Log("RECHTE WAND GETROFFEN");
            }
        } */
    }

    private bool wallCollision(Collision2D other) 
    {
        Debug.Log("Wilde Sachen passieren");
        if(other.gameObject.tag == "Ground")
        {
            return true;
        }
        return false;
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }

}
