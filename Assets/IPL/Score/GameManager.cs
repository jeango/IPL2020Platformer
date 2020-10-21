using UnityEngine;

namespace IPL
{
    public class GameManager : SingletonMb<GameManager>
    {
        [SerializeField] private ScoreManager scoreManager;
        public ScoreManager ScoreManager => scoreManager;

        protected override void Initialize()
        {
        }
        protected override void Cleanup()
        {
        }
    }
}