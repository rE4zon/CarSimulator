using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public void LoadLevelNumber(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }
}
