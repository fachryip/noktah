using System.Collections;
using UnityEngine;

namespace Noktah
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerModel PlayerPrefab;

        private void Start()
        {
            GameplayModel.Singleton.OnStageLoaded += SpawnPlayer;
        }

        private void SpawnPlayer()
        {
            var player = Instantiate(PlayerPrefab.gameObject).GetComponent<PlayerModel>();
            player.transform.position = GameplayModel.Singleton.Stage.RespawnLocation.position;

            GameplayModel.Singleton.Player = player;
        }
    }
}