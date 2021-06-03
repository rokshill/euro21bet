import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MatchComponent } from './match.component';
import { MatchListPageComponent } from './pages';

const routes: Routes = [
	{
		path: '',
		component: MatchComponent,
		children: [
			{
				path: '',
				component: MatchListPageComponent
			},
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class MatchRoutingModule { }
