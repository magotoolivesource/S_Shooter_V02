using UnityEngine;
using UnityEngine.AI;

[RequireComponent( typeof( NavMeshAgent ) )]
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyTarget : MonoBehaviour
{
    public Transform Target;
    [SerializeField]
    protected NavMeshAgent m_LinkAgent;
    [SerializeField]
    protected Animator m_Animator;
    
    void Start()
    {
        m_LinkAgent = GetComponent<NavMeshAgent>();

        m_PrevPos = transform.position;

        m_Animator = GetComponent<Animator>();
    }

    #region 원론직인 이동처리방법
    public bool UpdatePos = false;
    protected Vector3 m_PrevPos;
    void UpdateMovePos()
    {
        // 원론적인 방법
        Vector3 deltapos = transform.position - m_PrevPos;
        m_PrevPos = transform.position;
        
        if (deltapos.magnitude <= 0f) { UpdatePos = false; }
        else { UpdatePos = true; }
    }
    #endregion

    public Vector3 TargetVelocity;

    void UpdateMoveAnimation()
    {

        if (m_LinkAgent.velocity.magnitude <= 0f)
        {
            // 멈췄다
            m_Animator.SetBool("EnemyMove", false);
        }
        else
        {
            float anispeed = m_LinkAgent.speed / 2.5f;
            m_Animator.SetFloat("AniSpeed", anispeed);
            // 움직임
            m_Animator.SetBool("EnemyMove", true);
        }

    }

    void Update()
    {
        if( m_LinkAgent.enabled )
        {
            m_LinkAgent.SetDestination(Target.position);
        }
        

        UpdateMoveAnimation();
        

        //m_LinkAgent.path

        //UpdateMovePos();


    }
}
