using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void TryAgain()
    {
        MasterInfo.coinCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void GoToMainMenu()
    {
        MasterInfo.coinCount = 0;
        SceneManager.LoadScene(0);
    }
}
