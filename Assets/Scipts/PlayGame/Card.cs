using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour, IPointerClickHandler
{

    private Image image;
    private bool isHighlighted = false;

    private Color normalColor = Color.white;
    private Color darkerColor = new Color(0.7f, 0.7f, 0.7f, 1f);

    private void Awake()
    {
        image = GetComponent<Image>();
      
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.IsSelected = true;
        GameManager.Instance.HandleCardClick(this, eventData);
    }

    public void SetHighlight(bool state)
    {
        isHighlighted = state;
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (image != null)
            image.color = isHighlighted ? darkerColor : normalColor;
    }
}