// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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
