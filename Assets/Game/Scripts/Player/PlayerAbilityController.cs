using UnityEngine;

namespace GameJam.Player{
    public class PlayerAbilityController : MonoBehaviour{
        bool _shootAbility { get; set;} = false;
        bool _doubleJumpAbility { get; set;} = false;
        bool _climbWallAbility { get; set;} = false;
        bool _powerJumpAbility { get; set;} = false;
        
        public void UpdateAbility(bool canShoot, bool canClimbWall, bool canDoubleJump, bool canPowerJump){
            _shootAbility = canShoot;
            _climbWallAbility = canClimbWall;
            _doubleJumpAbility = canDoubleJump;
            _powerJumpAbility = canPowerJump;
        }
    }
}