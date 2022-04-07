import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ROUTES } from "@app/core/configs";
import { AuthGuard } from "@auth0/auth0-angular";
import { ItemComponent } from "./item.component";
import { AdminPageComponent } from "./pages/admin-page/admin-page.component";
import { AnonymousPageComponent } from "./pages/anonymous-page/anonymous-page.component";
import { UserPageComponent } from "./pages/user-page/user-page.component";

const routes: Routes = [
	{
		path: "",
		component: ItemComponent,
		children: [
			{
				path: "",
				redirectTo: ROUTES.ANONYMOUS,
				pathMatch: "full",
			},
			{
				path: ROUTES.ANONYMOUS,
				component: AnonymousPageComponent,
			},
			{
				path: ROUTES.USER,
				canActivate: [AuthGuard],
				component: UserPageComponent,
			},
			{
				path: ROUTES.ADMIN,
				canActivate: [AuthGuard],
				component: AdminPageComponent,
			},
		],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class ItemRoutingModule {}
