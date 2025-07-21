using UnityEngine;
using UnityEngine.AI;

public class EnemyBullet : MonoBehaviour
{

  
    NavMeshAgent agent;
    Transform target;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


        GameObject player = GameObject.FindWithTag("Player");
        
        if(player != null)
        {
            target = player.transform;
            agent.SetDestination(target.position);
        }

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null)
            {
                playerController.Damage();
            }

            Destroy(gameObject);
        }
    }


    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
        }
        
    }
}
