import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { NotFoundPageComponent } from "./core/components";
import { ContactPageComponent } from "./core/components/contact-page/contact-page.component";
import { ROUTES } from "./core/configs";

const routes: Routes = [
	{
		path: "",
		// canActivate: [AuthGuard],
		// canActivateChild: [AuthGuard],
		children: [
			{
				path: "",
				redirectTo: ROUTES.ITEM,
				pathMatch: "full",
			},
			{
				path: ROUTES.ITEM,
				loadChildren: () =>
					import("@app/modules/item/item.module").then(
						(m) => m.ItemModule
					),
			},
			// {
			// 	path: ROUTES.USER,
			// 	loadChildren: () =>
			// 		import("@modules/item/item.module").then(
			// 			(m) => m.ItemModule
			// 		),
			// },
			// {
			// 	path: ROUTES.ADMIN,
			// 	loadChildren: () =>
			// 		import("@modules/item/item.module").then(
			// 			(m) => m.ItemModule
			// 		),
			// },
			{
				path: ROUTES.CONTACT,
				component: ContactPageComponent,
			},
			{
				path: ROUTES.NOT_FOUND,
				component: NotFoundPageComponent,
			},
		],
	},
	{
		path: "**",
		redirectTo: `/${ROUTES.NOT_FOUND}`,
	},
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
