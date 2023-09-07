using UnityEngine;
public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject EndPanel;
    
    private void Start()
    {
        EndPanel.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EndPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
