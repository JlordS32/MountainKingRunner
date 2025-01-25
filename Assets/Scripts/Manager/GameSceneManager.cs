using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private void Update() {
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}
