using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
    [HideInInspector]
    public bool m_isSceneReady = false;

    private AsyncOperation mAsyncOperation;
    private int mCurProgress = 0;

    void Start()
    {

    }

    public void StartLoadGame()
    {
        StartCoroutine(LoadScene());
    }

    public bool IsSceneReady()
    {
        return mAsyncOperation.progress >= 0.8f;
    }

    public void EnterGame()
    {
        mAsyncOperation.allowSceneActivation = true;
    }

    private IEnumerator LoadScene()
    {
        mAsyncOperation = SceneManager.LoadSceneAsync("Game");
        // 不允许加载完毕自动切换场景，因为有时候加载太快了就看不到加载进度条UI效果了
        mAsyncOperation.allowSceneActivation = false;
        // mAsyncOperation.progress测试只有0和0.9(其实只有固定的0.89...)
        // 所以大概大于0.8就当是加载完成了
        while (!mAsyncOperation.isDone && mAsyncOperation.progress < 0.8f)
        {
            yield return mAsyncOperation;
        }
    }

    void Update()
    {
        //// 以下都是为实现加载进度条的
        //int progressBar = 0;
        //if (mAsyncOperation.progress < 0.8)
        //    progressBar = (int)(mAsyncOperation.progress * 100);
        //else
        //    progressBar = 100;
        //if (mCurProgress <= progressBar)
        //{
        //    mCurProgress++;
        //    // 进度条ui显示（本文不讨论） 
        //    ((Win_Loading)UIWindowCtrl.GetInstance().GetCurrentWindow()).loadingView.SetLoadSceneInfo(mCurProgress * 0.01f);
        //}
        //else
        //{
        //    // 必须等进度条跑到100%才允许切换到下一场景
        //    if (progressBar == 100) mAsyncOperation.allowSceneActivation = true;
        //}
    }
}
