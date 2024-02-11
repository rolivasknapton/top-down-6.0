using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetscene : MonoBehaviour
{
    public void ResetScence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}