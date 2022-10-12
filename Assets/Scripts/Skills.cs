using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Skills : MonoBehaviour, IDragHandler
{

    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject ChargeShot;
    [SerializeField] GameObject Dash;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("LV") < 3) 
            ChargeShot.GetComponent<TextMeshProUGUI>().text = "Required LV.3";
        else 
            ChargeShot.GetComponent<TextMeshProUGUI>().text = "ChargeShot LV." + PlayerPrefs.GetInt("CHARGESHOT");

        if (PlayerPrefs.GetInt("LV") < 5)
            Dash.GetComponent<TextMeshProUGUI>().text = "Required LV.5";
        else
            Dash.GetComponent<TextMeshProUGUI>().text = "Dash LV." + PlayerPrefs.GetInt("DASH");

    }

    public void OnDrag(PointerEventData eventData)
    {
        // ���� �̵��� ���ؼ� �󸶳� �̵��ߴ����� ������
        // ĵ������ �����ϰ� ����� �ϱ� ������
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

}