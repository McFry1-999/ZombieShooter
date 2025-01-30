using UnityEngine;
using  UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _bulletPivot;

    [SerializeField]

    private Animator _weaponAnimator;

    [SerializeField]
    
    private int _maxBulletNumber = 20;

    [SerializeField]
    private int _cartridgeBulletNumber = 5;
    private int _totalbulletNumber = 0;
    private int _currentBulletNumber = 0;
    private Text _bulletText;

    public void Shoot()
    {
        _weaponAnimator.Play("Shoot", -1, 0f);
        GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);
        _currentBulletNumber--;
         UpdateBulletText();
    }

    public void PickUpWeapon()
    {
        _totalbulletNumber = _maxBulletNumber;
        _currentBulletNumber = _cartridgeBulletNumber;

        _weaponAnimator.Play("Get Weapon");

         UpdateBulletText();



    }

    public void Reload()
    {
        if(_totalbulletNumber >= _cartridgeBulletNumber)
        {
            _currentBulletNumber = _cartridgeBulletNumber;

        } else if (_totalbulletNumber > 0)
        {
            _currentBulletNumber = _totalbulletNumber;
        }
        _totalbulletNumber -= _cartridgeBulletNumber;
        UpdateBulletText();

    }

    private void UpdateBulletText()
    {
        if(_bulletText == null)
        {
            _bulletText = GameObject.Find("BulletText").GetComponent<Text>();
        }
        _bulletText.text = _currentBulletNumber + "/" + _totalbulletNumber;

    }

}
