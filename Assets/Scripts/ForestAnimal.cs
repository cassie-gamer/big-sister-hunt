using UnityEngine;

// A forest animal: bear, snake, or tiger!
// It takes a few hits to defeat. When defeated, it drops meat!
public class ForestAnimal : MonoBehaviour
{
    public enum AnimalType { Bear, Snake, Tiger }

    [Header("What animal is this?")]
    public AnimalType animalType = AnimalType.Bear;

    [Header("How many hits to defeat")]
    public int hitsNeeded = 3;

    private int hitsTaken = 0;

    void Start()
    {
        // Bears are tough, snakes are quick, tigers are strong!
        if (animalType == AnimalType.Bear) hitsNeeded = 4;
        else if (animalType == AnimalType.Snake) hitsNeeded = 2;
        else if (animalType == AnimalType.Tiger) hitsNeeded = 3;
    }

    public void TakeHit()
    {
        hitsTaken++;
        Debug.Log(animalType + " takes a hit! (" + hitsTaken + "/" + hitsNeeded + ")");

        if (hitsTaken >= hitsNeeded)
        {
            Defeat();
        }
    }

    void Defeat()
    {
        Debug.Log("You defeated the " + animalType + "! It drops meat!");

        // Drop meat for the big sister to collect
        MeatCounter counter = FindObjectOfType<MeatCounter>();
        if (counter) counter.AddMeat(1);

        gameObject.SetActive(false);
    }
}
