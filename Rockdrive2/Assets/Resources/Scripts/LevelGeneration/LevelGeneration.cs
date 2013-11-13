using UnityEngine;
using System.Collections;

public class LevelGeneration : MonoBehaviour {
	GameObject block;
	public float minBlockLenght;
	public float maxBlockLenght;
	public float minBlockDislevel;
	public float maxBlockDislevel;
	public float minHoleLenght;
	public float maxHoleLenght;
	public int maxHoles;
	public int minHoles;
	public int roomWidth;
	public int roomHeight;
	public int[] roomEntrance;
	public int[] roomExit;
	public int stageLenght=1;
	public int[,,] roomData;
	public Vector3 roomTop;
	public int totalRooms= 5;
	public int currentRoom=0;
	// Use this for initialization
	void Start () {
		while(totalRooms>0){
			generateNextRoom();
			totalRooms--;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void generateNextRoom(){
		roomData= new int[roomWidth+1,roomHeight+1,50];
		Debug.Log("1");
		
		
		
		//Fills out the borders
		for(int i=0;i<=roomWidth;i++){
			for(int j=0;j<=roomHeight;j++){
				if(i==0||i==roomWidth||j==0||j==roomHeight)roomData[i,j,currentRoom]=1;
				else roomData[i,j,currentRoom]=0;
			}
		}
		
		//Hollows out borders between rooms
		for(int i=0;i<=roomWidth;i++){
			for(int j=0;j<=roomHeight;j++){
				if(i==0 && j==1 && currentRoom!=0) roomData[i,j,currentRoom]=0;
				if(i==roomWidth && j==1) roomData[i,j,currentRoom]=0;
			}
		}
		
		
		
		//Defines the positions of the room's holes
		int holesAdded=0;
		int numberHoles= Random.Range(minHoles,maxHoles);
		while(holesAdded< numberHoles){
			int holePos= Random.Range(0,roomWidth);
			if(roomData[holePos,0,currentRoom]!=0){
				roomData[holePos,0,currentRoom]=0;
				holesAdded++;
			}
		}
		
		//Creates dislevels
		
		
		//Finally, creates the blocks
		for(int i=0;i<=roomWidth;i++){	
			for(int j=0;j<=roomHeight;j++){
				if(roomData[i,j,currentRoom]==1){
					Vector3 roomPosition = new Vector3(i,j,0)+roomTop;
					
					block= Instantiate(Resources.Load("LevelPieces/Block"),roomPosition,Quaternion.identity) as GameObject;
					//block.transform.parent= levelContainer.transform;
				}
			}
		}
		
		roomTop=roomTop+ new Vector3(roomWidth,0,0);
		currentRoom++;
		//block= Instantiate(Resources.Load("LevelPieces/Block"),roomPosition,roomRotation) as GameObject;
		//block.transform.parent= levelContainer.transform;
	}
}
