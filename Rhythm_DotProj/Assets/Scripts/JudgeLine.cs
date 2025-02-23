using System;
using System.Linq;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class JudgeLine : MonoBehaviour
{
    public KeyCode PressCode = KeyCode.A;

    public float PerfectHeight = 0.1f;
    public float GoodHeight = 0.3f;
    public float NormalHeight = 0.5f;
    public float MissHeight = 0.8f;

    public LayerMask NodeLayer;

    // 판별 범위 그리기
    private void OnDrawGizmos()
    {
        // 퍼팩트 범위
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, PerfectHeight));

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(1.5f, GoodHeight));

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(2, NormalHeight));

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(2.5f, MissHeight));
    }


    void Start()
    {
        
    }

    
    void UpdateInput()
    {
        // 키를 눌렀을때 처리부분
        bool isakeypress = Input.GetKeyDown(PressCode);
        if (isakeypress == false)
            return;


        if (HitNode == null) return;


        // 판별 처리를 이용해서 처리
        Vector3 distvec = (HitNode.transform.position - transform.position);
        float nodedistance = distvec.magnitude;

        bool tempishit = false;
        if(nodedistance < PerfectHeight)
        {
            Debug.Log("퍼팩트");
            tempishit = true;
        }
        else if(nodedistance < GoodHeight)
        {
            Debug.Log("굿");
            tempishit = true;
        }
        else if (nodedistance < NormalHeight)
        {
            Debug.Log("노멀");
            tempishit = true;
        }
        else if (nodedistance < MissHeight)
        {
            Debug.Log("미스");
            tempishit = true;
        }

        if (tempishit)
        {
            GameObject.Destroy(HitNode.gameObject);
            HitNode = null; 
        }
    }


    public Node HitNode;
    void UpdateHitNode()
    {
        //HitNode = 

        BoxCollider2D box2d = GetComponent<BoxCollider2D>();
        //Collider2D hitcollider = Physics2D.OverlapBox(box2d.bounds.center, box2d.bounds.size, 0f);
        //HitNode = hitcollider.GetComponent<Node>();


        Collider2D[] hitnodearr = Physics2D.OverlapBoxAll(box2d.bounds.center
            , box2d.bounds.size
            , 0f
            , NodeLayer);

        HitNode = null;
        if (hitnodearr.Length > 0)
        {
            float ypos = transform.position.y;
            // Linq 란 것을 이용해서 정렬
            var resultarr = from item in hitnodearr
                            orderby Math.Abs( item.transform.position.y - ypos ) ascending
                            select item;

            HitNode = resultarr.First().GetComponent<Node>();
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }




    void Update()
    {
        UpdateHitNode();
        UpdateInput();

    }
}
