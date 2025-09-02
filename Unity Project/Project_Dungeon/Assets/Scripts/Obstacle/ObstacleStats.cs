using UnityEngine;

public class ObstacleStats : MonoBehaviour
{
    public float damage;
    public float obsHealth;
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
        float tempHealth = obsHealth -= (damage * 2);

        if(tempHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            obsHealth = tempHealth;
        }
    }
}
