function iniciarMap(){
    var coord = {lat:-12.070713 ,lng: -76.941267};
    var map = new google.maps.Map(document.getElementById('map'),{
      zoom: 15,
      center: coord
    });
    var marker = new google.maps.Marker({
      position: coord,
      map: map
    });
}


 // Agrega un evento de escucha al formulario
 document.getElementById("bmi-form").addEventListener("submit", function(event) {
  event.preventDefault(); // Evita que se envíe el formulario
  
  const weight = document.getElementById("weight").value;
  const height = document.getElementById("height").value;
  
  calculateBMI(weight, height);
});

/*----------------------------------------API IMC-------------------------------------------------*/
// Realiza la llamada a la API y muestra los resultados

/*----------------------------------------------------------------------------------------------*/