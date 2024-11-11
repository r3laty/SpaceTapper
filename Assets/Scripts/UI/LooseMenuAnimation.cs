using UnityEngine;
using DG.Tweening;

public class LooseMenuAnimation : MonoBehaviour
{
    private RectTransform _thisPanel;
    private void Awake()
    {
        _thisPanel = GetComponent<RectTransform>();
    }
    private void Update()
    {

        _thisPanel.DOMoveY(0, 1, false);
    }
}
