
using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class GameManager : Singleton<GameManager>
    {
        private bool _paused = true;
        private bool _invokedUnpause;

        [SerializeField] private GameObject _startButton;
        [SerializeField] private GameObject _pauseButton;

        public bool Paused => _paused;

        private void Start()
        {
            _pauseButton.SetActive(false);
        }

        public void TogglePause()
        {
            if (_invokedUnpause)
            {
                return;
            }
            if (_paused)
            {
                _invokedUnpause = true;
                Invoke(nameof(UnpauseGame), 1f);
            }
            else
            {
                PauseGame();
            }
        }

        public void TogglePause(bool paused)
        {
            if (_invokedUnpause)
            {
                return;
            }
            if (paused)
            {
                PauseGame();
            }
            else
            {
                _invokedUnpause = true;
                Invoke(nameof(UnpauseGame), 1f);
            }
        }

        private void PauseGame()
        {
            _paused = true;
        }

        private void UnpauseGame()
        {
            _paused = false;
            _invokedUnpause = false;
        }

        public void NewGame()
        {
            _startButton.SetActive(false);
            SoundManager.StaticInstance.PlaySound(SoundType.StartGame);
            StartCoroutine(NewGameAction());
        }

        private IEnumerator NewGameAction()
        {
            yield return new WaitForSeconds(0.5f);
            Player.StaticInstance.Revive();
            RoomSpawner.StaticInstance.SpawnStartRoom();
            yield return new WaitForSeconds(2f);
            TogglePause(false);
            _pauseButton.SetActive(true);
            SoundManager.StaticInstance.AmbientSource.Play();
        }

        public void GameOver()
        {
            _pauseButton.SetActive(false);
            SoundManager.StaticInstance.AmbientSource.Stop();
            TogglePause(true);
            StartCoroutine(GameOverAction());
        }

        private IEnumerator GameOverAction()
        {
            yield return new WaitForSeconds(2f);
            SoundManager.StaticInstance.PlaySound(SoundType.GameOver);
            yield return new WaitForSeconds(2f);
            RoomSpawner.StaticInstance.ClearRooms();
            _startButton.SetActive(true);
        }
    }
}