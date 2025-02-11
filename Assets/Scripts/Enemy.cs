using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private string enemytoLook = "Player";
    [SerializeField]

    private float speed = 1f;
    private Transform objective;

    private Health health;

    void Start()
    {
        objective = GameObject.FindGameObjectWithTag(enemytoLook).transform;
        health = GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        FollowObjective();
    }

    private void FollowObjective()
    {
        Vector3 direction = (objective.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health.TakeDamage(collision.gameObject.GetComponent<bULLET>().Damage);
            Destroy(collision.gameObject);
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
