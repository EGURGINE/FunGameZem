using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] 
    public Dictionary<int, AudioClip> oAudioClipsMap = new Dictionary<int, AudioClip>();
    public AudioSource oAS_Once = null;
    public AudioSource oAS_Loop = null;

    private static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null) _instance = new SoundManager();
            return _instance;
        }
    }

    public void CreateDefaultAudioSource()
    {
        if (null != oAS_Once && null != oAS_Loop)
        {
            Debug.Log("Already Created Dafault AudioSources!");
            return;
        }

        GameObject oGameManager = GameObject.Find("SoundManager");
        {
            oGameManager = new GameObject("SoundManager");
            Debug.Assert(oGameManager != null, "Can not create new SoundManager GameeObject");
        }
        GameObject.DontDestroyOnLoad(oGameManager);

        oAS_Once = oGameManager.AddComponent<AudioSource>();
        oAS_Once.loop = false;

        oAS_Loop = oGameManager.AddComponent<AudioSource>();
        oAS_Loop.loop = true;
    }

    public void Regist(int iInAudioKey, AudioClip oInAudioClip)
    {
        Debug.Assert(oInAudioClip != null, "Invalid AudioClip! AudioKey= " + iInAudioKey.ToString());

        if (oAudioClipsMap.ContainsKey(iInAudioKey) == true)
        {
            Debug.Log("Already Registed AudioClip! AudioKey= " + iInAudioKey.ToString());
            return;
        }
        oAudioClipsMap.Add(iInAudioKey, oInAudioClip);
    }

    public void PlayAudioClip(int iInAudioKey, bool bIsLoop)
    {
        if (oAudioClipsMap.ContainsKey(iInAudioKey) == false)
        {
            Debug.Log("Not exist AudioClip! AudioKey= " + iInAudioKey.ToString());
            return;
        }

        if (bIsLoop)
        {
            Debug.Assert(oAS_Loop != null, "AudioSource is null!");
            oAS_Loop.Stop();
            oAS_Loop.clip = oAudioClipsMap[iInAudioKey];
            oAS_Loop.Play();
        }
        else
        {
            Debug.Assert(oAS_Once != null, "AudioSource is null!");
            oAS_Once.PlayOneShot(oAudioClipsMap[iInAudioKey]);
        }
    }
}