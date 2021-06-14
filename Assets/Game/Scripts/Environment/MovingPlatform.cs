using System.Collections;
using UnityEngine;

namespace GameJam.Environments{
    public class MovingPlayer : MonoBehaviour{
        [SerializeField] GameObject platformPathStart;
        [SerializeField] GameObject platformPathEnd;
        [SerializeField] float speed;

        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private Vector2 _currentPosition;

        void Start(){
            _startPosition = platformPathStart.transform.position;
            _endPosition = platformPathEnd.transform.position;
            StartCoroutine(Vector2LerpCoroutine(gameObject, _endPosition, speed));
        }

        void Update(){
            _currentPosition = transform.position;
            if(_currentPosition == _endPosition){
                StartCoroutine(Vector2LerpCoroutine(gameObject, _startPosition, speed));
            }else if(_currentPosition == _startPosition){
                StartCoroutine(Vector2LerpCoroutine(gameObject, _endPosition, speed));
            }
        }

        void OnTriggerStay2D(Collision2D collision){
            collision.gameObject.transform.SetParent(gameObject.transform,true);
        }

        void OnTriggerExit2D(Collision2D collision){
            collision.gameObject.transform.SetParent(null);
        }

        IEnumerator Vector2LerpCoroutine(GameObject obj, Vector2 target, float speed){
            Vector2 startPosition = obj.transform.position;
            Vector2 currentPosition = obj.transform.position;
            float time = 0;
            while(currentPosition != target){
                obj.transform.position = Vector2.Lerp(startPosition, target, (time/Vector2.Distance(startPosition,target)) * speed);
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}