using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class Prologue : MonoBehaviour
{
    public PlayableDirector playableDirector;

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        SceneChanger scene = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneChanger>();
        scene.ChangeSceneIndex(1);
        scene.ChangeScene();
    }
}
