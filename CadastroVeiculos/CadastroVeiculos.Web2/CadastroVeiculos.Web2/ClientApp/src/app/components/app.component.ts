// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

import { Component, ViewEncapsulation, OnInit, OnDestroy, ViewChildren, AfterViewInit, QueryList, ElementRef } from "@angular/core";
import { Router, NavigationStart } from '@angular/router';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';
import { ModalDirective } from 'ngx-bootstrap/modal';

var alertify: any = require('../assets/scripts/alertify.js');

@Component({
    selector: "app-root",
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    encapsulation: ViewEncapsulation.None
})

export class AppComponent implements OnInit, AfterViewInit {

    isAppLoaded: boolean;
    shouldShowLoginModal: boolean;
    removePrebootScreen: boolean;
    appTitle = "CadastroVeiculos.Web2";
    appLogo = require("../assets/images/logo.png");

    stickyToasties: number[] = [];

    dataLoadingConsecutiveFailurs = 0;
    notificationsLoadingSubscription: any;
    
    constructor(private toastyService: ToastyService, private toastyConfig: ToastyConfig, public router: Router) {

        this.toastyConfig.theme = 'bootstrap';
        this.toastyConfig.position = 'top-right';
        this.toastyConfig.limit = 100;
        this.toastyConfig.showClose = true;
    }
    
    ngOnInit() {

        this.router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                let url = (<NavigationStart>event).url;

                if (url !== url.toLowerCase()) {
                    this.router.navigateByUrl((<NavigationStart>event).url.toLowerCase());
                }
            }
        });
    }

    ngOnDestroy() {
        this.unsubscribeNotifications();
    }

    private unsubscribeNotifications() {
        if (this.notificationsLoadingSubscription)
            this.notificationsLoadingSubscription.unsubscribe();
    }
}
