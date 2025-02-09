using UnityEngine;

public class Tower_Attack : MonoBehaviour
{

    //// OnCollisionEnter
    //// 2오브젝트 충돌하면 OnCollisionEnter
    //// 조건 오브젝트들 마다 조건이 충족되어야지 사용할수 있음
    //// 각각의 오브젝트에 Collider(Box, Sphare, Capsule )
    //// 둘중에 1개라도 RididBody있어야 호출이됨
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log( $"충돌됨 확인 : {collision.transform.name}");
    //}



    public Transform Attack_Target;
    // 조건 오브젝트들 마다 조건이 충족되어야지 사용할수 있음
    // 각각의 오브젝트에 Collider(Box, Sphare, Capsule )
    // Collider 에서 isTrigger 가 1개 선택되면 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log( $"트리거 확인 : {other.name}");
        //this.name

        if( other.tag == "Throw")
        {
            return;
        }

        if(Attack_Target == null)
        {
            Attack_Target = other.transform;
        }

        // overlap
        //Physics.OverlapBox
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Throw")
            return;

        Attack_Target = null;
    }




    // 1.범위안에 목표가 있게되면 목표 찾기 -- OnTriggerEnter()
    // 2.목표 위치로 회전
    // 3.목표에게 발사처리
    // 4.목표에게 1초에 한번씩 발사
    // 5.목표가 범위 벗어나면 다음 목표 찾기
    // 6.범위안에 목표가 없으면 대기


    void UpdateTargetLookRotation()
    {
        if (Attack_Target == null)
            return;


        // 유니티에서 제공되는 방법
        Quaternion yrot_qut = Quaternion.LookRotation(Attack_Target.position - transform.position
            , new Vector3(0f, 1f, 0f));

        // atan2 


        this.transform.rotation = yrot_qut;

        //float yrot = 0;
        //this.transform.rotation = Quaternion.Euler(0f, yrot, 0f);
    }


    // 1초에 한번씩 발사
    public float DealySec = 1f;
    protected float m_RemineSec = 0;
    void UpdateAttack()
    {

        m_RemineSec -= Time.deltaTime;

        if (Attack_Target == null)
        {
            return;
        }

        
        if(m_RemineSec <= 0)
        {
            m_RemineSec = DealySec;
            Debug.Log("발사");
            AttackThrow();
        }
    }


    public GameObject ThrowArrow;

    public Transform ThrowPos;
    public float ThrowPower = 300;
    void AttackThrow()
    {
        // 발사체 복사
        GameObject cloneobj = GameObject.Instantiate(ThrowArrow);

        cloneobj.transform.position = ThrowPos.position;
        cloneobj.transform.rotation = this.transform.rotation;
        cloneobj.SetActive(true);

        Throw_Line throwline = cloneobj.GetComponent<Throw_Line>();
        throwline.ThrowPower = ThrowPower;

        //Rigidbody body = cloneobj.GetComponent<Rigidbody>();
        //body.AddForce(ThrowPos.forward * ThrowPower);

        GameObject.Destroy(cloneobj, 5f);
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateTargetLookRotation();
        UpdateAttack();
    }
}
