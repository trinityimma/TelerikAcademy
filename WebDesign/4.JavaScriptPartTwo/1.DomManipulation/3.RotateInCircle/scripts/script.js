var angle = 0;

function move(circles, radius) {
    var i, currentAngle;

    var stepAngle = 2 * Math.PI / circles.length;

    for (i = 0; i < circles.length; i++) {
        currentAngle = stepAngle * i

        circles[i].style.left = Math.cos(angle + currentAngle) * radius + 'px';
        circles[i].style.top  = Math.sin(angle + currentAngle) * radius + 'px';
    }

    angle += 0.05;
}

(function animLoop() {
    var innerRadius = 100;
    var outerRadius = 150;

    var innerCircles = document.querySelectorAll('.js-circle-inner');
    var outerCircles = document.querySelectorAll('.js-circle-outer');

    move(innerCircles, innerRadius);
    move(outerCircles, outerRadius);

    requestAnimationFrame(animLoop);
 }());

// имаш ли време да
// да не те бавя с моите глупости нееее да напавим ещо друго
// но искам да си ги запазвам - не ги трий
// даже сега ще си копирам това

// // Move all circles
// var allCircles = document.querySelectorAll('.circle');
// window.addEventListener('mousemove', function(e) {
//     var i;

//     for (i = 0; i < allCircles.length; i++) {
//         allCircles[i].style.marginLeft = e.clientX + 'px';
//         allCircles[i].style.marginTop  = e.clientY + 'px';
//     }
// });
