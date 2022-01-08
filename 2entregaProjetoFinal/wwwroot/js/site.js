// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function () {
  'use strict';
  window.addEventListener('load', function () {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName('needs-validation');
    // Loop over them and prevent submission
    var validation = Array.prototype.filter.call(forms, function (form) {
      form.addEventListener('submit', function (event) {
        if (form.checkValidity() === false) {
          event.preventDefault();
          event.stopPropagation();
        }
        form.classList.add('was-validated');
      }, false);
    });
  }, false);
})();

// script do menu lateral
const botao = document.getElementById('btn-test')
const menu = document.getElementById('1')

botao.addEventListener("click", () =>{
    console.log('evento')
    if( menu.classList.contains("esconder")){
        menu.classList.remove('esconder')
        menu.classList.add('mostrar')
    }else{
        menu.classList.remove('mostrar')
        menu.classList.add('esconder')
    }
})
