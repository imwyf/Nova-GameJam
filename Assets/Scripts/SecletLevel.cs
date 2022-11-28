using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecletLevel : MonoBehaviour
{
    public void SecletScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
