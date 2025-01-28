using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    private Gun _weapon;
    public Gun Weapon
    {
        get{return _weapon;}
    }

    [SerializeField]

    private Transform _gunPivot;

    void OnTriggerEnter(Collider other)
    
    {
        if(other.CompareTag("Weapon") && _weapon == null)
        { 
            GrabWeapon(other.transform);
        }
    }

    private void GrabWeapon(Transform weapon)
    {
        weapon.GetComponent<Rotate>().IsRotating = false;
        weapon.GetComponent<BoxCollider>().enabled = false;
        weapon.SetParent(_gunPivot);
        weapon.localRotation = Quaternion.identity;
        weapon.localPosition = Vector3.zero;
        _weapon = weapon.GetComponent<Gun>();
    }
}
