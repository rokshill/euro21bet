import { NgModule } from "@angular/core";
import { SharedModule } from "@app/shared/shared.module";
import { ItemListComponent } from "./components/item-list/item-list.component";
import { ItemRoutingModule } from "./item-routing.module";
import { ItemComponent } from "./item.component";
import { ItemListPageComponent } from "./pages";
import { AdminPageComponent } from "./pages/admin-page/admin-page.component";
import { AnonymousPageComponent } from "./pages/anonymous-page/anonymous-page.component";
import { UserPageComponent } from "./pages/user-page/user-page.component";

@NgModule({
	declarations: [
		ItemComponent,
		ItemListPageComponent,
		ItemListComponent,
		AnonymousPageComponent,
		UserPageComponent,
		AdminPageComponent,
	],
	imports: [SharedModule, ItemRoutingModule],
})
export class ItemModule {}
