import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StandingsPageComponent } from './pages/standings-page/standings-page.component';
import { StandingsComponent } from './standings.component';

const routes: Routes = [
	{
		path: '',
		component: StandingsComponent,
		children: [
			{
				path: '',
				component: StandingsPageComponent
			},
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class StandingsRoutingModule { }
