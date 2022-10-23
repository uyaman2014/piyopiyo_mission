using System;
using Cysharp.Threading.Tasks;
using Manager;
using UI.Result;
using UnityEngine;

namespace keigo.Scripts.UI.DemoKeigo
{
    public class ResultDemo : MonoBehaviour
    {
        private WindowManager _windowManager;

        private void Start()
        {
            GameObject.FindWithTag("WindowManager").TryGetComponent(out _windowManager);
            
            UniTask.Create(async () =>
            {
                await UniTask.Delay(TimeSpan.FromSeconds(2));
                await _windowManager.OpenWindow<ResultWindow>();
            });
        }
    }
}