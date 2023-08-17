using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeStage()
    {
        SceneManager.LoadScene("Monologue");
    }
}