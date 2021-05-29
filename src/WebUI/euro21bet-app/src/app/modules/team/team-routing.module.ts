import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeamListPageComponent } from './pages';
import { TeamComponent } from './team.component';

const routes: Routes = [
	{
		path: '',
		component: TeamComponent,
		children: [
			{
				path: '',
				component: TeamListPageComponent
			},
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class TeamRoutingModule { }
