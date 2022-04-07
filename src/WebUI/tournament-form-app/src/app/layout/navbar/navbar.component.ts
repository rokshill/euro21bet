import { Component, OnInit } from "@angular/core";
import { ROUTES } from "@app/core/configs";
import { MenuItem } from "primeng/api";

@Component({
	selector: "roksh-navbar",
	templateUrl: "./navbar.component.html",
	styleUrls: ["./navbar.component.scss"],
})
export class NavbarComponent implements OnInit {
	public items: MenuItem[] = [];

	public ngOnInit(): void {
		this.items = [
			{ label: "Anonymous", routerLink: [ROUTES.ITEM, ROUTES.ANONYMOUS] },
			{ label: "User", routerLink: [ROUTES.ITEM, ROUTES.USER] },
			{ label: "Admin", routerLink: [ROUTES.ITEM, ROUTES.ADMIN] },
		];
	}
}
