using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    float maxDisplacement = 0.1f,
    playerPersonalSpaceRadius = 3f,
    enemyReactionTime = 0.2f,
    dashStrenght = 8;


    bool isEnemyDashing;    

    UnityEngine.Vector2 playerToGoalDirection;
    UnityEngine.Vector2 playerPosition;
    UnityEngine.Vector2 enemyPosition;
    UnityEngine.Vector2 currentBallDestination;

    UnityEngine.Vector2 closestGoalPosition;

    void OnEnable()
    {
        player = GameObject.Find("Player");
        closestGoalPosition = GameObject.FindObjectOfType<Goal>().closestGoal;
    }

    void FixedUpdate()
    {
        closestGoalPosition = GameObject.FindObjectOfType<Goal>().closestGoal;   
        
        if(!isEnemyDashing)
        {
            if(player.GetComponent<Rigidbody2D>().velocity != UnityEngine.Vector2.zero)
            {
                StartCoroutine(SetPositionForDash());
            }

            if(enemyPosition == currentBallDestination)
            {
                GetComponent<Rigidbody2D>().velocity = UnityEngine.Vector2.zero;
                StartCoroutine(Dash());
            }
        }
    }

    IEnumerator Dash()
    {
        isEnemyDashing = true;
        GetComponent<Rigidbody2D>().AddForce(playerToGoalDirection * dashStrenght);
        yield return new WaitForSeconds(2);
        isEnemyDashing = false;

    }

    IEnumerator SetPositionForDash()
    {
        yield return new WaitForSeconds(enemyReactionTime);

        playerPosition = new UnityEngine.Vector2(player.transform.position.x,player.transform.position.y);
        enemyPosition = new UnityEngine.Vector2(transform.position.x,transform.position.y);

        UnityEngine.Vector2 goalPosition = closestGoalPosition;

        // Calculate player To goal vector.
        playerToGoalDirection = (goalPosition - playerPosition).normalized * playerPersonalSpaceRadius;

        currentBallDestination = playerPosition - playerToGoalDirection;

        if(UnityEngine.Vector2.Distance(playerPosition,enemyPosition) > playerPersonalSpaceRadius)
        {
            yield return new WaitForSeconds(0.1f);
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position,currentBallDestination,maxDisplacement);
        }
    }
}
