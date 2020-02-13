using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    [SerializeField] float damage;
    HealthMeter healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player")
        {
            healthBar.ChangeHealth(--damage);
            //Spelaren blir odödlig och blinkar?
        }
    }        

    // Update is called once per frame
    void Update()
    {
        
    }
}
