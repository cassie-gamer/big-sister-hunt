using UnityEngine;
using UnityEngine.UI;

// Counts the meat! You need 20 meat to feed your hungry siblings.
// When you reach 20, you win and everyone eats!
public class MeatCounter : MonoBehaviour
{
    [Header("Meat needed to win")]
    public int meatNeeded = 20;

    [Header("Show meat count here")]
    public Text meatText;

    [Header("Show this when you win")]
    public Text winText;

    private int meat = 0;

    public void AddMeat(int amount)
    {
        meat += amount;
        Debug.Log("Meat collected: " + meat + "/" + meatNeeded);

        if (meatText) meatText.text = "Meat: " + meat + "/" + meatNeeded;

        if (meat >= meatNeeded)
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("You collected 20 meat! Your brother and sister can eat now!");
        if (winText) winText.text = "You did it! Everyone eats! The End";
    }
}
