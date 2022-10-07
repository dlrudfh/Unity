using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Status : MonoBehaviour, IDragHandler
{

    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 이전 이동과 비교해서 얼마나 이동했는지를 보여줌
        // 캔버스의 스케일과 맞춰야 하기 때문에
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

}
//참고 : https://husk321.tistory.com/m/214