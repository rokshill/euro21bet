import { Component, OnInit } from "@angular/core";
import { ItemClient } from "@app/web-api-client";

@Component({
	selector: "roksh-admin-page",
	templateUrl: "./admin-page.component.html",
	styleUrls: ["./admin-page.component.scss"],
})
export class AdminPageComponent implements OnInit {
	constructor(private itemService: ItemClient) {}

	public ngOnInit(): void {
		this.itemService.adminPage().subscribe();
	}
}
