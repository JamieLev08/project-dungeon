using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float health;

    private float maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            ObstacleStats objDamage = collision.gameObject.GetComponent<ObstacleStats>();
            
            TakeDamage(objDamage.damage);

            objDamage.Damaged();
        }
    }

    void TakeDamage(float damage)
    {
        float tempHealth = health -= damage;

        if(tempHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            health = tempHealth;
            Debug.Log(health);
        }
    }
}
