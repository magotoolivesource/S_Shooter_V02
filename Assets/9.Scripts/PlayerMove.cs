using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Start()
    {
        
    }

    public float MoveSpeed = 1;

    void UpdateMove()
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

    public Camera maincam;
    void UpdateRotation1()
    {
        Camera cam = maincam;
        // -1~1 사이값으로 하는것 ViewPort
        //Vector3 viewport = cam.WorldToViewportPoint(this.transform.position);

        // 화면 의 왼쪽 하단을 기준 스크린 사이즈에 맞추어서 좌표 반환
        Vector3 screenpos = cam.WorldToScreenPoint(this.transform.position);

        float centerx = screenpos.x;// 1920.0f * 0.5f;
        float centery = screenpos.y;// 1080.0f * 0.5f;

        Vector3 pos = Input.mousePosition;
        Debug.Log($"마우스 : {pos}");

        // 마우스 위치를 이용한 회전
        float targetx = pos.x - centerx;
        float targety = pos.y - centery;
        float radian = Mathf.Atan2( -targety, targetx);
        Debug.Log($"회전 : {radian}");

        // 3.141595f
        this.transform.rotation = Quaternion.Euler(0
                                    , (radian * Mathf.Rad2Deg) + 90
                                    , 0);
    }

    void Update()
    {
        UpdateMove();
        UpdateRotation1();

    }
}
