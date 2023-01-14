using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title, score, highscore;
    [SerializeField] Button play, music, sound;
    [SerializeField] MusicManager MusicManage;

    private bool Music = true, Audio = true;

    private void Start()
    {
        score.gameObject.SetActive(false);
    }

    public void ChangeMenu(bool x)
    {
        title.gameObject.SetActive(x);
        score.gameObject.SetActive(!x);
        play.gameObject.SetActive(x);
    }

    public void ChangeAudio()
    {
        Audio = !Audio;
        MusicManage.MuteDie(Audio);
        MusicManage.MuteJump(Audio);
    }

    public void ChangeMusic()
    {
        Music = !Music;
        MusicManage.MuteMusic(Music);
    }
}