using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= maxX || transform.position.x <= minX
            || transform.position.y >= maxY || transform.position.y <= minY) {
            Reset();
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Base")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collider.tag == "Floatie")
        {
            Reset();
        }
    }

    void Reset()
    {
        transform.position = RandomBorderPosition();
        targetPosition = RandomOppositeBorderPosition();

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    Vector2 RandomBorderPosition()
    {
        switch (Random.Range(0,30) / 10)
        {
            case 0:
                return new Vector2(minX, Random.Range(minY, maxY));
                break;
            case 1:
                return new Vector2(maxX, Random.Range(minY, maxY));
                break;
            case 2:
                return new Vector2(Random.Range(minX, maxX), minY);
                break;
            case 3:
                return new Vector2(Random.Range(minX, maxX), maxY);
                break;
            default:
                return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                break;
        }
    }

    Vector2 RandomOppositeBorderPosition()
    {
        if (transform.position.x == minX)
        {
            return new Vector2(maxX, Random.Range(minY, maxY));
        } else if (transform.position.x == maxX)
        {
            return new Vector2(minX, Random.Range(minY, maxY));
        } else if (transform.position.y == minY)
        {
            return new Vector2(Random.Range(minX, maxX), maxY);
        }
        else 
        {
            return new Vector2(Random.Range(minX, maxX), minY);
        }
    }
}
