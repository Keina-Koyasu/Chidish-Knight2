private var spinSpeed : float;

function Update () {
	if(Input.GetMouseButton(0)){
		var sign : int = Mathf.Sign(Input.GetAxis("Mouse X"));
		var expMouseX : float = Mathf.Pow(Mathf.Abs(Input.GetAxis("Mouse X")),1.3);
		spinSpeed -= expMouseX * sign * Time.deltaTime * 20;
	}
	transform.rotation.eulerAngles.y += spinSpeed;
	spinSpeed = Mathf.Lerp(spinSpeed, 0, Time.deltaTime * 10.0);
}