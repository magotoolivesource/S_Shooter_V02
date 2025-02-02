using UnityEngine;
using UnityEngine.UI;

public class MYUI_ImgSlider : MonoBehaviour
{

    public UnityEngine.UI.Image SliderImg;
    public float AddNMinusVal = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SliderImg.fillAmount = 1;
    }

    // Update is called once per frame
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
