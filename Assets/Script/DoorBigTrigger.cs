using UnityEngine;

public class DoorBigTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetActive(false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.SetActive(true);
        }
    }

}