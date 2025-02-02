using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    // 플레이어가 2미만 거리일때 공격처리
    // 공격중 거리가 2이상이되면 공격취소
    // 플레이어에게 공격할때 2초에 한번씩 공격 처리


    public LayerMask AttackLayerMask;
    void UpdateAttack()
    {
        LayerMask codemask = LayerMask.GetMask("Player");
        //this.transform.position;
        Collider[] collarr = Physics.OverlapSphere(transform.position
            , 2f
            , codemask); 
        for (int i = 0; i < collarr.Length; i++)
        {
            if(collarr[i].tag == "Player"
                && collarr[i].transform.GetComponent<PlayerMove>() )
            {


            }
        }

    }


    public Transform Target;
    protected PlayerStat TargetStat;
    void Start()
    {
        // 오브젝트 이름으로찾기
        //GameObject obj = GameObject.Find("Player111");
        // tag타입으로 찾기
        //GameObject obj = GameObject.FindGameObjectWithTag("Player");
        //GameObject[] objarr = GameObject.FindGameObjectsWithTag("Player");

        // 컴포넌트 타입으로 찾기
        TargetStat = GameObject.FindFirstObjectByType<PlayerStat>();
        //GameObject.FindObjectsByType<PlayerStat>()

        
    }

    public float AttackDealySec = 1f;
    protected float m_AttackCurrentSec = 0f;
    void UpdateAttack2()
    {
        m_AttackCurrentSec -= Time.deltaTime;
        Vector3 vec = TargetStat.transform.position - transform.position;
        if( vec.magnitude <= 2f
            && m_AttackCurrentSec <= 0f )
        {
            Debug.Log($"{name} -> 공격 -> 플레이어");
            TargetStat.SetDamage(1);
            m_AttackCurrentSec = AttackDealySec;
        }
    }

    void Update()
    {
        if( false)
        {
            //UpdateAttack();
        }
        else
        {
            UpdateAttack2();
        }

        

    }
}
