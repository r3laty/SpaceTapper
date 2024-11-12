using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LooseMenu : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ProcedularGeneration procedularGeneration;
    [SerializeField] private RectTransform loosePanel;
    private Animator _playerAnimator;
    private ReturnToHome _playerHome;
    private Jump _playerJump;
    private Collider2D _firtsPlanetCollider;
    private void Awake()
    {
        //_firtsPlanetCollider = procedularGeneration.FirstPlanet.GetComponent<Collider2D>();
        _playerAnimator = player.GetComponent<Animator>();
        _playerHome = player.GetComponent<ReturnToHome>();
        _playerJump = player.GetComponent<Jump>();

        Death.Dead += ShowMenu;
    }
    public void Again()
    {
        // _playerHome.Return();
        // _playerAnimator.SetBool(AnimationTags.PlayerIdle, true);
        // Destroy(procedularGeneration.CurrentPlanet);
        // Destroy(procedularGeneration.PrelastPlanet);
        // Destroy(procedularGeneration.LastPlanet);
        // if (procedularGeneration.FirstPlanet)
        // {
        //     procedularGeneration.FirstPlanet.SetActive(true);
        //     procedularGeneration.FirstPlanet.transform.position = new Vector2(-0.0900000036f, 3.20000005f);
        //     _firtsPlanetCollider.enabled = true;
        // }
        // else
        // {
        //     Vector2 instantiateVector = new Vector2(-0.0900000036f, 3.20000005f);
        //     Instantiate(procedularGeneration.FirstPlanet, instantiateVector, Quaternion.identity);
        // }
        
        
        // procedularGeneration.BasePlanet.SetActive(true);
        // Invoke("ResetSwipes", 0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        loosePanel.gameObject.SetActive(false);
    }
    public void Leave()
    {
        Debug.Log("Leave");
    }
    private void ShowMenu()
    {
        loosePanel.gameObject.SetActive(true);

        loosePanel.DOMoveY(0, 1, false);
        loosePanel.DOScaleX(1, 1);
    }
    private void ResetSwipes()
    {
        _playerJump.AvailableSwipes();
    }
    private void OnDisable()
    {
        Death.Dead -= ShowMenu;
    }
}
