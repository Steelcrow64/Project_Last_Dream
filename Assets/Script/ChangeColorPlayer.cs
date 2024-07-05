using UnityEngine;

public class ChangeColorPlayer : MonoBehaviour
{
    [SerializeField] Material myMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myMaterial.color = Color.blue;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myMaterial.color = Color.cyan;
        }
    }

}
