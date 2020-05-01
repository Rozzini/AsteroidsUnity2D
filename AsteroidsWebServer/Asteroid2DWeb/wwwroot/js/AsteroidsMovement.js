var x;
var changeDirection;
var image;


function preload() {
	image = loadImage('AsteroidType2.png');
}

function setup() {
	createCanvas(1920, 1080);
	x = 1;
	changeDirection = false;
}

function draw() {
	background(220);
	ellipse(x, 50, 50);
	if (x > width) {
		changeDirection = true
	}

	else if (x <= 0) {
		changeDirection = false
	}

	if (x >= 0 && changeDirection == false) {
		x = x + 1
	}

	else if (changeDirection == true) {
		x = x - 1
	}

}