using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    float m_CurrTime = 0;
    public float DelayAttackSec = 1f;
    void Fire1()
    {
        // 마우스를 누르고 있으면 1초에 한번씩 공격
        // 마우스를 누르고있다
        if (Input.GetMouseButton(0))
        {
            // 1초에 한번씩
            //Time.time; // 24일 이 최대

            if (m_CurrTime < Time.time)
            {
                Debug.Log("공격");
                m_CurrTime = Time.time + DelayAttackSec;
            }

        }

    }


    public float RemineSec = 0f;
    void UpdateFire2()
    {
        // 0.0001f -= 10f; // 2
        RemineSec -= Time.deltaTime;

        if (RemineSec <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                RemineSec = DelayAttackSec;
                Debug.Log("공격2");
                Attack();
            }
        }

    }

    public Transform EndBariel = null;

    [Header("[파티클용]")]
    public GameObject m_HitParticle = null;
    void Attack()
    {
        //// 총기류
        //Physics.OverlapBox();
        //Physics.OverlapCapsule();
        //Physics.OverlapSphere();


        Vector3 endlinepos = EndBariel.position + EndBariel.forward * 100f;
        RaycastHit hit;
        // fps 게임 총알 공격 
        if ( Physics.Raycast(EndBariel.position
            , EndBariel.forward
            , out hit) )
        {
            // 레이저와 부딪힌 오브젝트 이름 출력
            Debug.Log( $"{hit.transform.name }" );
            endlinepos = hit.point;

            // 파티클 생성
            //GameObject originalparticl = Resources.Load<GameObject>("GunParticles");
            GameObject cloneparticle = GameObject.Instantiate(m_HitParticle);
            cloneparticle.transform.position = hit.point;
            // 파티클 회전
            //cloneparticle.transform.rotation = Quaternion.LookRotation(-transform.forward);
            // hit 안의 노멀값 활용
            cloneparticle.transform.rotation = Quaternion.LookRotation(hit.normal);
            GameObject.Destroy(cloneparticle, 5f);


            // 적을 알아내야지
            // SetDamage(1f);
            EnemyHPStat hpstat = hit.transform.GetComponent<EnemyHPStat>();

            if ( hpstat != null )
            {
                hpstat.SetDamage(1f);
            }
            
        }

        //Debug.DrawLine(EndBariel.position
        //    , EndBariel.position + EndBariel.forward * 100f
        //    , Color.red, 2f);

        // 라인 그리기
        // 0.1초뒤 사라지도록 하기
        m_LinkLineRender.gameObject.SetActive(true);
        m_LinkLineRender.SetPosition(0, EndBariel.position);
        m_LinkLineRender.SetPosition(1, endlinepos );

        m_LineDurationSec = LineShowSec;
    }

    // 시간 적용
    // 업데이트에서 적용된 시간 빼기
    // 시간이 0이되면 setactive(false) 하기
    // 다른 조건도 적용 해서 
    [Header("[라인용]")]
    public float m_LineDurationSec = 0f;
    public float LineShowSec = 0.2f;


    public LineRenderer m_LinkLineRender = null;

    void Start()
    {
        m_CurrTime = Time.time; // 1초
    }


    void Update()
    {
        //Fire1();
        UpdateFire2();

        m_LineDurationSec -= Time.deltaTime;
        if(m_LineDurationSec <= 0f
            && m_LinkLineRender.gameObject.activeInHierarchy )
        {
            m_LinkLineRender.gameObject.SetActive(false);
        }
    }



}
