using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour
{

    public float speed = 8;
    private float moveDirection = 0;
    // Start Position um da zurückkehren zu können
    public Vector3 startPosition;
    public bool turned;

    // Grenzen sind (erstmal) hard gecodet
    public float leftBorder = -10;
    public float rightBorder = 10;

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

        transform.Translate(Vector2.right * speed * Time.deltaTime * moveDirection);

       

        // Hier wird sich der Reset widerfinden
        /* if(!turned)
        {
            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID))
            {
                
            }
        }else{
            if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID))
            {
                
            }
        } */

        if(turned)
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

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
        }else if(other.gameObject.tag == "Ground")
        {
            moveDirection = 0;
        }
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
        if(other.gameObject.tag == "Ground")
        {
            return true;
        }
        return false;
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        other.transform.SetParent(null);
    }

}
