using UnityEngine;
using System.Collections;

public class GenerateRoom : MonoBehaviour {
	string[,] Level;
	public int levelNumber=0;
	public GameObject[,] Rooms;
	float initialposition;
	int gridWidth= 5;
	int gridHeight= 5;
	int roomTypes= 4;
	public float cellSize=1f;
	public int roomScale=1;
	public string[,] RoomCodes;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	[ContextMenu ("Build New Level")]
	
	void BuildLevel(){
		
		//		LEVEL5
		Level= new string[,]{
			
			{"W"	,"W"	,"W"	,"W"	,"W"},
			{"W"	,"O"	,"O"	,"O"	,"W"},
			{"W"	,"O"	,"O"	,"O"	,"W"},
			{"W"	,"O"	,"O"	,"O"	,"W"},
			{"W"	,"W"	,"D"	,"W"	,"W"},

		};
		
		RoomCodes= new string[,]{
			{"W"	,"WallCell"},
			{"w"	,"Wall"},
			{"D"	,"Door"},
			{"O"	,"GroundCell"}
			
		};
		
		GameObject levelContainer= new GameObject("LevelContainer"+levelNumber);
		
		
		for (int i=0;i<=gridHeight-1;i++){
			Debug.Log("i="+i);
			for (int j=0;j<=gridWidth-1;j++){
				Debug.Log("j="+j);
				if(Level[i,j]!=null){
					for(int k=0;k<roomTypes;k++){
						//Debug.Log("k="+k);
						if(RoomCodes[k,0]!=null && Level[i,j]==RoomCodes[k,0]){
							Vector3 roomPosition = new Vector3(roomScale*cellSize*i,0,roomScale*cellSize*j);
							//if(Level[i,j]=="W")roomPosition= new Vector3(roomScale*cellSize*i,0.5f,roomScale*cellSize*j);
							
							//Quaternion roomRotation= Quaternion.Euler(0,float.Parse(RoomCodes[k,2]),0);
							Quaternion roomRotation= Quaternion.Euler(0,0,0);
							Debug.Log(RoomCodes[k,1]);
							GameObject newRoom;
							if(GameObject.Find("Room_"+i+"x"+j)==null){
								newRoom= Instantiate(Resources.Load("LevelPieces/"+RoomCodes[k,1]),roomPosition,roomRotation) as GameObject;
								newRoom.transform.parent= levelContainer.transform;
								//newRoom.transform.localScale= new Vector3(roomScale,roomScale,roomScale);
								newRoom.name="Room_"+i+"x"+j;
							}
							
						}
						
					}
					
				}
			}
		}
	}
}
