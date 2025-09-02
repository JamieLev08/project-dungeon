using UnityEngine;

public class ObstacleStats : MonoBehaviour
{
    public float damage;
    public float obsHealth;
    public bool persistent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damaged()
    {
        if (!persistent)
        {
            float tempHealth = obsHealth -= damage;
            if (tempHealth <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                obsHealth = tempHealth;
            }
        }
    }
}
