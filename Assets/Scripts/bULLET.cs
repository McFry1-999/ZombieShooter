using UnityEngine;

public class bULLET : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField]
    private float _bulletspeed;

    [SerializeField]
    private int damage = 1;

    public int Damage
    {
        get { return damage;}

    }

        private void OnEnable()
        {
            if (_rigidBody == null)
            {
                _rigidBody = gameObject.GetComponent<Rigidbody>();
            }
            _rigidBody.AddForce(transform.forward * _bulletspeed, ForceMode.Impulse);
        }
}
