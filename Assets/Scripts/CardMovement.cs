using System;
using System.Runtime.InteropServices;
using MainGameNamespace;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;
    private Vector3 originalScale;
    private int currentState = 0;
    private Quaternion originalRotation;
    private Vector3 originalPosition;
    private CardDisplay card;
    private Camera mainCamera;
    private MonsterGridManager gridManager;
    private HandManager handManager;
    [SerializeField] private float selectScale = 1.1f;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private float lerpFactor = 0.5f;



    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        card = GetComponent<CardDisplay>();
        mainCamera = Camera.main;
        setPosition();
    }

    void Update()
    {
        switch (currentState)
        {
            case 1:{
                HandleHoverState();
                break;
            }
            case 2:{
                HandleDragedState();
                if(!Input.GetMouseButton(0)){
                    TransitionToState0();
                }
                break;
            }
            case 3:{
                HandlePlayState();
                break;
            }

        }
    }
    private void TransitionToState0()
    {
        currentState = 0;
        resetPosition();
        glowEffect.SetActive(false);
    }
    

    private void HandleHoverState()
    {
        glowEffect.SetActive(true);
        rectTransform.localScale = originalScale * selectScale;
        rectTransform.localRotation = Quaternion.identity ;
    }
    private void HandleDragedState()
    {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        if(hit.collider != null && hit.collider.CompareTag("Monster")){
            MonsterDisplay monster = hit.collider.GetComponent<MonsterDisplay>();
            if(monster != null){
                monster.ApplyCardEffect(card.cardData);

            }
        }
        rectTransform.localRotation = Quaternion.identity;
    }
    private void HandlePlayState()
    {
        rectTransform.localRotation = Quaternion.identity;
        if(!Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if(hit.collider != null && hit.collider.GetComponent<GridCell>()){
                GridCell cell = hit.collider.GetComponent<GridCell>();
                int targetPosition = cell.gridIndex;
                if(cell.isFull){
                    //effect on mob
                    handManager.DiscardCardTest(gameObject);
                }
            }
        }
        TransitionToState0();
    }

    public void OnPointerEnter(PointerEventData eventData){
        if (currentState == 0 ){
            setPosition();
            currentState = 1;
        }
    }
    public void OnPointerExit(PointerEventData eventData){
        if(currentState == 1 ){
            TransitionToState0();
        }
    }
    public void OnPointerDown(PointerEventData eventData){
        if(currentState == 1){
            currentState = 2;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out originalLocalPointerPosition);
            originalPanelLocalPosition = rectTransform.localPosition;
        }
    }
    public void OnDrag(PointerEventData eventData){
        if(currentState == 2){
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out Vector2 localPointerPosition)){
                rectTransform.position = Vector3.Lerp(rectTransform.position, Input.mousePosition, lerpFactor);
            }
        }
    }

    private void resetPosition(){
        rectTransform.localScale = originalScale;
        rectTransform.localRotation = originalRotation;
        rectTransform.localPosition = originalPosition;
    }
    private void setPosition(){
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;
        originalRotation = rectTransform.localRotation;
    }
}
