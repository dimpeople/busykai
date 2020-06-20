using UnityEngine;
using UnityEngine.SceneManagement;

public class Homeland : MonoBehaviour
{
    public int Health;
    public Animator animator;

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
        Debug.Log($"Homeland: Took {hit} damage of {Health}");
        Debug.Log("Hit animation: Start");
        animator.SetBool("IsHit", true);
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Homeland: Die");
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    public void OnHitAnimationEnded()
    {
        Debug.Log("Hit animation: End");
        animator.SetBool("IsHit", false);
    }
}
