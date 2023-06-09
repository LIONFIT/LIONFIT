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
