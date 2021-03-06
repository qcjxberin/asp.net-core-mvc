﻿var dig = {
    Loading: function () {
        $('.login').addClass('test');
        $('.login').addClass('testtwo');
        setTimeout(function () {
            $('.authent').show().animate({
                top: -100
            }, {
                easing: 'easeOutQuint',
                duration: 600,
                queue: false
            });
            $('.authent').animate({
                opacity: 1
            }, {
                duration: 200,
                queue: false
            }).addClass('visible')
        }, 500)
    },
    Success: function (result) {
        if (result.Status) {
            window.location.href = result.ReturnUrl
        } else {
            setTimeout(function () {
                $('.authent').show().animate({
                    right: 500
                }, {
                    easing: 'easeOutQuint',
                    duration: 600,
                    queue: false
                });
                $('.authent').animate({
                    opacity: 0
                }, {
                    duration: 200,
                    queue: false
                }).addClass('visible');
                $('.login').removeClass('testtwo')
            }, 2500);
            setTimeout(function () {
                $('.login').removeClass('test');
                $('.login div').fadeOut(123)
            }, 2800);
            setTimeout(function () {
                $('.success p:eq(0)').text(result.Msg);
                $('.success').fadeIn()
            }, 3200)
        }
    },
    Failure: function () {
        setTimeout(function () {
            $('.authent').show().animate({
                right: 90
            }, {
                easing: 'easeOutQuint',
                duration: 600,
                queue: false
            });
            $('.authent').animate({
                opacity: 0
            }, {
                duration: 200,
                queue: false
            }).addClass('visible');
            $('.login').removeClass('testtwo')
        }, 2500);
        setTimeout(function () {
            $('.login').removeClass('test');
            $('.login div').fadeOut(123)
        }, 2800);
        setTimeout(function () {
            $('.success p:eq(0)').text("认证失败");
            $('.success').fadeIn()
        }, 3200)
    },
    Complete: function () {
        $("#login-button").attr("disabled", false)
    },
    ErrorMsg: function (msg) {
        setTimeout(function () {
            $('.authent').show().animate({
                right: 90
            }, {
                easing: 'easeOutQuint',
                duration: 600,
                queue: false
            });
            $('.authent').animate({
                opacity: 0
            }, {
                duration: 200,
                queue: false
            }).addClass('visible');
            $('.login').removeClass('testtwo')
        }, 2500);
        setTimeout(function () {
            $('.login').removeClass('test');
            $('.login div').fadeOut(123)
        }, 2800);
        setTimeout(function () {
            $('.success p:eq(0)').text(msg);
            $('.success').fadeIn()
        }, 3200)
    },
    Back: function () {
        $('.login').addClass('test');
        $('.login').addClass('testtwo');
        $('.success p:eq(0)').text('');
        $('.authent').hide().animate({
            opacity: 0,
            top: 0,
            right: 0
        }, {
            duration: 200,
            queue: false
        }).removeClass('visible');
        setTimeout(function () {
            $('.login').removeClass('test');
            $('.login div').fadeIn(123);
            $('.success').hide();
            $("#imgVerify").prop("src", $("#imgVerify").prop("src") + "?")
        }, 500)
    }
};
function Particle(x, y, radius) {
    this.init(x, y, radius)
}
Particle.prototype = {
    init: function (x, y, radius) {
        this.alive = true;
        this.radius = radius || 10;
        this.wander = 0.15;
        this.theta = random(TWO_PI);
        this.drag = 0.92;
        this.color = '#fff';
        this.x = x || 0.0;
        this.y = y || 0.0;
        this.vx = 0.0;
        this.vy = 0.0
    },
    move: function () {
        this.x += this.vx;
        this.y += this.vy;
        this.vx *= this.drag;
        this.vy *= this.drag;
        this.theta += random(-0.5, 0.5) * this.wander;
        this.vx += sin(this.theta) * 0.1;
        this.vy += cos(this.theta) * 0.1;
        this.radius *= 0.96;
        this.alive = this.radius > 0.5
    },
    draw: function (ctx) {
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.radius, 0, TWO_PI);
        ctx.fillStyle = this.color;
        ctx.fill()
    }
};
var MAX_PARTICLES = 280;
var COLOURS = ['#69D2E7', '#A7DBD8', '#E0E4CC', '#F38630', '#FA6900', '#FF4E50', '#F9D423'];
var particles = [];
var pool = [];
var body = Sketch.create({
    container: document.getElementById('loginBody')
});
body.setup = function () {
    var i, x, y;
    x = (body.width * 0.5) + random(-100, 100);
    y = (body.height * 0.5) + random(-100, 100);
    body.spawn(0, 999)
};
body.spawn = function (x, y) {
    if (particles.length >= MAX_PARTICLES) pool.push(particles.shift());
    particle = pool.length ? pool.pop() : new Particle();
    particle.init(x, y, random(5, 40));
    particle.wander = random(0.5, 2.0);
    particle.color = random(COLOURS);
    particle.drag = random(0.9, 0.99);
    theta = random(TWO_PI);
    force = random(2, 8);
    particle.vx = sin(theta) * force;
    particle.vy = cos(theta) * force;
    particles.push(particle)
};
body.update = function () {
    var i, particle;
    for (i = particles.length - 1; i >= 0; i--) {
        particle = particles[i];
        if (particle.alive) particle.move();
        else pool.push(particles.splice(i, 1)[0])
    }
};
body.draw = function () {
    body.globalCompositeOperation = 'lighter';
    for (var i = particles.length - 1; i >= 0; i--) {
        particles[i].draw(body)
    }
};
body.mousemove = function () {
    var particle, theta, force, touch, max, i, j, n;
    for (i = 0, n = body.touches.length; i < n; i++) {
        touch = body.touches[i], max = random(1, 4);
        for (j = 0; j < max; j++) {
            body.spawn(touch.x, touch.y)
        }
    }
};