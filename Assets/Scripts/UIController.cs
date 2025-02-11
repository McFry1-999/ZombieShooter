using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
[SerializeField]

    private GameObject _bulletUI;

    [SerializeField]
    private Text _bulletsText;
    public Text BulletsText
    {
        get{return _bulletsText;}
    }

    [SerializeField]

    private GameObject _gameOverUI;

    [SerializeField]
    private GameObject _winUI;

    public void Start()
    {
        ShowBulletUI(false);
        ShowGameOverUI(false);
        ShowWinUI(false);
    }

    
    public void ShowBulletUI(bool show)    
    {
        _bulletUI.SetActive(show);
    }

    public void ShowGameOverUI(bool show)
    {
        _gameOverUI.SetActive(show);
    }

    public void ShowWinUI(bool show)
    {
        _winUI.SetActive(show);
    }
}
