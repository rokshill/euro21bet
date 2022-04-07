import { Component, Input } from "@angular/core";
import { ItemVm } from "@app/web-api-client";

@Component({
	selector: "roksh-item-list",
	templateUrl: "./item-list.component.html",
	styleUrls: ["./item-list.component.scss"],
})
export class ItemListComponent {
	@Input() public items: ItemVm[] = [];
	@Input() public isLoading = true;
}
