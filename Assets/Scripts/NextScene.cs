using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public static bool isCheck1;
    public static bool isCheck2;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player 1")
            isCheck1 = true;
        if (other.gameObject.name == "Player 2")
            isCheck2 = true;
        if (isCheck1 && isCheck2) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isCheck1 = false;
        isCheck2 = false;
    }
}