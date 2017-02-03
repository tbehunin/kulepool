import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { Route } from './route'
import { RouteDetail } from '../routeDetail/routeDetail'

@Component({
  selector: 'page-routes',
  templateUrl: 'routes.html'
})
export class RoutesPage {
    items: Route[];

    constructor(public navCtrl: NavController) {
        this.items = [
            { id: 1, number: 24, name: 'Tucson Street' },
            { id: 2, number: 25, name: 'Main Street' },
            { id: 3, number: 26, name: 'Foo Street' }
        ];
    }

    itemSelected(item: Route) {
        this.navCtrl.push(RouteDetail, item);
    }
}
