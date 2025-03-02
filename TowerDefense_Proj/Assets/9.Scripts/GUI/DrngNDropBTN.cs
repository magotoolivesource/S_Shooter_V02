using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrngNDropBTN : MonoBehaviour
    , IBeginDragHandler
    , IEndDragHandler
    , IDragHandler
    , IDropHandler
{
    public Image DragIcon;
    public Vector3 m_InitPos;

    public bool m_ISChange = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log( $"드래드 시작 : {this.name}");
        m_InitPos = DragIcon.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mpos = Input.mousePosition;
        //Debug.Log($"드래그중 : {this.name}, {mpos}, {eventData.position}");

        DragIcon.transform.position = eventData.position;
    }

    

    //public Image SendImage = null;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log($"드랍처리 : {eventData.selectedObject.name} -> {this.name} ");

        DrngNDropBTN srcbtn = eventData.selectedObject.GetComponent<DrngNDropBTN>();
        if (srcbtn != null)
        {
            // 서로 치환
            Sprite swapsprite = this.DragIcon.sprite;
            this.DragIcon.sprite = srcbtn.DragIcon.sprite;
            srcbtn.DragIcon.sprite = swapsprite;
        }


        OnlyDropBTN tempbtn = eventData.selectedObject.GetComponent<OnlyDropBTN>();
        if (tempbtn != null)
        {
            // 지워라
            tempbtn.DragIcon.sprite = null;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log( $"드래그 끝 : {this.name}" );
        DragIcon.transform.position = m_InitPos;//  eventData.pressPosition;
    }

    void Start()
    {
        m_InitPos = DragIcon.transform.position;
    }

    void Update()
    {
        
    }
}
