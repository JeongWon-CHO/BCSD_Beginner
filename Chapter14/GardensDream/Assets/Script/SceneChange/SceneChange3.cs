using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange3 : MonoBehaviour
{
    public void ChangeStage3()
    {
        SceneManager.LoadScene("Boss");
    }
}