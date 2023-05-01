// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function(event) { 
    // Obtener el elemento de la pantalla de carga
    var pantallaCarga = document.querySelector(".pantalla-carga");
  
    // Ocultar la pantalla de carga después de 3 segundos
    setTimeout(function() {
      pantallaCarga.classList.add("oculto");
    }, 1000);
  });