
/**
   * Create google map
   */
function initMap() {
    var uluru = { lat: 43.2228149, lng: 27.9250262 };
    var map = new google.maps.Map(document.getElementById('map'),
        {
            zoom: 13,
            center: uluru
        });
    var marker = new google.maps.Marker({
        position: uluru,
        map: map
    });
}

/**
   * Create facebook buttons
   */
(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s);
    js.id = id;
    js.src = "//connect.facebook.net/bg_BG/sdk.js#xfbml=1&version=v2.9&appId=1689139458055428";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));