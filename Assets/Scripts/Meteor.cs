using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float Speed;
    public int HitDamage;
    public Animator animator;
    public bool isHit = false;

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    private Vector2 _targetPosition;
    private float _spawnDelta = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= MaxX || transform.position.x <= MinX
            || transform.position.y >= MaxY || transform.position.y <= MinY) {
            //Debug.Log($"Meteor: reached border at ({transform.position.x},{transform.position.y})");
            //Debug.Log($"Meteor: border at ({MinX},{MinY},{MaxX},{MaxY})");
            Destroy(gameObject);
        } else
        {
            if (!isHit) {
                transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Speed * Time.deltaTime);
            }
            
            //Debug.Log($"Meteor: moved to ({transform.position.x},{transform.position.y})");
        }        
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        SoundManager.PlaySound("meteorHit");
        isHit = true;
        if (hit.CompareTag("Base"))
        {            
            //Debug.Log("Meteor: hit a base");
            hit.GetComponent<Homeland>().TakeHit(HitDamage);
            Die();
        }

        if (hit.CompareTag("Meteor"))
        {
            //Debug.Log("Meteor: hit a Meteor");
            Die();
        }
    }

    void Init()
    {
        transform.position = RandomBorderPosition();
        _targetPosition = RandomOppositeBorderPosition();
        //Debug.Log($"Meteor: Init from ({ transform.position.x },{ transform.position.y }) to ({ _targetPosition.x },{ _targetPosition.y })");
    }

    void Die()
    {
        //Debug.Log("Meteor: Died");
        animator.SetBool("IsHit", true);
    }

    Vector2 RandomBorderPosition()
    {
        switch (Random.Range(0,39) / 10)
        {
            case 0:
                return new Vector2(MinX + _spawnDelta, Random.Range(MinY + _spawnDelta, MaxY - _spawnDelta));
            case 1:
                return new Vector2(MaxX - _spawnDelta, Random.Range(MinY + _spawnDelta, MaxY - _spawnDelta));
            case 2:
                return new Vector2(Random.Range(MinX + _spawnDelta, MaxX - _spawnDelta), MinY - _spawnDelta);
            case 3:
                return new Vector2(Random.Range(MinX + _spawnDelta, MaxX - _spawnDelta), MaxY - _spawnDelta);
            default:
                return new Vector2(Random.Range(MinX + _spawnDelta, MaxX - _spawnDelta), Random.Range(MinY + _spawnDelta, MaxY - _spawnDelta));
        }
    }

    Vector2 RandomOppositeBorderPosition()
    {
        if (transform.position.x == MinX + _spawnDelta)
        {
            return new Vector2(MaxX, Random.Range(MinY, MaxY));
        } else if (transform.position.x == MaxX - _spawnDelta)
        {
            return new Vector2(MinX, Random.Range(MinY, MaxY));
        } else if (transform.position.y == MinY + _spawnDelta)
        {
            return new Vector2(Random.Range(MinX, MaxX), MaxY);
        }
        else 
        {
            return new Vector2(Random.Range(MinX, MaxX), MinY);
        }
    }

    public void OnHitAnimationEnded()
    {
        animator.SetBool("IsHit", false);
        Destroy(gameObject);
    }
}
