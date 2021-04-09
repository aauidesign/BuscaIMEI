function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

$(document).ready(function () {

    var msgSucesso = getParameterByName("msgSucesso");

    if (msgSucesso != null && msgSucesso.length > 0) {

        alert("--------Sucesso--------\r\n" + msgSucesso);
    }

    var msgErro = getParameterByName("msgErro");

    if (msgErro != null && msgErro.length > 0) {

        alert("--------Erro--------\r\n" + msgErro);
    }
});

////Inicio do Script para o navbar fixo descer junto com a rolagem da página-- >
//jQuery(document).ready(function ($) {
//    $(window).scroll(function () {
//        if ($(this).scrollTop() > 100) {
//            $('nav').addClass('fixed-top p-3 mb-5 bg-white rounded');
//        } else {
//            $('nav').removeClass('fixed-top p-3 mb-5 bg-white rounded');
//        }
//    });
//});

////Fim do Script para o navbar fixo descer junto com a rolagem da página-- >
////Inicio do Script para mostrar a senha ao fazer o login-- >

//const olho = document.querySelector('#olho');
//const senha = document.querySelector('#Senha');

//olho.onclick = function (event) {
//    event.preventDefault();

//    let type = senha.getAttribute('type');

//    if (type == 'password') {
//        senha.setAttribute('type', 'text');

//        $('.fa').removeClass('fa-eye-slash');
//        $('.fa').addClass('fa-eye');

//    }

//    if (type == 'text') {
//        senha.setAttribute('type', 'password');

//        $('.fa').removeClass('fa-eye');
//        $('.fa').addClass('fa-eye-slash');

//    }
//}

////Fim do Script para mostrar a senha ao fazer o login-- >
////Inicio do Script verificar se o usuário apertou o Capslok do teclado-- >

//$(document).ready(function () {

//    $('#Senha').on('keypress', function (e) {

//        kc = e.keyCode ? e.keyCode : e.which;
//        sk = e.shiftKey ? e.shiftKey : ((kc == 16) ? true : false);

//        if (((kc >= 65 && kc <= 90) && !sk) || (kc >= 97 && kc <= 122) && sk) {

//            $("#msg-capslok").html('<div class="alert alert-danger text-center text-uppercase font-weight-bold" role="alert">CapsLok Ativo!</div>');
//        }

//        else {
//            $("#msg-capslok").html('<div class="" role="alert"></div>');
//        }
//    });
//});


////Fim do Script verificar se o usuário apertou o Capslok do teclado-- >
////Inicio do Script validar campos do cadastro de login-- >

////$(document).ready(function () {
////    $('#insert_form').on('submit', function (event) {
////        event.preventDefault();


////        if ($('#Senha').val() == "") {
////            //Alerta de campo senha vazio
////            $("#msg-error").html('<div class="alert alert-warning alert-dismissible fade show" role="alert">Necessário prencher o campo senha!!<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
////        }

////        else if ($('#Senha').val().length <= 5) {
////            //Necessário prencher o campo senha com mínimo 6 caracteres!
////            $("#msg-error").html('<div class="alert alert-warning alert-dismissible fade show" role="alert">Necessário prencher o campo senha com mínimo 6 caracteres!!<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
////        }

////        else if ($('#rep_senha').val() == "") {
////            //Necessário prencher o campo confirmar senha!
////            $("#msg-error").html('<div class="alert alert-warning alert-dismissible fade show" role="alert">Necessário prencher o campo confirmar senha!!<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
////        }


////        else if ($('#rep_senha').val().length <= 5) {
////            //Necessário prencher o campo confirmar senha com mínimo 6 caracteres!
////            $("#msg-error").html('<div class="alert alert-warning alert-dismissible fade show" role="alert">Necessário prencher o campo confirmar senha com mínimo 6 caracteres!!<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
////        }

////        else if ($('#rep_senha').val() != "" && $('#senha').val() == "") {
////            //Necessário prencher o campo senha primeiro!
////            $("#msg-error").html('<div class="alert alert-warning alert-dismissible fade show" role="alert">Necessário prencher o campo senha primeiro!!<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
////        }

////        else if ($('#senha').val() != $('#rep_senha').val()) {
////            //As senhas não conferem!
////            $("#msg-error").html('<div class="alert alert-warning alert-dismissible fade show" role="alert">As senhas não conferem!!<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
////        }


////        else {
////            //Tudo certo obrigado!
////            $("#msg-error").html('<div class="alert alert-success alert-dismissible fade show" role="alert">Tudo certo obrigado!!<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
////        }

////    });
////});

////Fim do Script validar campos do cadastro de login-- >
////Inicio do Script da animação do botão de Cadastrar no navbar-- >

//var pfx = ["webkit", "moz", "MS", "o", ""];
//function prefixedEventListener(element, type, callback) {
//    for (var p = 0; p < pfx.length; p++) {
//        if (!pfx[p]) type = type.toLowerCase();
//        element.addEventListener(pfx[p] + type, callback, false);


//    }
//}

//var btnShake = document.querySelector("#btnSwing");

//prefixedEventListener(btnShake, "AnimationEnd", function (e) {
//    btnShake.classList.remove("swing");
//    setTimeout(function () { btnShake.classList.add("swing"); }, 300);

//});

////Fim do Script da animação do botão de Cadastrar no navbar-- >
////Inicio do Script que starta as animações de acrodo com o Scroll da pagina-- >

//const debounce = function (func, wait, immediate) {
//    let timeout;
//    return function (...args) {
//        const context = this;
//        const later = function () {
//            timeout = null;
//            if (!immediate) func.apply(context, args);
//        };
//        const callNow = immediate && !timeout;
//        clearTimeout(timeout);
//        timeout = setTimeout(later, wait);
//        if (callNow) func.apply(context, args);
//    };
//};

//const target = document.querySelectorAll('[data-anime]');
//const animationClass = 'animate';

//function animeScroll() {
//    const windowTop = window.pageYOffset + (window.innerHeight * 0.75);
//    target.forEach((element) => {
//        console.log('i')
//        if (windowTop > element.offsetTop) {
//            element.classList.add(animationClass);
//        } else {

//        }
//    })
//}


//const handleScroll = debounce(animeScroll, 50);

//if (target.length) {
//    window.addEventListener('scroll', handleScroll);
//}

////Fim do Script que starta as animações de acrodo com o Scroll da pagina-- >
////Inicio do Script de Habilitar botão registar atraves do checkbox-- >

//$("[name='toggle']").click(function () {
//    var cont = $("[name='toggle']:checked").length;
//    $("#aplica").prop("disabled", cont ? false : true);

//});

//    //Fim do Script de Habilitar botão registar atraves do checkbox-- >