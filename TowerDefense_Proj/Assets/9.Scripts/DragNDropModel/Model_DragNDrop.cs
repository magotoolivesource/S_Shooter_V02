using UnityEngine;
using UnityEngine.EventSystems;

public class Model_DragNDrop : MonoBehaviour
    , IBeginDragHandler
{

    private void OnMouseDrag()
    {
        //Debug.Log("모델 마우스 드래그");
    }

    private void OnMouseDown()
    {
        Debug.Log("모델 마우스 클릭");

    }

    private void OnMouseUp()
    {
        Debug.Log("모델 마우스 업");
    }


    public void UpdateDrop(UI_DragNDrop p_dropinfo)
    {
        Debug.Log($"모델 드랍 정보 : {this.name}, {p_dropinfo.name}");
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("모델 드래그 시작");
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
