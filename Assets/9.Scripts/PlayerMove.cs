using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Start()
    {
        
    }

    public float MoveSpeed = 1;
    void Update()
    {
        //float xx = 0;
        //if( Input.GetKey(KeyCode.A)
        //    || Input.GetKey(KeyCode.LeftArrow) )
        //{
        //    xx = -1;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    xx = 1;
        //}


        // a, d, <-, ->
        // -1 ~ 1
        float xx = Input.GetAxis("Horizontal");
        //Time.time;
        //w, s, a,d, 화살표 이용해서 이동처리
        Vector3 temppos = transform.position;
        temppos.x += xx * MoveSpeed * Time.deltaTime;
        temppos.z += Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

        this.transform.position = temppos;


    }
}
