using GameJam.Attributes;
using GameJam.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam.System{
    public class UIController : Singleton<UIController>{
        [SerializeField] TextMeshProUGUI player1ScoreText;
        [SerializeField] TextMeshProUGUI player2ScoreText;
        [SerializeField] RectTransform hp;

        float barWidth;
        float initialBarWidth;
        HealthController healthController;
        bool isShowHP = false;
        GameObject healthBar;

        override protected void Init() {
            healthBar = transform.GetChild(0).GetChild(0).gameObject;
            healthController = GameObject.FindObjectOfType<HealthController>();
            initialBarWidth = barWidth = hp.sizeDelta.x;
        }
        
         void OnEnable(){
            healthController = GameObject.FindObjectOfType<HealthController>();
            barWidth = initialBarWidth;
        }
        
        private void Update() {
            UpdateHealth();
            UpdateScore();
        }

        // protected override void Init()
        // {
        //     barWidth = healthBar.sizeDelta.x;
        // }

        public void DisableHealthBar(){
                healthBar.SetActive(false);
        }

        public void EnableHealthBar(){
                healthBar.gameObject.SetActive(true);
        }

        public void UpdateHealth(){
            if(healthController == null){
                healthController = GameObject.FindObjectOfType<HealthController>();
            }
            Vector2 size = hp.sizeDelta;
            size.x = barWidth * healthController.GetFraction();
            // size.x = barWidth * HealthController.GetInstance().GetFraction();
            hp.sizeDelta = size;
        }

        public void UpdateScore(){
            float p1score = GameManager.GetInstance().GetPlayer1Score();
            float p2score = GameManager.GetInstance().GetPlayer2Score();
            player1ScoreText.SetText("Score: " + p1score);
            player2ScoreText.SetText("Score: " + p2score);
        }

    }
}