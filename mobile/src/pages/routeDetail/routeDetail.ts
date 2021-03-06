import { Component } from '@angular/core';
import { NavController, Platform, NavParams } from 'ionic-angular';
import { Route } from '../routes/route';
import { GoogleMap, GoogleMapsEvent, GoogleMapsLatLng } from 'ionic-native';

@Component({
  selector: 'route-detail',
  templateUrl: 'routeDetail.html'
})
export class RouteDetail {
    map: GoogleMap;
    route: Route;
    constructor(public navCtrl: NavController, public platform: Platform, private navParams: NavParams) {
        this.route = navParams.data;
        platform.ready().then(() => {
            this.loadMap();
        });
    }
 
    loadMap(){
 
        let location = new GoogleMapsLatLng(-34.9290,138.6010);
 
        this.map = new GoogleMap('map', {
          'backgroundColor': 'white',
          'controls': {
            'compass': true,
            'myLocationButton': true,
            'indoorPicker': true,
            'zoom': true
          },
          'gestures': {
            'scroll': true,
            'tilt': true,
            'rotate': true,
            'zoom': true
          },
          'camera': {
            'latLng': location,
            'tilt': 30,
            'zoom': 15,
            'bearing': 50
          }
        });
 
        this.map.on(GoogleMapsEvent.MAP_READY).subscribe(() => {
            console.log('Map is ready!');
        });
 
    }
}
