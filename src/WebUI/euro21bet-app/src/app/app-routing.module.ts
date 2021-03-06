import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import { NotFoundPageComponent } from './core/components';
import { ContactPageComponent } from './core/components/contact-page/contact-page.component';
import { ROUTES } from './core/configs';

const routes: Routes = [
	{
		path: '',
		canActivate: [AuthGuard],
		canActivateChild: [AuthGuard],
		children: [
			{
				path: '',
				redirectTo: ROUTES.MATCH,
				pathMatch: 'full',
			},
			{
				path: ROUTES.TEAM,
				loadChildren: () =>
					import('@modules/team/team.module').then(m => m.TeamModule)
			},
			{
				path: ROUTES.STANDINGS,
				loadChildren: () =>
					import('@modules/standings/standings.module').then(m => m.StandingsModule)
			},
			{
				path: ROUTES.MATCH,
				loadChildren: () =>
					import('@app/modules/match/match.module').then(m => m.MatchModule)
			},
			{
				path: ROUTES.CONTACT,
				component: ContactPageComponent
			},
			{
				path: ROUTES.NOT_FOUND,
				component: NotFoundPageComponent
			}
		]
	},
	{
		path: '**',
		redirectTo: `/${ROUTES.NOT_FOUND}`
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
