
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Button replayButton;
    [SerializeField] Button quitButton;
    [SerializeField] GameObject gameMenu;

    [SerializeField] CharacterController characterController;
    

    private void Start()
    {
        replayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameMenu.SetActive(false);

        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    public void OnPlayerDead()
    {
        characterController.SetBoolIsdead(true);
        gameMenu.SetActive(true);
    }


}
