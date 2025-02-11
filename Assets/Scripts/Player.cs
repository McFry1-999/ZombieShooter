using UnityEngine;


public class Player : MonoBehaviour
{

    private Health health;

    private bool isplaying = true;

    private UIController uiController;
    void Start()
    {
        health = GetComponent<Health>();
        uiController = GetComponent<UIController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && isplaying)
        {
            health.TakeDamage(1);
            Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
            transform.position += pushDirection * 0.5f;
        }
        else if(collision.gameObject.CompareTag("Key"))
        {
            isplaying = false;
            uiController.ShowWinUI(true);
        }
    }

    public void Die()
    {
        uiController.ShowGameOverUI(true);
    }
    
}
