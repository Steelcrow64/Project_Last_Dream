using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject door;

    bool isOpened = false;

    public void OnTriggerEnter(Collider other)
    {
        if (!isOpened)
        {
            isOpened = true;
            door.transform.position += new Vector3(7, 0, 0);
        }
    }

    /*
    public void OnTriggerExit(Collider other)
    {
        door.transform.position += new Vector3(0, 0, 0);
    }
    */
}