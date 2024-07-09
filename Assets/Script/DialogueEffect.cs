using UnityEngine;

public class DialogueEffect : MonoBehaviour
{
    [SerializeField] Material enterMat;
    [SerializeField] Material pressMat;
    [SerializeField] private GameObject popUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerController>().ChangeSkinMat(enterMat);
            popUp.SetActive(true);
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
            popUp.SetActive(false);
        }
    }

}
