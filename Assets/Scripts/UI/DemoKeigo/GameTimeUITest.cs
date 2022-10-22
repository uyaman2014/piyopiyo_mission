﻿using UI.Game;
using UnityEngine;

namespace UI.DemoKeigo
{
    public class GameTimeUITest : MonoBehaviour
    {
        [SerializeField] private GameTimeUI timeUI;

        private void Start()
        {
            timeUI.SetMaxTimeSec(20);
        }

        private void FixedUpdate()
        {
            timeUI.IncreaseElapsedSec(Time.fixedDeltaTime);
        }
    }
}