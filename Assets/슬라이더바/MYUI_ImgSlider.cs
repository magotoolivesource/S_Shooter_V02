using UnityEngine;
using UnityEngine.UI;

public class MYUI_ImgSlider : MonoBehaviour
{

    public UnityEngine.UI.Image SliderImg;
    public float AddNMinusVal = 0.1f;

    void Start()
    {
        SliderImg.fillAmount = 1;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals)
            //&& (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) )
            )
        {
            Debug.Log("DD++");
            SliderImg.fillAmount += AddNMinusVal;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Debug.Log("DD--");
            SliderImg.fillAmount -= AddNMinusVal;
        }
    }
}
