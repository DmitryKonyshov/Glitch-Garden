using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCoast = 100;

    public void AddStars(int ammount)
    {
        FindObjectOfType<StarDisplay>().AddStars(ammount);
    }
}
