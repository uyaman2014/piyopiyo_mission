using System;
using Manager;
using UnityEngine;

namespace UI.Game
{
    public class GameSceneInitializer : MonoBehaviour
    {
        private void Start()
        {
            BgmManager.Instance.Transition(1);
        }
    }
}