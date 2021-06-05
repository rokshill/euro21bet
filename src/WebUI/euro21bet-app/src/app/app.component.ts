import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';

@Component({
	selector: 'e21b-root',
	templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
	public title = 'euro21bet-app';

	constructor(private primengConfig: PrimeNGConfig) { }

	public ngOnInit(): void {
		this.primengConfig.ripple = true;
	}
}
