using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Main : MonoBehaviour
{
    [SerializeField] private GameObject a;
    [SerializeField] private GameObject b;
    [SerializeField] private GameObject c,d,e,f,g,h;
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
        //a.transform.DOLocalMoveX(-400, 1f).SetLoops(1, LoopType.Incremental);
        //f.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionGame()
    {
        a.transform.DOLocalMoveX(-400, 1f).SetLoops(1, LoopType.Incremental);
        Option();
        Application.Quit();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Option()
    {
        c.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);/*.OnComplete(
            () =>
            {
                SoundManager.instance.PlayAudioClip(1 , false);

            });*/

        Application.Quit();
    }
    
    public void OptionBack()
    {
        a.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
        c.transform.DOLocalMoveX(300, 1f).SetLoops(1, LoopType.Incremental);

        Application.Quit();
    }

    public void QuitGame()
    {
        //d.transform.DOLocalMoveX(-6, 1).SetLoops(-1, LoopType.Restart);
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GamePlay()
    {

        b.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);

        Application.Quit();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void GamePlayBack()
    {
        a.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
        b.transform.DOLocalMoveX(300, 1f).SetLoops(1, LoopType.Incremental);
        Application.Quit();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void CreditButton()
    {
        c.transform.DOLocalMoveX(-300, 1f).SetLoops(1, LoopType.Incremental);
        Credit();
        Application.Quit();
    }

    public void Credit()
    {
        d.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
        Application.Quit();
    }

    public void CreditBack()
    {
        d.transform.DOLocalMoveX(300, 1f).SetLoops(1, LoopType.Incremental);
        c.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
        Application.Quit();
    }

    public void TutorialButton()
    {
        e.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
        b.transform.DOLocalMoveX(-300, 1f).SetLoops(1, LoopType.Incremental);
    }

    public void TutorialBack()
    {
        e.transform.DOLocalMoveX(300, 1f).SetLoops(1, LoopType.Incremental);
        b.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
    }

    public void Ingame()
    {
         SceneManager.LoadScene("Main");
    }

    public void GameClose1()
    {
        f.transform.DOLocalMoveY(400, 1f).SetLoops(1, LoopType.Incremental);
        g.transform.DOLocalMoveY(0, 1f).SetLoops(1, LoopType.Incremental);
    }

    public void GameClose2()
    {
        f.transform.DOLocalMoveY(0, 1f).SetLoops(1, LoopType.Incremental);
        g.transform.DOLocalMoveY(-400, 1f).SetLoops(1, LoopType.Incremental);
    }

    public void ReStart()
    {
        g.transform.DOLocalMoveY(-400, 1f).SetLoops(1, LoopType.Incremental);
        b.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
        f.transform.DOLocalMoveX(300, 1f).SetLoops(1, LoopType.Incremental);
        f.transform.DOLocalMoveY(0, 1f).SetLoops(1, LoopType.Incremental);
    }

    public void Home()
    {
        a.transform.DOLocalMoveX(0, 1f).SetLoops(1, LoopType.Incremental);
        g.transform.DOLocalMoveY(-400, 1f).SetLoops(1, LoopType.Incremental);
        f.transform.DOLocalMoveX(300, 1f).SetLoops(1, LoopType.Incremental);
        f.transform.DOLocalMoveY(0, 1f).SetLoops(1, LoopType.Incremental);
    }

    public void Close()
    {
        Debug.Log("게임을 종료합니다.");
    }
}