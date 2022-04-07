import { Component, OnInit } from "@angular/core";
import { ItemClient } from "@app/web-api-client";

@Component({
	selector: "roksh-user-page",
	templateUrl: "./user-page.component.html",
	styleUrls: ["./user-page.component.scss"],
})
export class UserPageComponent implements OnInit {
	constructor(private itemService: ItemClient) {}

	public ngOnInit(): void {
		this.itemService.userPage().subscribe();
	}
}
