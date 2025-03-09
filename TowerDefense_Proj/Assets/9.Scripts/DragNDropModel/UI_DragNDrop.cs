using UnityEngine;
using UnityEngine.EventSystems;

public class UI_DragNDrop : MonoBehaviour
    //, IBeginDragHandler
    , IEndDragHandler
    //, IDragHandler
    //, IDropHandler
{

    public Camera m_3DModelCam = null;

    public LayerMask m_HitLayerMask;
    public void OnEndDrag(PointerEventData eventData)
    {



        Debug.Log("드래그 종료");

        Ray ray = m_3DModelCam.ScreenPointToRay(eventData.position);

        RaycastHit hitobj;
        if( Physics.Raycast(ray, out hitobj, 10000f, m_HitLayerMask) )
        {
            Debug.Log( $"드래그 오브젝트 : {hitobj.transform.name}");

            if( false)
            {
                Model_DragNDrop modeldrop = hitobj.transform.GetComponent<Model_DragNDrop>();
                if (modeldrop != null)
                {
                    modeldrop.UpdateDrop(this);
                }
            }
            else
            {
                hitobj.transform.GetComponent<Model_DragNDrop>()?.UpdateDrop(this);
            }

            

        }
        

    }

    
    void Start()
    {
        m_3DModelCam = Camera.main;
        m_HitLayerMask = LayerMask.GetMask("Build");
    }

    
    void Update()
    {
        
    }
}
