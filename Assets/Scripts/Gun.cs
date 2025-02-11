using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    private GetWeapon _getWeapon;


    private void RemoveWeapon()
        {
            _getWeapon.RemoveWeapon();
            _getWeapon = null;
        }
    
    public void Shoot()
    {

        if(_currentBulletNumber == 0)
        {
            if(_totalbulletNumber == 0)
            {
                RemoveWeapon();
            }
            return;
        }

        SoundManager.instance.Play("Shoot");
        _weaponAnimator.Play("Shoot", -1, 0f);
        GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);
        _currentBulletNumber--;
         UpdateBulletText();
    }

    public void PickUpWeapon(GetWeapon getWeapon)
    {
        _getWeapon = getWeapon;
        _totalbulletNumber = _maxBulletNumber;
        _currentBulletNumber = _cartridgeBulletNumber;

        _weaponAnimator.Play("Get Weapon");

         UpdateBulletText();



    }

    public void Reload()
    {
        if(_currentBulletNumber == _cartridgeBulletNumber || _totalbulletNumber == 0)
        {
            return;
        }

        int bulletNeeded = _cartridgeBulletNumber - _currentBulletNumber;
        if(_totalbulletNumber >= _cartridgeBulletNumber)
        {
            _currentBulletNumber = bulletNeeded;
        }
        else if (_totalbulletNumber > 0)
        {
            _currentBulletNumber = _totalbulletNumber;
        }

        SoundManager.instance.Play("Reload");
        _totalbulletNumber -= _cartridgeBulletNumber;
        UpdateBulletText();

         _weaponAnimator.Play("Reload");

    }

    private void UpdateBulletText()
    {
        if(_bulletText == null)
        {
            _bulletText = _getWeapon.GetComponent<UIController>().BulletsText;
        }
        _bulletText.text = _currentBulletNumber + "/" + _totalbulletNumber;

    }

}
