using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject taskField;
    [SerializeField]
    private GameObject task;
    [SerializeField]
    private GameObject tasksButton;
    [SerializeField]
    private GameObject closeButton;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenTasks()
    {
        taskField.SetActive(true);
        task.SetActive(true);
        closeButton.SetActive(true);
        tasksButton.SetActive(false);

    }
    public void CloseTasks()
    {
        taskField.SetActive(false);
        task.SetActive(false);
        tasksButton.SetActive(true);
        closeButton.SetActive(false);

    }


}
