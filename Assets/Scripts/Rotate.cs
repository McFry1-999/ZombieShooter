using System;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private  float _RotateSpeed = 5;

    public Boolean _isRotating = true;

    public bool IsRotating
    {
        get { return _isRotating; }
        set { _isRotating = value ;}
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon();


    }

    private void RotateWeapon()
    {
        if (_isRotating)
        {
            gameObject.transform.Rotate(0f, _RotateSpeed * Time.deltaTime,0f);
        }
    }
}
