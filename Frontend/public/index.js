async function getData() {
  let url = "https://localhost:7110/Location"
  let response = await fetch(url, {
    method: "GET",
    mode: "cors",
  })
  let result = response.json()
  return result
}

function initMap() {
  const map = new google.maps.Map(document.getElementById("myMap"), {
    center: { lat: 33.4484, lng: -112.074 },
    zoom: 5,
  });
  
  getData().then(data => {
    for (let i = 0; i < data.length; i++) {
      const latLng = new google.maps.LatLng(data[i].location.position.latitude, data[i].location.position.longitude)
      const marker = new google.maps.Marker({
        position: latLng,
        map: map
      })
      const content = `<div class="flex">${data[i].location.name}<img style="height: 10rem; width: 12rem"src=${data[i].urls.small} alt="picture"/></div>`
      const infowindow = new google.maps.InfoWindow({
        content: content
      });
      hoverWindow(marker, infowindow);
    }
    
  })
  function hoverWindow(marker, infowindow) {
    marker.addListener("mouseover", () => {
      infowindow.open({
        anchor: marker,
        map,
        shouldFocus: false
      })
    })
    marker.addListener("mouseout", () => {
      infowindow.close({
        anchor: marker,
        map,
        shouldFocus: false
      })
    })
  }
  
}










// let pin;
// function getMap() {
//   let map = new Microsoft.Maps.Map("#myMap", {
//     credentials:
//     "As_70EZZsXnDelGCe9Md4mj2cKffdTWMGQwwRgUGjxxMpiVB89WWGRlfJVh1DG_q",
//     center: new Microsoft.Maps.Location(33.4484, -112.074),
//     zoom: 5,
//   })
  
  
//   let center = map.getCenter()

//   // getData().then((data) => {
//   //   data.map(d => {
//   //     locationData.push(d)
//   //   })
//   // })
//   // var locationData = [];
//   // console.log(locationData[0]);
//   // for (let i = 0; i < locationData.length; i++) {
//   //   pin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(locationData[i].location.position.latitude, locationData[i].location.position.longitude), {
//   //     title: locationData[i].location.name,
//   //     color: "#10B981"
//   //   })
//   //   map.entities.push(pin)
//   //   pin.metadata = {
//   //     title: locationData[i].location.name
//   //   }
//   // }
//   let pin;
//   getData().then((data) => {
//     //console.log(data[0].location.position.latitude)
//     for (let i = 0; i < data.length; i++) {
//       pin = new Microsoft.Maps.Pushpin(
//         new Microsoft.Maps.Location(
//           data[i].location.position.latitude,
//           data[i].location.position.longitude
//         ),
//         {
//           title: data[i].location.name,
//           color: "#10B981",
//         }
//       )
//       map.entities.push(pin)
//       pin.metadata = {
//         title: data[i].location.name,
//       }
//       Microsoft.Maps.Events.addHandler(pin, "mouseover", pushpinEnter)
//       Microsoft.Maps.Events.addHandler(pin, "mouseout", pushpinExit)


//       let infobox = new Microsoft.Maps.Infobox((pin.getLocation()), {
//         visible: false,
//       })
//       infobox.setMap(map)
//     }
//     function pushpinEnter(e) {
//       //Make sure the infobox has metadata to display.
//       if (e.target.metadata) {
//         //Set the infobox options with the metadata of the pushpin.
//         infobox.setOptions({
//           visible: true,
//           title: e.target.metadata.title,
//           description: e.target.metadata.description,
//           location: e.target.getLocation(),
//           //htmlContent: infoboxTemplate.replace('{title}', e.target.metadata.title).replace('{description}', e.target.metadata.description),
//         })
//       }
//     }
//     //leave pushpin
//     function pushpinExit(e) {
//       infobox.setOptions({
//         visible: false,
//       })
//     }
//   })
// }
