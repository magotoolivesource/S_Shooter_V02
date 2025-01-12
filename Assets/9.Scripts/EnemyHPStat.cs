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
            //Debug.Log( "�� hp : 0");
            // �ִϸ��̼� 1.3�ʵڿ� 
            //GameObject.Destroy(gameObject);
            //GetComponent<NavMeshAgent>().speed = 0;

            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;

            //// 3�� �ڿ� ������
            //GameObject.Destroy(gameObject, 3f);
            // 1�ʵڿ� �Ʒ��� ���������� �ϱ�
            // 3�ʵ��� �������ڿ� Destroy() �ϱ�

            //Thread.Sleep(1000);
            m_ISDeath = true;

            StartCoroutine( FallDown() );
            
        }
    }


    IEnumerator FallDown()
    {

        //// return �� ����
        //if( true)
        //    yield break;

        // 1�ʴ��
        yield return new WaitForSeconds(1f);

        //// �Ʒ��� �̵�ó��
        //while(true)
        //{
        //    transform.Translate(0f, 1f * Time.deltaTime, 0f);
        //    if( transform.position.y <= 5f)
        //    {
        //        break;
        //    }
        //    yield return null; // 1������ ���
        //}

        // �Ʒ��� �̵�
        for (int i = 0; i < 1000; i++)
        {
            transform.Translate(0f, -1f * Time.deltaTime, 0f);
            if (transform.position.y <= -5f)
            {
                break;
            }

            yield return null; // 1������ ���
        }

        // �����
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
                // �Ʒ��� �̵� ó��
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
