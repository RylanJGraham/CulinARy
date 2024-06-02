using UnityEngine;

public class FruitSlice : MonoBehaviour
{
    public GameObject slicedFruitPrefab; // Assign your sliced fruit prefab

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            // Replace the fruit with its sliced version
            Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
