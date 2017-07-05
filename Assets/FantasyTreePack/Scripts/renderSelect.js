var meshRendererList : MeshRenderer[];
private var currentMesh : int;

function Start(){
	ShowCurrentMeshOnly();
}

function Update () {
	if(Input.GetKeyDown(KeyCode.LeftArrow)){
		currentMesh --;
		if(currentMesh < 0){
			currentMesh = meshRendererList.Length - 1;
		}
		ShowCurrentMeshOnly();
	}
	if(Input.GetKeyDown(KeyCode.RightArrow)){
		currentMesh ++;
		if(currentMesh > meshRendererList.Length - 1){
			currentMesh = 0;
		}
		ShowCurrentMeshOnly();
	}	
}

function ShowCurrentMeshOnly(){
	for (var i = 0; i < meshRendererList.Length; i++){
		if(i == currentMesh){
			meshRendererList[i].enabled = true;
		}
		else{
			meshRendererList[i].enabled = false;
		}
	}
}
