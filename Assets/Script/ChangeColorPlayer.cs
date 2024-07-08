using UnityEngine;

public class ChangeColorPlayer : MonoBehaviour
{
    [SerializeField] Material enterMat;
    [SerializeField] Material pressMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ChangeSkinMat(enterMat);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetMouseButtonUp(0))
            {
                other.GetComponent<PlayerController>().ChangeSkinMat(pressMat);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ResetSkinMat();
        }
    }

}
