using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaveSpawner : MonoBehaviour {
	[System.Serializable]
	public class Wave{
		public Enemy[] enemies;
		public int count;
		public float timeBetweenSpawns;
	}

	public Wave[] waves;
	public Transform[] spawnPoints;
	public float timeBetweenWave;

	private Wave currentWave;
	public int currentWaveIndex;
	private Transform player;
	private bool finishedSpawning=false;

	public GameObject bossHealthBar;

	public GameObject boss,BossInstance=null;

	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").transform;
		currentWaveIndex=0;
		StartCoroutine(StartNextWave(currentWaveIndex));
	}

	IEnumerator StartNextWave(int waveIndex){
		yield return new WaitForSeconds(timeBetweenWave);
		StartCoroutine(SpawnWave(waveIndex));
	}
	IEnumerator SpawnWave(int waveIndex){
		currentWave=waves[waveIndex];
		if(player==null)
			yield return null;
		for(int i=0;i<currentWave.count;i++){
			Instantiate(currentWave.enemies[Random.Range(0,currentWave.enemies.Length)],spawnPoints[Random.Range(0,spawnPoints.Length)].position,Quaternion.identity);
			if(i==currentWave.count-1){
				finishedSpawning=true;
			}
			yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
		}
		if(waveIndex==waves.Length-1){
			Instantiate(boss,spawnPoints[Random.Range(0,spawnPoints.Length)].position,transform.rotation);
			bossHealthBar.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(finishedSpawning&&GameObject.FindGameObjectsWithTag("enemy").Length==0&&currentWaveIndex<waves.Length){
			currentWaveIndex++;
			finishedSpawning=false;
			if(currentWaveIndex<(waves.Length)){
				StartCoroutine(StartNextWave(currentWaveIndex));
			}
		}else if(finishedSpawning&&currentWaveIndex==waves.Length){
			if(GameObject.FindGameObjectWithTag("boss")==null&&GameObject.FindGameObjectsWithTag("enemy").Length==0){
				StartCoroutine(gameWon());
			}
		}
	}
	IEnumerator gameWon(){
		yield return new WaitForSeconds(3f);
		// FindObjectOfType<SceneTransition>()
	}
}
