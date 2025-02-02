using UnityEngine;
using UnityEngine.UI;

public class MYUI_Slider : MonoBehaviour
{
    public int MAXHP = 4320;

    // 0~100
    // 키보드 + 누르면 슬라이더 값더하기 5씩증가
    // 키보드 - 누르면 슬라이더 값빼기 5씩빼기
    public UnityEngine.UI.Slider LinkSlider;
    void Start()
    {
        LinkSlider.value = 0;
        LinkSlider.interactable = false;
        LinkSlider.minValue = 0;
        LinkSlider.maxValue = MAXHP;
    }

    void Update()
    {

        if ( Input.GetKeyDown(KeyCode.Plus) )
        {
            Debug.Log("PP++");
        }

        if ( Input.GetKeyDown(KeyCode.Equals) 
            //&& (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) )
            )
        {
            Debug.Log("++");

            LinkSlider.value += 5;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Debug.Log("--");
            LinkSlider.value -= 5;
        }

    }
}
