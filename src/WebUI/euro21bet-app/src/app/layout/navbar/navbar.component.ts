import { Component, OnInit } from '@angular/core';
import { ROUTES } from '@app/core/configs';
import { MenuItem } from 'primeng/api';

@Component({
	selector: 'e21b-navbar',
	templateUrl: './navbar.component.html',
	styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

	public items: MenuItem[] = [];

	public ngOnInit(): void {
		this.items = [
			{ label: 'Mecze', routerLink: [ROUTES.MATCH] },
			{ label: 'Tabele', routerLink: [ROUTES.STANDINGS] },
			{ label: 'Drużyny', routerLink: [ROUTES.TEAM] }
		];
	}
}
