using UnityEngine;
using UnityEngine.SceneManagement;

public class Homeland : MonoBehaviour
{
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Homeland: Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit(int hit)
    {
        //Debug.Log("Homeland: took a hit");
        Health -= hit;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Debug.Log("Homeland: Die");
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
}
