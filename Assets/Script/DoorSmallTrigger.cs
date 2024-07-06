using UnityEngine;

public class DoorSmallTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetActive(false);
        }
    }
}