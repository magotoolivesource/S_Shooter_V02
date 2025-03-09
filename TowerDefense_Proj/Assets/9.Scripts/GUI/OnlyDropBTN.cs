using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnlyDropBTN : BaseDragNDropBTN
    , IBeginDragHandler
    , IEndDragHandler
    , IDragHandler
    //, IDropHandler
{

    public override E_DragNDropType GetDragNDropType()
    {
        return E_DragNDropType.E_OnlyDrag;
    }


    //public Image DragIcon;
    //public Vector3 m_InitPos;

    public bool m_ISChange = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"드래드 시작 : {this.name}");
        m_InitPos = DragIcon.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mpos = Input.mousePosition;
        //Debug.Log($"드래그중 : {this.name}, {mpos}, {eventData.position}");

        DragIcon.transform.position = eventData.position;
    }


    ////public Image SendImage = null;
    //public override void OnDrop(PointerEventData eventData)
    //{
    //    base.OnDrop(eventData);

    //    ////DrngNDropBTN srcbtn = eventData.selectedObject.GetComponent<DrngNDropBTN>();
    //    ////Debug.Log($"드랍처리 : {eventData.selectedObject.name} -> {this.name} ");

    //    ////if(srcbtn != null)
    //    ////{
    //    ////    // 복사
    //    ////    this.DragIcon.sprite = srcbtn.DragIcon.sprite;
    //    ////}

    //    ////// 서로 치환
    //    ////OnlyDropBTN seletedbtn = eventData.selectedObject.GetComponent<OnlyDropBTN>();
    //    ////if (seletedbtn != null)
    //    ////{
    //    ////    // 서로 치환
    //    ////    Sprite swapsprite = this.DragIcon.sprite;
    //    ////    this.DragIcon.sprite = seletedbtn.DragIcon.sprite;
    //    ////    seletedbtn.DragIcon.sprite = swapsprite;
    //    ////}


    //    //DrngNDropBTN srcbtn = eventData.selectedObject.GetComponent<DrngNDropBTN>();
    //    //Debug.Log($"드랍처리 : {eventData.selectedObject.name} -> {this.name} ");

    //    //E_DragNDropType srctype = srcbtn.GetDragNDropType();
    //    //E_DragNDropType desttype = this.GetDragNDropType();

    //    //E_DropCopyType copytype = this.GetSrcTODestMatrixType(srctype, desttype);
    //    //if (copytype == E_DropCopyType.E_Chnage)
    //    //{
    //    //    // 교체
    //    //    ChangeDragNDrop(srcbtn, this);
    //    //}
    //    //else if (copytype == E_DropCopyType.E_Copy)
    //    //{
    //    //    // src -> dest 카피용
    //    //    CopyDragNDrop(srcbtn, this);
    //    //}
    //    //else if (copytype == E_DropCopyType.E_Delete)
    //    //{
    //    //    // src 지우기
    //    //    DeleteDragNDrop(srcbtn, this);
    //    //}


    //}

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log($"드래그 끝 : {this.name}");
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
