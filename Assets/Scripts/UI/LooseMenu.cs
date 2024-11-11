using UnityEngine;
using DG.Tweening;

public class LooseMenu : MonoBehaviour
{
    private RectTransform _thisPanel;
    private void Awake()
    {
        _thisPanel = GetComponent<RectTransform>();

        Death.Dead += ShowMenu;
    }
    private void ShowMenu()
    {
        _thisPanel.DOMoveY(0, 1, false);
    }
    private void OnDisable()
    {
        Death.Dead -= ShowMenu;
    }
}
