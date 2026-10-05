using UnityEngine;

// You are the BIG SISTER! Your little brother and sister are hungry,
// so you go into the forest to hunt for food.
// Move with WASD / arrows, press SPACE (or tap the Attack button) to swing!
public class BigSister : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 6f;

    [Header("Attack")]
    public float attackRange = 2f;
    public KeyCode attackKey = KeyCode.Space;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        if (rb) rb.velocity = moveInput * speed;
        else transform.Translate(moveInput * speed * Time.deltaTime);
    }

    // For touch screens - hook to an Attack button
    public void TapAttack()
    {
        Attack();
    }

    void Attack()
    {
        Debug.Log("Big sister swings!");
        // Hit the closest animal in range
        ForestAnimal[] animals = FindObjectsOfType<ForestAnimal>();
        ForestAnimal closest = null;
        float bestDist = attackRange;

        foreach (ForestAnimal a in animals)
        {
            float d = Vector2.Distance(transform.position, a.transform.position);
            if (d < bestDist)
            {
                bestDist = d;
                closest = a;
            }
        }

        if (closest != null)
        {
            closest.TakeHit();
        }
    }
}
