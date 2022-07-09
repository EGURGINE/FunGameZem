using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject setWnd;
    private bool isSet = false;
    public void SetWndON()
    {
        if (isSet == false)
        {
            isSet = true;
            setWnd.transform.DOLocalMoveX(0, 1f);
        }
        else if (isSet)
        {
            isSet = false;
            setWnd.transform.DOLocalMoveX(1200, 1f);

        }
    }

    public void Title()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
