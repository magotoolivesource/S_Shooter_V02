using UnityEngine;
using UnityEngine.AI;

[RequireComponent( typeof( NavMeshAgent ) )]
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyTarget : MonoBehaviour
{
    public Transform Target;
    [SerializeField]
    protected NavMeshAgent m_LinkAgent;
    
    void Start()
    {
        m_LinkAgent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        m_LinkAgent.SetDestination(Target.position);

    }
}
