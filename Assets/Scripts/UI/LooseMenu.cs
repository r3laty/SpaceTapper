using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LooseMenu : MonoBehaviour
{
    [SerializeField] private RectTransform loosePanel;
    private void Awake()
    {
        Death.Dead += ShowMenu;
    }
    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        loosePanel.gameObject.SetActive(false);
    }
    public void Leave()
    {
        Application.Quit();
    }
    private void ShowMenu()
    {
        loosePanel.gameObject.SetActive(true);

        loosePanel.DOMoveY(0, 1, false);
        loosePanel.DOScaleX(1, 1);
    }
    private void OnDisable()
    {
        Death.Dead -= ShowMenu;
    }
}
