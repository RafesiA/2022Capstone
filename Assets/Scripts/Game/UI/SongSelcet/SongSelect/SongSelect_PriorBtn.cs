using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SongSelctBtn
{
    [System.Obsolete("�̱��� ��ư")]
    public class SongSelect_PriorBtn : UIButton
    {
        public override void ClickEvent()
        {/*
            //AudioManager.intance.PlaySFX("Touch");
            Debug.Log("Prior Song");

            if (--currentSong < 0)
                currentSong = songList.Length - 1;
            SettingSong(); */
            SoundManager.Instance.PlaySFXSound("metronome_tick");

            //GameObject.Find("Canvas")
            //   .transform.Find("Select")
            //   .transform.Find("Disk")
            //   .transform.Find("Mask")
            //   .transform.Find("SongImage").GetComponent<SongSelect>().currentSong -= 1;

            //5/05
            GameObject.Find("Canvas")
                .transform.Find("Select").GetComponent<StageMenu>().currentSong -= 1;
            //�̹����� �ȹٲ�..

            Debug.Log("Preivous Song");
        }
    }
}