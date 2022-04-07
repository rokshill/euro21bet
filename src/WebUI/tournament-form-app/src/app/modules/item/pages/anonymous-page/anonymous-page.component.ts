import { Component, OnInit } from "@angular/core";
import { ItemClient } from "@app/web-api-client";
import { BehaviorSubject } from "rxjs";

@Component({
	selector: "roksh-anonymous-page",
	templateUrl: "./anonymous-page.component.html",
	styleUrls: ["./anonymous-page.component.scss"],
})
export class AnonymousPageComponent implements OnInit {
	public isLoading: BehaviorSubject<boolean> = new BehaviorSubject(true);

	constructor(private itemService: ItemClient) {}

	public ngOnInit(): void {
		this.itemService.anonymousPage().subscribe();
	}
}
