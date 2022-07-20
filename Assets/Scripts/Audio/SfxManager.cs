using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class SfxManager : MonoBehaviour
    {
        public AudioSource Audio;
        public AudioClip DrawCard;
        public AudioClip TurnCard;
        public AudioClip PlaceCard;
        public AudioClip ButtonClick;

        public static SfxManager sfxInstance;

        private void Awake()
        {
            if (sfxInstance != null && sfxInstance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            sfxInstance = this;
            DontDestroyOnLoad(this);
        }
    }

}
