using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    // Reference to tab group
    public TabGroup tabGroup;
    // Reference background depending on which tab selected
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.SelectTab(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.EnterTab(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.ExitTab(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Select(this);
    }
}
