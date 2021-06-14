using GameJam.Player;
using UnityEngine;

namespace GameJam.Manager{
    public class GameManager : Singleton<GameManager>{

        // GameManager _instance;
        PlayerAbilityController _playerAbilityController = null;
        [SerializeField] int _player1Score = 0;
        [SerializeField] int _player2Score = 0;

        #region playerProgression
        bool _canShoot = false;
        bool _canDoubleJump = false;
        bool _canClimbWall = false;
        bool _canPowerJump = false;
        #endregion
        // Awake(){
        //     if(_instance!=null&&_instance!=this){
        //         Destroy(this);
        //         return;
        //     }
        //     _instance = this;
        //     _playerAbilityController = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityController>();
        // }

        // public static GetInstance(){
        //     if(_instance == null)
        //         _instance = new PickupManager();
        //     return _instance;
        // }

        protected override void Init()
        {
            _playerAbilityController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilityController>();
        }

        public void AddPlayer1Score(int score){
            _player1Score += score;
        }

        public void AddPlayer2Score(int score){
            _player2Score += score;
        }

        public void RestScore(){
            _player1Score = 0;
            _player2Score = 0;
        }

        public float GetPlayer1Score(){
            return _player1Score;
        }

        public float GetPlayer2Score(){
            return _player2Score;
        }

        #region ActivatePlayerAbility
        public void ActivateAbility(PlayerAbility ability){
            switch(ability){
                case PlayerAbility.shoot:
                    _canShoot = true;
                    break;
                case PlayerAbility.doubleJump:
                    _canDoubleJump = true;
                    break;
                case PlayerAbility.climbWall:
                    _canClimbWall = true;
                    break;
                case PlayerAbility.powerJump:
                    _canPowerJump = true;
                    break;
            }
            UpdatePlayerAbility();
        }

        private void UpdatePlayerAbility(){
            _playerAbilityController.UpdateAbility(_canShoot,_canClimbWall,_canDoubleJump,_canPowerJump);
        }
        #endregion
    }
}