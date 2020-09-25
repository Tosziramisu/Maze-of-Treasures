using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [Range(0.1f, 25f)] [SerializeField] protected float range;
    [SerializeField] protected Light spotLight;
    protected float viewAngle;
    protected Color basicColor;

    [SerializeField] private EnemyStateMachine stateMachine = default;
    [SerializeField] private PlayerAwareState playerAwareState = default;

    private IEnumerator Start()
    {
        viewAngle = spotLight.spotAngle;
        basicColor = spotLight.color;
        while (true)
        {
            yield return new WaitUntil(CalculatePlayerPosition);
            yield return InitiateFollowingState();
        }
    }

    private IEnumerator InitiateFollowingState()
    {
        stateMachine.SetState(playerAwareState);
        yield return new WaitForSeconds(0.3f);
    }

    private bool IsPlayerVisible()
    {
        float angleBetweenEnemyAndPlayer = Vector3.Angle(playerAwareState.Direction, transform.forward);

        if (angleBetweenEnemyAndPlayer <= viewAngle / 2 && playerAwareState.DistanceBetweenEnemyAndPlayer <= range)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, playerAwareState.Direction, out hit))
            {
                if(hit.transform.position == playerAwareState.playerPosition)
                {
                    playerAwareState.isPlayerStillVisible = true; 
                    spotLight.color = Color.red;
                    return true;
                }
            }
        }
        playerAwareState.isPlayerStillVisible = false;
        spotLight.color = basicColor;
        return false;
    
    }
    
    private bool CalculatePlayerPosition()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.tag == "Player")
            {
                playerAwareState.playerPosition = hitCollider.transform.position;
                if(IsPlayerVisible())
                    return true;
            }
        }
        return false;
    }
       
        
        

}
