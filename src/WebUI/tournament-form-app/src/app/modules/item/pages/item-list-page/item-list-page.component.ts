import { Component, OnInit } from "@angular/core";
import { ItemClient, ItemsPageVm, ItemVm } from "@app/web-api-client";
import { BehaviorSubject, Observable } from "rxjs";
import { map, tap } from "rxjs/operators";

@Component({
	selector: "roksh-item-list-page",
	templateUrl: "./item-list-page.component.html",
	styleUrls: ["./item-list-page.component.scss"],
})
export class ItemListPageComponent implements OnInit {
	public items$: Observable<ItemVm[]>;
	public isLoading: BehaviorSubject<boolean> = new BehaviorSubject(true);

	constructor(private itemService: ItemClient) {}

	public ngOnInit(): void {
		this.items$ = this.itemService.getAll().pipe(
			tap(() => this.isLoading.next(true)),
			map((data: ItemsPageVm) => {
				return data.items ? data.items : [];
			}),
			tap(() => this.isLoading.next(false))
		);
	}
}
