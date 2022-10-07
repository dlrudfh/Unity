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
        // ���� �̵��� ���ؼ� �󸶳� �̵��ߴ����� ������
        // ĵ������ �����ϰ� ����� �ϱ� ������
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

}
//���� : https://husk321.tistory.com/m/214