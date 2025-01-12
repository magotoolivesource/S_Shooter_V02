using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHPStat : MonoBehaviour
{
    public int HP = 5;

    public void SetDamage(float p_dmg)
    {
        if (HP <= 0)
            return;

        HP = HP - (int)p_dmg;
        if( HP <= 0)
        {
            //Debug.Log( "적 hp : 0");
            // 애니메이션 1.3초뒤에 
            //GameObject.Destroy(gameObject);
            //GetComponent<NavMeshAgent>().speed = 0;

            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;

            //// 3초 뒤에 지워라
            //GameObject.Destroy(gameObject, 3f);
            // 1초뒤에 아래로 떨어지도록 하기
            // 3초동안 떨어진뒤에 Destroy() 하기

            //Thread.Sleep(1000);
            m_ISDeath = true;

            StartCoroutine( FallDown() );
            
        }
    }


    IEnumerator FallDown()
    {

        //// return 과 같다
        //if( true)
        //    yield break;

        // 1초대기
        yield return new WaitForSeconds(1f);

        //// 아래로 이동처리
        //while(true)
        //{
        //    transform.Translate(0f, 1f * Time.deltaTime, 0f);
        //    if( transform.position.y <= 5f)
        //    {
        //        break;
        //    }
        //    yield return null; // 1프레임 대기
        //}

        // 아래로 이동
        for (int i = 0; i < 1000; i++)
        {
            transform.Translate(0f, -1f * Time.deltaTime, 0f);
            if (transform.position.y <= -5f)
            {
                break;
            }

            yield return null; // 1프레임 대기
        }

        // 지우기
        GameObject.Destroy(gameObject);
    }

    void Start()
    {
        
    }




    bool m_ISDeath = false;
    float m_DeathDelaySec = 1f;
    float m_FallDownDelaySec = 3f;
    void UpdateCodeFallDown()
    {
        if (m_ISDeath)
        {
            m_DeathDelaySec -= Time.deltaTime;
            if (m_DeathDelaySec <= 0f)
            {
                // 아래로 이동 처리
                Vector3 temppos = transform.position;
                temppos.y -= 1f * Time.deltaTime;
                transform.position = temppos;
                //transform.Translate(0f, 1f * Time.deltaTime, 0f);

                if (transform.position.y <= -5f)
                {
                    GameObject.Destroy(gameObject);
                }

                m_FallDownDelaySec -= Time.deltaTime;
                if (m_FallDownDelaySec <= 0f)
                {
                    GameObject.Destroy(gameObject);
                }
            }
        }

    }
    
    void Update()
    {
        //UpdateCodeFallDown();
        
    }
}
