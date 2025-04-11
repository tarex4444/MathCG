using System;
using System.Runtime.InteropServices;
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
    [SerializeField] private float selectScale = 1.1f;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private float lerpFactor = 0.5f;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
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
                if(!Input.GetMouseButton(0)){
                    TransitionToState0();
                }
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
        rectTransform.localRotation = Quaternion.identity;
    }
    private void HandlePlayState()
    {
        rectTransform.localRotation = Quaternion.identity;
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
