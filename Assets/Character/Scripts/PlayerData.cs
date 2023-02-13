using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/PlayerData")]
internal class PlayerData : ScriptableObject
{
	[SerializeField] public float groundSpeed = 5;
	[SerializeField] public float airSpeed = 5;
	[SerializeField] public float hitForce = 2;
	[SerializeField] public float gravity = Physics.gravity.y;
	[SerializeField] public float turnRate = 10;
	[SerializeField] public float jumpHeight = 2;
}

