var branchSound : AudioSource;

function Update () {
	if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
		branchSound.Play();
	}
}