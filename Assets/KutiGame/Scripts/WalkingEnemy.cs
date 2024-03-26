using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{

    // Managing the movement of the walking Enemy type

    public Transform thisEnemy;
    // Setting boundaries
    public Transform leftEnd, rightEnd;

    public float speed = 4;

    UnityEngine.Vector2 currentTarget;

    public bool isUpsideDown = false;

    private void Start() 
    {
        currentTarget = rightEnd.position;   
        if(isUpsideDown)
        {
            UnityEngine.Vector2 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Vector2.Distance(thisEnemy.position,leftEnd.position)< 0.1f) currentTarget = rightEnd.position;
        if(UnityEngine.Vector2.Distance(thisEnemy.position,rightEnd.position)< 0.1f) currentTarget = leftEnd.position;

        thisEnemy.position = UnityEngine.Vector2.MoveTowards(thisEnemy.position, currentTarget, speed * Time.deltaTime);
    }

    // To visualize the path of the enemy
    private void OnDrawGizmos() 
    {
        if(leftEnd != null && rightEnd != null)
        {
            Gizmos.DrawLine(thisEnemy.position, leftEnd.position);
            Gizmos.DrawLine(thisEnemy.position, rightEnd.position);    
        }else
        {
            Debug.LogWarning("WalkingEnemy: Cant draw Gizmo. Left and or Right End not set!");
        }
    }
}
